# Insurance_Management_Csharp
## Overview
This is a codebase for an insurance management system, written in C# & ADO.net, that provides a way to manage and track insurance policies. The system allows creating and managing policies, clients, and claims.

This is a C# program that represents a basic insurance management system. The program contains the following classes:

* Customer
* Insurance
* Program

The 'Customer' class contains information about a customer and its policies. It has the following attributes:

1. [x] Customer ID
2. [x] Customer Name
3. [x] Email ID
4. [x] Password
5. [x] Address
6. [x] Contact Number
7. [x] Nominee Name
8. [x] Customer Relationship
9. [x] Policy Number
10. [x] Policy Type
11. [x] Date
12. [x] Title
13. [x] Sum Assured
14. [x] Premium
15. [x] Term
16. [x] Next Due

The class also has several constructors to set the customer information and a method Assign_Value which assigns values to the customer policy and adds it to the system.

The Insurance class is used to manage the insurance policies for the customers. It has a method AddPolicy which adds a new policy to the system and a method fetchCustomer which retrieves all the customer information.

The Program class contains the main method which runs the program and implements the functionalities of the system. It allows the user to add a new policy, display information for a customer, and display information for all customers.

*** This Code is not well optimised and do not have full functionalities ***
## How to Run the Program
* Clone the repository onto your local machine
* Open the program in Visual Studio
* Build and run the program
* Follow the instructions provided in the console to add a new policy or display information

## Requirements
* Operating System: Windows 7 or later, MacOS or Linux with Mono installed.
* .NET Framework: C# code requires the .NET Framework, which can be installed as a standalone package or as part of Visual Studio. The latest version of the .NET Framework can be downloaded from Microsoft's website.
* Development Environment: A development environment such as Visual Studio, Visual Studio Code, or MonoDevelop must be installed. These IDEs provide a user-friendly interface for writing, compiling, and debugging C# code.
* Compiler: The .NET Framework includes a C# compiler that is used to compile C# code into an executable file.
* Code Editor: A code editor such as Visual Studio Code, Notepad++, or Sublime Text must be installed to write and edit the C# code.
## Contributions
If you find any bugs or have suggestions for improvements, feel free to open an issue or make a pull request.
## Conclusion
This program is a basic representation of an insurance management system. It demonstrates the use of classes and methods in C# and provides a starting point for a more complex insurance management system.