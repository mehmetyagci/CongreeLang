## CongreeLang Client-Server Application
The solution has two application. 
- One is Client Console Application: It creates a request to the server with the document text to be analyzed and the tag information to be extracted and shows the analysis results.
![Client](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/ClientApp.png)
- Second is Server Rest Service Application: It analyzes the sent XML document and the requested tags. It stores the request and result information in the database.
![Server](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/Server.png)
![Db](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/Db.png)

## UML
![UML](https://github.com/mehmetyagci/CongreeLang/blob/master/screehshots/UML_Diagram.png)
 - Document: It stores XML file information to be analyzed.(XMLDocument data, date )
 - Tag: It stores the information of the elements to be extracted from the document.(p;li e.g.)
 - TagContent: It stores Tag related contents.

 - Analysis: It stores document analysis information. (StartDate, EndDate, ElapsedMiliseconds e.g.)
 - AnalysisItem: It stores the repeating vocabulary and the number of occurrences associated with the Analysis, Document and Tag.

 ## Client 
