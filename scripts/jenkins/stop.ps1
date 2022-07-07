$jenkins = docker ps --filter 'name=jenkins' --format '{{.Names}}'
if ($jenkins) {
	docker stop jenkins | Out-Null
}