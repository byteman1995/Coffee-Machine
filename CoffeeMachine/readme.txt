Solution Description :-
1. Solution Name : CoffeeMachine
2. Tech Stack : .Net Core 3.1 MVC : https://dotnet.microsoft.com/download/dotnet/3.1
3. Solution consists of 2 section : 
	a. CoffeeMachine Solution
	b. CoffeeMachine Test Solution

Solution Execution Steps :-
1. Install .Net Core 3.1
2. The ResourcesTest contains the input1.json and input2.json for which the test case is defined
3. Proceed to CoffeeMachine folder containing CoffeeMachine.sln and run the following in command prompt : 
	a. dotnet restore : To restore packages and dependencies
	b. dotnet test CoffeeMachine.sln : To run the defined tests for the solution
4. This test would trigger the CoffeeMachine solution and generate output in ResorucesTest folder as output1.txt and output2.txt
