#!/usr/bin/env bash

DBUSER=MULTI_USER
DBPASSWD=userpass
MSSQL_PID='developer'
sudo curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -
sudo curl https://packages.microsoft.com/config/ubuntu/16.04/prod.list > /etc/apt/sources.list.d/mssql-release.list
sudo apt-get update
sudo ACCEPT_EULA=Y apt-get install -y --allow-unauthenticated msodbcsql17
sudo ACCEPT_EULA=Y apt-get install -y --allow-unauthenticated mssql-tools
sudo echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bash_profile
sudo echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc
sudo ln -s /opt/mssql-tools/bin/* /usr/local/bin/
#sudo service mysql stop
 wget -qO- https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
sudo add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/16.04/mssql-server-2019.list)"
#curl https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
#curl https://packages.microsoft.com/config/ubuntu/16.04/prod.list | sudo tee /etc/apt/sources.list.d/msprod.list 
#curl https://packages.microsoft.com/config/ubuntu/16.04/prod.list > /etc/apt/sources.list.d/mssql-release.list
#echo "THIS IS A TEST"
sudo apt-get update
#sudo apt -y install unixodbc
#echo "WOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO"
#sudo apt-get -y install msodbcsql17
#echo "THIS IS ALSO A TEST"
sudo apt-get -y install mssql-server
#sudo apt-get -y install mssql-tools unixodbc-dev

sudo MSSQL_SA_PASSWORD='Securepassword123' \
     MSSQL_PID=$MSSQL_PID \
     /opt/mssql/bin/mssql-conf -n setup accept-eula
systemctl status mssql-server --no-pager
cp /vagrant/database-setup.sql database-setup.sql

sqlcmd -S 192.168.2.12 -U sa -P 'Securepassword123' -i database-setup.sql