# Demonstrator/TA Marketplace

Each year the School of Computer Science and Statistics assigns Demonstrators and Teaching Assistants to modules to support the delivery of labs and tutorials and to assist with the grading of student work. This is currently a largely manual process performed by staff in the School, supported by IT systems for maintaining relevant data. 

This project will turn the allocation process on its head and instead allow Demonstrators and Teaching Assistants to pick the modules that they wish to be
assigned to, subject to some constraints. This will be the primary functionality. Secondary functionality will include an approval workflow for demonstrator allocation
and functionality for an administrator to manually change allocations.

## Running the Code

Due to time constraints, deployment of the web app has not been implemented and the project must be ran locally on your own machine, requiring installation of the individual components used.

This project is built off the ASP.NET framework, which can be downloaded **[here](https://dotnet.microsoft.com/download)**.

MariaDB will also need to be installed, found **[here](https://mariadb.org/download/)**. An important note when installing MariaDB is to set the password as `marketplace`, this is important for connecting the web app to the database.

Once both of these programs are installed, you may run `Startup.bat` to install dependencies, migrate models to the database and run the program.

This file needs only to be ran the first time through to install dependencies, to run the app afterwards, in the terminal you must write `dotnet watch run` and the app will begin running and a tab will open in your default browser to the home page. From here you can stop it with Ctrl + C.

## Contributors

* Bair Buyrchiyev
* Vince Casey
* Cian Crowley
* Vitali Borsak
* Conn Breathnach
* Jacqueline McCarrick
