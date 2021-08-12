# CongreeLang Client-Server Application
## About Project
The solution has two applications. 
- The first one is one **Client Console Application**: It creates a request to the server with the document text to be analyzed and the tag information to be extracted and shows the analysis results
![Client](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/1ClientApp.png)

- The second is an **Asp.NET Core Web API Application**: It analyzes the submitted XML document and the requested tags. It stores the request and result infos in the database
![Server](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/2Server.png)

- Db: Request, response, and analysis informations store on MS Sql Server database
![Db](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/3Db.png)

## UML
![UML](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/4UML_Diagram.png)
 - Document: It stores XML file information to be analyzed (XMLDocument data, date, etc.)
 - Tag: It stores the information of the elements to be extracted from the document and the contents of the tag (p, how comprehensible individual...  e.g.)
 - Analysis: It stores document analysis information (StartDate, EndDate, ElapsedMiliseconds e.g.)
 - AnalysisItem: It stores the repeating vocabulary and the number of occurrences associated with the Analysis, Document, and Tag

## Installation 
The project uses .NET 5 Framework and MS SQL Server. 
 - If you do not have .NET >= 5.x installed, you can download it here: [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
 - If you do not have an MS SQL Server instance, you can download the Express version from here: [MS SQL Express](https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads)
 - Install Visual Studio 2019 Express for, you can download it here: [Visual Studio 2019](https://visualstudio.microsoft.com/tr/vs/express/) 

## Running Application
 - git clone **https://github.com/mehmetyagci/CongreeLang.git**
 - cd CongreeLang
 - open CongreeLang.sln with Visual Studio 2019
 - Rebuil Solution

![Rebuild Folder](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/7Rebuild.png)

 - Change MS SQL Server connection string setting in **appsettings.json** file on **Server Project**
![Connection String Setting](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/5ConnString.png)

 - Delete Migration Folder on Server Project
![Migration Folder](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/6DeleteMigrationFolder.png)

 - Set **Server** as starter project
![Server starter project](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/8SetServerStarterProject.png)

 - Open **Package Manager Console** Window then run below commands
 ```bash
 Add-Migration Initial 
 ```

 ```bash
 Update-Database 
 ```
![Create Migration](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/9CreateMigration.png)


## How to Use the App
 - Server Application must start firstly. Run CongreeLang.sln for starting Server project
![Server](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/2Server.png)

- Open Power shell then run below command for starting Client Application
 ```bash
 cd CongreeLang\Client\bin\Debug\net5.0
  ```

- For starting Client App use below command.
 ```bash
.\Client.exe "1.xml" "p;li" "2.xml" "p" "3.xml" "li" "4.xml" "p;li" "5.xml" "p" "6.xml" "li" "7.xml" "p;li" "8.xml" "p" "9.xml" "li"
 ```

- Multiple requests sending asynchronously. You can see elapsed miliseconds info
![Result1](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/10Result.png)

- Each XML document analysis result seen beetween 
>**Index - $indexnumber Document processing starting** 
and 
>**Index - $indexnumber Document processing ended**
![Result2](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/11Result.png)