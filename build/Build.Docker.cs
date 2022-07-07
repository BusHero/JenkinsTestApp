using static Nuke.Common.Tools.Docker.DockerTasks;
using Nuke.Common.Tools.Docker;

using Nuke.Common;

#pragma warning disable CA1822, IDE0051  // Mark members as static

partial class Build
{
    [Parameter, Secret] readonly string DockerRegistryKey;

    Target LoginRegistry => _ => _
        .Requires(() => DockerRegistryKey)
        .Executes(() => DockerLogin(_ => _
            .SetServer("ghcr.io")
            .SetUsername("BusHero")
            .SetPassword(DockerRegistryKey)
    ));
}

#pragma warning restore CA1822, IDE0051  // Mark members as static
