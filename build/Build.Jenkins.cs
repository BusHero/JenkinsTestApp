using System;
using static Nuke.Common.Tools.PowerShell.PowerShellTasks;
using static Nuke.Common.Tools.Docker.DockerTasks;
using Nuke.Common.Tools.PowerShell;
using Nuke.Common.Tools.Docker;

using Nuke.Common;
using System.Linq.Expressions;

#pragma warning disable CA1822, IDE0051  // Mark members as static

partial class Build
{
    private const string JenkinsImage = "docker-in-docker-jenkins";
    private const string JenkinsContainerName = "jenkins";

    Target BuildJenkins => _ => _
        .DependsOn(StartDockerDesktop)
        .Executes(() => DockerBuild(_ => _
            .SetTag(JenkinsImage)
            .SetPath(RootDirectory / "scripts" / "jenkins")
        ));


    Target StartJenkins => _ => _
        .DependsOn(BuildJenkins)
        .Executes(() => DockerRun(_ => _
            .SetRm(true)
            .SetDetach(true)
            .SetGroupAdd("0")
            .SetVolume(
                "//var/run/docker.sock:/var/run/docker.sock",
                "jenkins-data:/var/jenkins_home",
                "jenkins-docker-certs:/certs/client:ro")
            .SetPublish("8080:8080", "43833:43833")
            .SetNetwork("jenkins")
            .SetNetworkAlias("jenkins")
            .SetName(JenkinsContainerName)
            .SetImage(JenkinsImage)
        ));

    Target StopJenkins => _ => _
        .Executes(() => DockerStop(_ => _
            .SetContainers(JenkinsContainerName)));
    
    Target RelaunchJenkins => _ => _
        .DependsOn(StopJenkins, StartJenkins)
        .Executes();
}

#pragma warning restore CA1822, IDE0051  // Mark members as static
