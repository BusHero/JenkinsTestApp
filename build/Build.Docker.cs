using static Nuke.Common.Tools.Docker.DockerTasks;
using Nuke.Common.Tools.Docker;

using Nuke.Common;

#pragma warning disable CA1822, IDE0051  // Mark members as static

partial class Build
{
    [Parameter, Secret] readonly string DockerRegistryKey;
    [Parameter] readonly string Tag = "latest";

    private const string Server = "ghcr.io";
    private const string UserName = "bushero";
    private const string AppImageName = "jenkinstestapp";

    private string PushableAppImageName => $"{Server}/{UserName}/{AppImageName}:{Tag}";

    Target LoginRegistry => _ => _
        .Requires(() => DockerRegistryKey)
        .Executes(() => DockerLogin(_ => _
            .SetServer(Server)
            .SetUsername(UserName)
            .SetPassword(DockerRegistryKey)
    ));

    Target BuildImage => _ => _
        .DependsOn(Publish)
        .Executes(() => DockerBuild(_ => _
            .SetQuiet(true)
            .SetTag(AppImageName)
            .SetPath(Solution.JenkinsTestApp.Directory)
        ));

    Target TagImage => _ => _
        .DependsOn(LoginRegistry)
        .Requires(() => Tag)
        .Executes(() => DockerTag(_ => _
            .SetSourceImage(AppImageName)
            .SetTargetImage(PushableAppImageName)
        ));

    Target PushImage => _ => _
        .DependsOn(TagImage)
        .Requires(() => Tag)
        .Executes(() => DockerPush(_ => _
            .SetName(PushableAppImageName)
        ));
}

#pragma warning restore CA1822, IDE0051  // Mark members as static
