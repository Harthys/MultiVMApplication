#!/usr/bin/env bash

sudo apt-get update
wget https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-5.0
apt-get install -y nuget
cp -R /vagrant/WebApi WebApi
cd WebApi
nuget sources add -Name nuget -Source "https://api.nuget.org/v3/index.json"
sudo dotnet run --project WebApi