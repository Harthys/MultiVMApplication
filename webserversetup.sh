#!/usr/bin/env bash

sudo apt-get update
curl -sL https://deb.nodesource.com/setup_12.x | sudo -E bash -
sudo apt-get install -y nodejs
cp -R /vagrant/ReactApp/react-app react-app
cd react-app
sudo rm package-lock.json
sudo npm install
sudo npm install typescript
sudo npm install axios --save
sudo sysctl -w fs.inotify.max_user_watches=100000
sudo npm start
