-This is an ASP.NET Web API application that uses three-tier architecture to provide clear separation of concerns between the controller (UI), business logic, and data access layers.  
-This API follows R.E.S.T. and S.O.L.I.D. principles and uses an attribute routing scheme.  
-All of the methods are asynchronous to improve the overall speed of the application.  
-External dependencies are injected into classes using interfaces to allow for easier unit testing and to promote loose coupling.  
-The Repository Pattern is leveraged to allow a variety of data access mechanisms to be used (hard coded data, SQL Server database, Oracle database, etc).  
-Entity framework is used to read data from the database and Fluent API is used to map entity classes to their data table counterparts (see DataAccess project – Maps – ProductMap.cs for an example).  
-The database is composed of two tables: Product and Category with Product being foreign keyed to the Category table via Category’s Id column.  
-This table structure promotes normalization and guards against non-existent or misspelled categories from being inserted.

-Third party libraries used in this app include Simple Injector for the dependency injection, NUnit and Moq for the unit tests, Strathweb.CacheOutput.WebApi2 for caching, and Swashbuckle for documentation.  
