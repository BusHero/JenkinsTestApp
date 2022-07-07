docker run `
  --rm `
  --detach `
  --group-add 0 `
  --volume '//var/run/docker.sock:/var/run/docker.sock' `
  --volume jenkins-data:/var/jenkins_home `
  --volume jenkins-docker-certs:/certs/client:ro `
  --publish 8080:8080 `
  --publish 43833:43833 `
  --network jenkins `
  --network-alias jenkins `
  --name jenkins `
  docker-in-docker-jenkins
