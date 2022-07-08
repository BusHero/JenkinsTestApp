param(
	[string]$jenkinsContainerName,
	[string]$jenkinsImageName,
	[string]$jenkinsNetwork,
	[int]$sshPort
)

. "${PSScriptRoot}\common.ps1"

if (Test-DockerContainerRunning -jenkinsContainerName $jenkinsContainerName) {
	Write-Host "'${jenkinsContainerName}' is already running"
}
else {
	docker run `
		--rm `
		--detach `
		--group-add 0 `
		--volume '//var/run/docker.sock:/var/run/docker.sock' `
		--volume jenkins-data:/var/jenkins_home `
		--volume jenkins-docker-certs:/certs/client:ro `
		--publish 8080:8080 `
		--publish "${sshPort}:${sshPort}" `
		--network $jenkinsNetwork `
		--network-alias jenkins `
		--name $jenkinsContainerName `
		$jenkinsImageName
}