# studio_task
Task

# Solution
1- The task consists of two main parts 
	A- Well-Structured data and writing clean code using (interfaces , inheritance , injection, delegates, enums)
	B- Random every step to acheive the goal
	
2- Hierarchy
	- Exception
		- UserInputException => to handle user input errors
	- Helpers
		-Enums => to store data structured (TroopType)
	- Managers
		- IFactoryManager => to generate troops
		- IRandomManager => to be responsible for any random data
		- IUserInterface => to hande user Input and Output
	- Interfaces
		- IFactoryManager
		- IRandomManager
		- IUserInterface
	- Models
		- BaseTroop => troop base class