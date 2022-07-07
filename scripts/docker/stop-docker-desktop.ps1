$DockerDesktop = 'Docker Desktop'

Write-Host 'Check Docker Desktop process ... '
if (Get-Process `
		-Name $DockerDesktop `
		-ErrorAction Ignore) {
	Write-Host 'Found processes related to Docker Desktop'
	Stop-Process `
		-Name $DockerDesktop `
		-ErrorAction Ignore
	Write-Host 'Done'
}
else {
	Write-Host 'No process related to Docker desktop is currently running'
}

