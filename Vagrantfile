# -*- mode: ruby -*-
# vi: set ft=ruby :

# All Vagrant configuration is done below. The "2" in Vagrant.configure
# configures the configuration version (we support older styles for
# backwards compatibility). Please don't change it unless you know what
# you're doing.
Vagrant.configure("2") do |config|
  config.vm.box = "ubuntu/xenial64"


  #Creating a separate VM for the web server
  config.vm.define "webserver" do |webserver|
	webserver.vm.hostname = "webserver"
	webserver.vm.network "forwarded_port", guest: 80, host: 8080, host_ip: "127.0.0.1"
	webserver.vm.network "private_network", ip: "192.168.2.11"
	
	webserver.vm.provision "shell", inline: <<-SHELL
	  apt-get update
	  apt-get install -y apache2
	  # Change VM's webserver's configuration to use shared folder.
      # (Look inside test-website.conf for specifics.)
      cp /vagrant/website.conf /etc/apache2/sites-available/
      # install our website configuration and disable the default
      a2ensite website
      a2dissite 000-default
      service apache2 reload
	SHELL
  end


  #Creating a separate VM for the database server
  config.vm.define "dbserver" do |dbserver|
    dbserver.vm.hostname = "dbserver"
	dbserver.vm.network "private_network", ip: "192.168.2.12"
	
	dbserver.vm.provision "shell", inline: <<-SHELL
	  apt-get update
	SHELL
  end
  
  #Creating a separate VM for the admin
  config.vm.define "adminserver" do |adminserver|
    adminserver.vm.hostname = "adminserver"
	adminserver.vm.network "private_network", ip: "192.168.2.13"
	
	adminserver.vm.provision "shell", inline: <<-SHELL
	  apt-get update
	SHELL
  end
end
