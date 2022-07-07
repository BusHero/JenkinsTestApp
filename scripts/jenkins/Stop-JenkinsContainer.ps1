param([string]$jenkinsContainerName)

. "${PSScriptRoot}\common.ps1"

if (Test-DockerContainerRunning -jenkinsContainerName $jenkinsContainerName) {
	docker stop $jenkinsContainerName | Out-Null
}
else {
	Write-Host "No container named '${jenkinsContainerName}' is currentrly running"
}