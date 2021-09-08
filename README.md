## How to launch the vagrant servers

The VMs can be launched through the vagrant up command but the webserver and adminserver
will need to be run on separate command lines as they dont allow anything to be run
after it starts its server

e.g. running one of the servers
vagrant up webserver

## How to use the application

This application is used to store movies and reviews of those movies, this is
done by first creating a movie through the create movie button and then from
there, additional movies can be added or a review can be added to the movie
that now exists in the database

## Build

Note: this is a developement build so the api and react projects can be reconfigured for production builds

## Networking

When running the react application within your browser, you will need to run https://192.168.2.13:5001/Movie in a
separate tab to allow react to connect to the api