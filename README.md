# HairSalon.Solution
#### Hair Salon - 09/27/21 


#### By Gabriel Ayala

## Technologies Used :floppy_disk:
* _C#_
* _Entity_
* _.Net 5 SDK_
* _REPL_
* _MySQL_
* _MySQL Workbench_
* _Razor_
* _ASP.NET Core_


## Description :page_with_curl:
_A web application that allows the user to manage her stylists and their clients._

## Schema


## Setup/Installation Requirements :triangular_ruler:

* _Clone github repo: https://github.com/Gabeaya/VendorOrder.Solution.git_
* _Navigate the directory: (cd top name directory)_
* _Open in Vs code: code ._
* _Run: dotnet restore VendorOrder_
* _The line above will install necessary dependencies._
* _Importing the dump file database:_
  - Open MySQL Workbench.
  - In the Navigator> Administration window, select Data Import/Restore.
  - In Import Options select Import from Self-Contained File.
  - Click the button with the two dots located to the right of the pathway.
  - Locate the HairSalon project folder.
  - Select the dump file titled, "gabriel_ayala.sql."
  - Click Ok.
  - Navigate to the tab called Import Progress and click Start Import in the bottom right corner.
  - Finally in the Navigator>Schemas tab, right click and select Refresh all to make the database appear.
  
* _Next we will need a connection string: create a file within the main directory titled, "appsettings.json."_
* _Add the following within our new file: {
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=gabriel_ayala;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
    }
}_
* _IMPORTANT NOTE: Do not iclude the brackets when entering your username or password._



* _Run: dotnet run in order to use the application in the browser._


## License :clipboard:
MIT &copy; 2021 _Gabriel Ayala_
## Contact Information :mailbox:

_Gabriel Ayala:
gabeayala100@gmail.com_