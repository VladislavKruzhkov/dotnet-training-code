## Material Content 
- *Value and Reference Types.*
- *Classes vs Struct. Boxing and Unboxing. Naming conventions.*
- *Static and instance class.*
- *Type members - Fields, Constructors, Methods (Property, Indexers, Operators , Event - preview), Nested types. Enum.*
- *Partial Types and Methods.*

## Books & Useful References 
- [C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015.](http://shop.oreilly.com/product/0636920040323.do)
   - *Chapter 3.* Creating Types in C# [Code Listings](http://www.albahari.com/nutshell/ch03.aspx)
- [C# 5.0 Unleashed. Bart De Smet. Sams Publishing. 2013.](https://www.goodreads.com/book/show/16284093-c-5-0-unleashed)
   - *Chapter 9.* Introducing Types
- [Programming C# 5.0. Ian Griffiths. O'Reilly Media. 2012.](http://shop.oreilly.com/product/0636920024064.do)
   - *Chapter 3.* Types [Download Example Code](https://resources.oreilly.com/examples/0636920024064/blob/master/Ch03.zip)
- [CLR via C#. Jeffrey Richter. Microsoft Press. 2010](https://www.goodreads.com/book/show/7121415-clr-via-c)
   - *Chapter 4.* Type Fundamentals
   - *Chapter 5.* Primitive, Reference, and Value Types
   - *Chapter 6.* Type and Member Basics
- [The CLR book. Stanislav Sidristij](https://github.com/sidristij/dotnetbook/blob/master/book/ru)
   - [*Chapter* Reference Types Vs ValueTypes](https://github.com/sidristij/dotnetbook/blob/master/book/ru/ReferenceTypesVsValueTypes.md)

## Tasks  
**Task1:** 
1) Create a console application called "Students".
2) Create a class "Student" which includes string **FullName** and string **Email** (name is like Name Surname, email is like name.surname@epam.com).
3) Create a constuctor for this class, which takes only Email (you can get the FullName from the Email).
4) Create a constructor for this class, which takes name and surname (you can get FullName and Email from name and surname).
5) In the main method create a string array "subjects" which contains 6 different shcool subjects ("Maths, "PE", etc..).
5) In the main method create 3 students with different names using first constructor
- (like var student1c1 = new Student ("vasya.pupkin@epam.com")
6) In the main method create 3 students with the same names names using second constructor
- (like var student1c2 = new Student ("Vasya", "Pupkin").
7) Overall you should have 3 unique students (but there are 2 instances of each student)
9) Create a new empty dictionary of <Student, HashSet<string>> called "studentSubjectDict".
10) For each student (remebmer that we got 6 variables despite there are only 3 unique students) fill in the dictionary like

- studentSubjectDict[student1c1] = %3 random values from the subject array%
- studentSubjectDict[student2c1] = %3 random values from the subject array%
- studentSubjectDict[student3c1] = %3 random values from the subject array%
- studentSubjectDict[student1c2] = %3 random values from the subject array%
- studentSubjectDict[student2c2] = %3 random values from the subject array%
- studentSubjectDict[student3c2] = %3 random values from the subject array%

11) Make sure that after that there are only three records in the "studentSubjectDict" dictionary
(for that purpose you should override Equals() and GetHashCode() for students class).

**Task2:** 
*Goal of the task is to get acquainted with Array.Sort, Stopwatch and System.Diagnostics.Process.*

1) Create a console application called "Performance".
2) Create a class "C" with just one int field called "i".
3) Create a struct "S" with just one int field called "i". 
4) In the main method create an array of 100000 "C" called "classes" and intialize it with random numbers.
5) In the main method create an array of 100000 "S" called "structs" and intialize it with random numbers.
5) Calculate PrivateMemorySize64 delta before and after arrays initialization (for each array separately). Print the results to console.
6) Compare the difference between these deltas and print it to the console.
7) Execute Array.Sort< С >(classes) и Array.Sort< S >(structs). Print the execution time of each sort to the console.