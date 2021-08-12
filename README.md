## CongreeLang Client-Server Application
The solution has two applications. 
- The first one is one Client Console Application: It creates a request to the server with the document text to be analyzed and the tag information to be extracted and shows the analysis results.
![Client](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/1ClientApp.png)
- The second is one Asp.NET Core Web API Application: It analyzes the sent XML document and the requested tags. It stores the request and result information in the database.
![Server](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/2Server.png)
- Db: Request, Response and Analysis Results stores on MS Sql Server
![Db](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/3Db.png)

## UML
![UML](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/4UML_Diagram.png)
 - Document: It stores XML file information to be analyzed.(XMLDocument data, date etc.)
 - Tag: It stores the information of the elements to be extracted from the document and the contents of tag.(p, how comprehensible individual...  e.g.)
 - Analysis: It stores document analysis information. (StartDate, EndDate, ElapsedMiliseconds e.g.)
 - AnalysisItem: It stores the repeating vocabulary and the number of occurrences associated with the Analysis, Document and Tag.

## Installation 
 The project uses .NET 5 Framework and MS Sql Server. 
 - If you do not have .NET >= 5.x installed, you can download it here: [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
 - If you do not have MS Sql Server instance, you can download Express version from here: [MS Sql Express](https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads)
 - Install Visual Studio 2019 Express for,you can download it here: [Visual Studio 2019](https://visualstudio.microsoft.com/tr/vs/express/)  

## Running Application
* git clone https://github.com/mehmetyagci/CongreeLang.git
* cd CongreeLang
* open CongreeLang.sln with Visual Studio 2019
*Rebuilg Solution
![Rebuild Folder](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/7Rebuild.png)

 ## How to Use the App
 - Change Sql server connection string setting in appsettings.json file on Server Project
![Connection String Setting](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/5ConnString.png)
- Delete Migration Folder on Server Project
![Migration Folder](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/6DeleteMigrationFolder.png)
- Set Server as starter project
![Server starter project](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/8SetServerStarterProject.png)
- Open Package Manager Console Window then run "Add-Migration Initial" command after run "Update-Database" command
![Create Migration](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/9CreateMigration.png)
- Run CongreeLang.sln for starting Server project
![Server](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/2Server.png)
-Open Power shell then cd CongreeLang\Client\bin\Debug\net5.0 folder for staring client app below command.
.\Client.exe "1.xml" "p;li" "2.xml" "p" "3.xml" "li" "4.xml" "p;li" "5.xml" "p" "6.xml" "li" "7.xml" "p;li" "8.xml" "p" "9.xml" "li" 


