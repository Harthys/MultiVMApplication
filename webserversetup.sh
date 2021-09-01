#!/usr/bin/env bash

apt-get update
apt-get install -y apache2

# Change VM's webserver's configuration to use shared folder.
# (Look inside test-website.conf for specifics.)
cp /vagrant/website.conf /etc/apache2/sites-available/

# install our website configuration and disable the default
a2ensite website
a2dissite 000-default
service apache2 reload