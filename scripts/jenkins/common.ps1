function Test-DockerContainerRunning {
	param (
		[string]$jenkinsContainerName
	)
	docker ps `
		--filter "name=${jenkinsContainerName}" `
		--format '{{.Names}}'
}