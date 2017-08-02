This is a simple to implement but lightweight and highly efficient package used to log informations from .Net applications to Database
Usage:

1. In class where Efuelite Db Logger is to be used, just import the name space "EfueliteSolutionsDbLogger".

2. To log an information, call string status = DbLogger.WriteLog(string DBConnectionString, string Log);
	This function returns a string status telling the outcome of its operation.
	Parameters:
	Supply connection string to the database(mssql) where it will log information.
	The information to log in string format.
	
	
3. To read all information from log, just call var obj = DbLogger.ReadAllLog(string DBConnectionString); 
	This function returns a list object containing all logs found.	
	Parameters:
	Supply connection string to the database(mssql) where it will log information.
	
	
4.  To delete all logs, just call string status = DbLogger.DeleteAllLog(string DBConnectionString);
	This function returns a string status telling the outcome of its operation.
	Parameters:
	Supply connection string to the database(mssql).
	
5. To read all information from log within a specified date range, just call var obj = DbLogger.ReadLogInDateRange(string DBConnectionString, DateTime StartDate, DateTime EndDate, bool SortByLatest); 
	This function returns a list object containing all logs found.	
	Parameters:
	Supply connection string to the database(mssql) where it will log information.
	Supply the start date 
	Supply the end date
	supply SortByLatest as either true/false ==> If true, it will return a list of logs within the given date range sorted with the latest records appearing first and vice-versa

6.  To read specific number of log, just call var obj = DbLogger.ReadSpecificNumberOfLog(string DBConnectionString, int NumberOfLogs, bool SortByLatest)
	This function returns a list object containing all logs found.	
	Parameters:
	Supply connection string to the database(mssql) where it will log information.
	Supply the number of logs to retrieve e.g. 1,2 e.t.c.
	supply SortByLatest as either true/false ==> If true, it will return a list of logs within the given date range sorted with the latest records appearing first and vice-versa
	
7.  To read specific number of log within a specified date range, just call var obj = DbLogger.ReadSpecificNumberOfLogInDateRange(string DBConnectionString, DateTime StartDate, DateTime EndDate, int NumberOfLogs, bool SortByLatest)	
	This function returns a list object containing all logs found.	
	Parameters:
	Supply connection string to the database(mssql) where it will log information.
	Supply the start date 
	Supply the end date
	Supply the number of logs to retrieve e.g. 1,2 e.t.c.
	supply SortByLatest as either true/false ==> If true, it will return a list of logs within the given date range sorted with the latest records appearing first and vice-versa


8.  To search logs a specified criteria, just call var obj = DbLogger.SearchLog(string DBConnectionString, string SearchCriteria)
	This function returns a list object containing all logs found.	
	Parameters:
	Supply connection string to the database(mssql) where it will log information.
	Supply the search term/word(s) 	
	
For further enquiries, you can send mails to info@efuelite.com