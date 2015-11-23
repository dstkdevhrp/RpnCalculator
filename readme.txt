RPN (Reverse Polish Notation) expression calculator

Requirement: 'unit-test assignment.docx'

1. Function:
	- Validate the input string arrays (Whether it is a RPN list)
	- Calculate the RPN values (Allow double value)
	- Interact with user via console, output the hint and error message

2. Develop environment:
	- You can test run 'RpnCalculator.exe' directly (currently in ./obj/Debug folder)
	- VS2015 community, MSTest
	- .NET 4.5.2, C#

3. Unit test:
	- method level: isDouble, isOperator, validInput, calculate
	- class level: calculate & constructor