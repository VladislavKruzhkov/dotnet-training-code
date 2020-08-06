## Tasks
- Create a console application (UI).
- Create a class library that allows to convert a string to an integer number. Do not use Parse, TryParse, Convert etc. 
- Console application should reference the library (for demo puproses). 
- Configure logger into the console application (use NLog). Set up two levels of logging - one for errors only, second one for all other levels. 
- Class library should take an ILogger interface as a dependency (from console application) and use it to log every action. 
- All of the exceptions should be logged properly and rethrown to the console application.
- Console application should handle the exceptions and provide the user with the exception details.
