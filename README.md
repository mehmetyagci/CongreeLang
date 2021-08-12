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
 - Document: It stores XML file information to be analyzed.(XMLDocument data, date )
 - Tag: It stores the information of the elements to be extracted from the document and the contents of tag.(p, how comprehensible individual...  e.g.)

 - Analysis: It stores document analysis information. (StartDate, EndDate, ElapsedMiliseconds e.g.)
 - AnalysisItem: It stores the repeating vocabulary and the number of occurrences associated with the Analysis, Document and Tag.

 ## How to Use the App
 - First way: Running projects from Visual Studio.  

 ## Installation and Launch
 The project uses .NET 5 Framework and MS Sql Server. 
 - If you do not have .NET >= 5.x installed, you can download it here: [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
 - If you do not have MS Sql Server instance, you can download it here: [MS Sql Express]https://go.microsoft.com/fwlink/?linkid=866658



