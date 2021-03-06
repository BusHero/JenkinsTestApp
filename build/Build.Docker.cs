using static Nuke.Common.Tools.Docker.DockerTasks;
using Nuke.Common.Tools.Docker;

using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.IO;

#pragma warning disable CA1822, IDE0051  // Mark members as static

partial class Build
{
    [Parameter, Secret] readonly string DockerRegistryKey;
    [Parameter] readonly string Tag = "latest";
    [Parameter] readonly int? PublishPort;

    private const string Server = "ghcr.io";
    private const string UserName = "bushero";
    private const string AppImageName = "jenkinstestapp";

    private string PushableAppImageName => $"{Server}/{UserName}/{AppImageName}:{Tag}";
    private string AppContainerName => $"{AppImageName}_{Tag}";

    Target LoginRegistry => _ => _
        .Requires(() => DockerRegistryKey)
        .Executes(() => DockerLogin(_ => _
            .SetServer(Server)
            .SetUsername(UserName)
            .SetPassword(DockerRegistryKey)
    ));

    Target BuildAppImage => _ => _
        .Executes(() => DockerBuild(_ => _
            .SetQuiet(true)
            .SetTag(AppImageName)
            .SetPath(Solution.JenkinsTestApp.Directory)
        ));

    Target TagAppImage => _ => _
        .DependsOn(LoginRegistry)
        .Requires(() => Tag)
        .Executes(() => DockerTag(_ => _
            .SetSourceImage(AppImageName)
            .SetTargetImage(PushableAppImageName)
        ));

    Target PushAppImage => _ => _
        .DependsOn(TagAppImage)
        .Requires(() => Tag)
        .Executes(() => DockerPush(_ => _
            .SetName(PushableAppImageName)
    ));

    Target RunAppImage => _ => _
        .Requires(() => PublishPort)
        .Requires(() => Tag)
        .Executes(() => DockerRun(_ => _
            .SetRm(true)
            .SetDetach(true)
            .SetPublish($"{PublishPort}:80")
            .SetNetwork(JenkinsNetworkName)
            .SetNetworkAlias(AppContainerName)
            .SetName(AppContainerName)
            .SetImage(PushableAppImageName)
    ));

    [LocalExecutable("/bin/sh")]
    readonly Tool Sh;

    Target RunSmokeTest => _ => _
        .Requires(() => Tag)
        .Executes(() => Sh(
            arguments: $"run-smoketest.sh {AppContainerName}:80",
            workingDirectory: JenkinsScriptsRoot));

    Target StopAppContainer => _ => _
        .Requires(() => Tag)
        .Executes(() => Sh(
            arguments: $"stop-docker-container.sh {AppContainerName}",
            workingDirectory: JenkinsScriptsRoot));

}

#pragma warning restore CA1822, IDE0051  // Mark members as static
