FROM jenkins/jenkins:2.346.1-jdk11

USER root
RUN apt-get update
RUN apt-get install \
    -y \
    lsb-release

RUN curl \
    -fsSLo /usr/share/keyrings/packages-microsoft-prod.deb \
    https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb 
RUN dpkg -i /usr/share/keyrings/packages-microsoft-prod.deb
RUN rm /usr/share/keyrings/packages-microsoft-prod.deb

RUN apt update
RUN apt install -y apt-transport-https
RUN apt install -y dotnet-sdk-6.0

RUN apt install net-tools -y

RUN curl \
    -fsSLo /usr/share/keyrings/docker-archive-keyring.asc \
    https://download.docker.com/linux/debian/gpg
RUN echo "deb [arch=$(dpkg --print-architecture) \
  signed-by=/usr/share/keyrings/docker-archive-keyring.asc] \
  https://download.docker.com/linux/debian \
  $(lsb_release -cs) stable" > /etc/apt/sources.list.d/docker.list
RUN apt-get update 
RUN apt-get install \
    -y \
    docker-ce-cli

USER jenkins
RUN jenkins-plugin-cli --plugins "blueocean:1.25.5 docker-workflow:1.28"