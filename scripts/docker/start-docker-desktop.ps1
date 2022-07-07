$DockerDesktop = 'Docker Desktop'

Write-Host 'Check Docker Desktop ... '
if (Get-Process `
		-Name $DockerDesktop `
		-ErrorAction Ignore) {
	Write-Host "$DockerDesktop is already running"
}
else {
	Write-Host "Start $DockerDesktop ..."

	Start-Process "${env:ProgramFiles}\Docker\Docker\$DockerDesktop.exe"

	Write-Host 'Done'
}