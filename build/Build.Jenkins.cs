using static Nuke.Common.Tools.PowerShell.PowerShellTasks;
using Nuke.Common.Tools.PowerShell;

using static Nuke.Common.Tools.Docker.DockerTasks;
using Nuke.Common.Tools.Docker;
using Nuke.Common;
using Nuke.Common.IO;

#pragma warning disable CA1822, IDE0051  // Mark members as static

partial class Build
{
    private const string JenkinsImage = "docker-in-docker-jenkins";
    private const string JenkinsContainerName = "jenkins";

    private readonly AbsolutePath JenkinsScriptsRoot = RootDirectory / "scripts" / "jenkins";

    Target BuildJenkins => _ => _
        .DependsOn(StartDockerDesktop)
        .Executes(() => DockerBuild(_ => _
            .SetTag(JenkinsImage)
            .SetPath(JenkinsScriptsRoot)
        ));

    Target RunJenkins => _ => _
        .DependsOn(BuildJenkins)
        .Executes(() => PowerShell(_ => _
            .SetFile(JenkinsScriptsRoot / "Run-JenkinsContainer.ps1")
            .SetFileKeyValueParameter("jenkinsContainerName", JenkinsContainerName)
            .SetFileKeyValueParameter("jenkinsImageName", JenkinsImage)
            .SetNoProfile(true)
            .SetNoLogo(true)
        ));

    Target StopJenkins => _ => _
        .Executes(() => PowerShell(_ => _
            .SetFile(JenkinsScriptsRoot / "Stop-JenkinsContainer.ps1")
            .SetFileKeyValueParameter("jenkinsContainerName", JenkinsContainerName)
            .SetNoProfile(true)
            .SetNoLogo(true)
        ));
    
    Target RelaunchJenkins => _ => _
        .DependsOn(StopJenkins, RunJenkins)
        .Executes();
}

#pragma warning restore CA1822, IDE0051  // Mark members as static
