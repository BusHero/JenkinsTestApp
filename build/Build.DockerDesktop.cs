using static Nuke.Common.Tools.PowerShell.PowerShellTasks;
using Nuke.Common.Tools.PowerShell;

using Nuke.Common;

#pragma warning disable CA1822, IDE0051  // Mark members as static
partial class Build
{
    //Target StartDockerDesktop => _ => _
    //    .Executes(() => PowerShell(_ => _
    //    .SetFile(RootDirectory / "scripts" / "docker" / "start-docker-desktop.ps1")
    //    .SetNoLogo(true)
    //    .SetNoProfile(true)));

    //Target StopDockerDesktop => _ => _
    //    .Executes(() => PowerShell(_ => _
    //    .SetFile(RootDirectory / "scripts" / "docker" / "stop-docker-desktop.ps1")
    //    .SetNoLogo(true)
    //    .SetNoProfile(true)));
}
#pragma warning restore CA1822, IDE0051  // Mark members as static
