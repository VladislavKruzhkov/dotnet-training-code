## Tasks  
**Objective:**  
1. Develop a console application that uses LINQ queries to retrieve data. Data is stored in a .json file and represents information about the results of students tests.
2. Information about the student contains the name of the student, the name of the test, the date of the test and the assessment of the test for this student.
3. When the applications is being initialized, all the data from .json file should be loaded into memory. 
4. Provide ability to input search criteria using a search string as an input parameter (based on different flags).

Example:
Hello! Please input your criteria:
-name Ivan -minmark 3 -maxmark 5 -datefrom 20/11/2012 -dateto 20/12/2012 -test Maths

Result:
- Student        Test     Date        Mark
- Ivan Petrov    Maths    25/11/2012  4
- Ivan Ivanov    Maths    30/11/2012  3

5. Provide the ability to sort the result using -sort flag with two paramaters (for ex, -sort name asc)
6. Develop Unit Tests
