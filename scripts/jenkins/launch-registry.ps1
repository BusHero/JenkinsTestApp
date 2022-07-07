docker run `
	--network jenkins `
	--network-alias registry `
	--rm `
	-d `
	-p 5000:5000 `
	-p 443:443 `
	--name registry `
	-v "$(Get-Location)/certs:/certs" `
	-e REGISTRY_HTTP_ADDR=0.0.0.0:443 `
	-e REGISTRY_HTTP_TLS_CERTIFICATE=/certs/domain.crt `
	-e REGISTRY_HTTP_TLS_KEY=/certs/domain.key `
	registry