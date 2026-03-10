public class Program
{
	public static void Main()
	{
		//List of strings
		List<string> operandList = new List<string>()
		{
			"add",
			"subtract",
			"multiply",
			"divide",
			"sqrt",
			"pythag",
			"sin",
			"info",
			"rng",
		};
		
		//Getting the operation
		Console.WriteLine("Supported operations: add, subtract, multiply, divide, sqrt, pythag, sin, rng and info");
		Console.WriteLine("Enter operation: ");
		string operation = Console.ReadLine();
		//We check against the list of potential operation strings. If the string is invalid we return. If not then continue the script.
		if(!operandList.Contains(operation))
		{
			Console.WriteLine("Not a supported operation");
			return;
		}
		
		//Info on the software
		if(operation == "info")
		{
			Console.WriteLine("This application was written by Archilux in C# based on JourneyJ012's TerminalCalculator");
			Console.WriteLine("This software falls under GNU General Public License v3.0 (GPL)");
			Console.WriteLine("The supported operations in this version are: add, subtract, multiply, divide, sqrt, pythag, sin and rng.");
			Console.WriteLine("This is v1.0.0 built on 10/03/2026");
			return;
		}
		
		//Console.WriteLine(operation); Debug to see if the operation was recieved
		
		//Getting the numbers for the operand
		Console.WriteLine("Enter numbers seperated by commas: ");
		string[] numberStrings = Console.ReadLine().Split(',');
		
		//Convert the numbers from a string array into a double array
		double[] numbers;
        try
        {
            numbers = numberStrings.Select(n => Convert.ToDouble(n)).ToArray();
        }
        catch 
        {
            Console.WriteLine("Contains an invalid number");
            return;
        }
		
		//Console.WriteLine(numbers[1]); Debug to see if the numbers were recieved and converted
		
		double result = 0.0; //I think this needs a number so that the compiler knows that if it doesnt get a number it can print something. 
		
		//Switch cases for all the operands
		switch (operation)
		{
			//This is pretty simple
			case "add":
				result = numbers.Sum();
				break;
				
			case "subtract":
				result = numbers[0];
                //
				for (int i = 1; i < numbers.Length; i++)
                {
					result-= numbers[i];
                }
				break;
			case "multiply":
                result = numbers[0];
                for (int i = 1; i < numbers.Length; i++)
                {
                    result*= numbers[i];
                }
                break;
            case "divide":
                result = numbers[0];
                for (int i = 1; i < numbers.Length; i++)
                {
                    //Check for a zero anywhere in the divide function
					if (numbers[i] == 0)
                    {
                        Console.WriteLine("Divide by zero not allowed!");
                        return;
                    }
                    result/= numbers[i];
                }
                break;
            case "sqrt":
                result = numbers[0];
                for (int i = 0; i < numbers.Length; i++)
                {
                    //Check if the sqrt operation has a negative number
					if (numbers[i] < 0)
                    {
                        Console.WriteLine("The square root of negative numbers is not defined");
                        return;
                    }
                }
				//Check if the sqrt operand has more than one number. If so stop application.
				if(numbers.Length >= 2)
                {
                    Console.WriteLine("Can only square root one number at a time.");
                    return;
                }
                
                result = Math.Sqrt(numbers[0]);
                break;
			case "pythag":
				result = numbers[0];
				for (int i = 0; i < numbers.Length; i++)
                {
					if (numbers[i] <= 0)
					{
				   		//Check for 0 or below anywhere in the pythag function
						Console.WriteLine("Cannot include 0 or a negative number in the pythaogrean theorem");
						return;
					}
                }

				if(numbers.Length >= 3)
				{
					//Check for 3 or more numbers
					Console.WriteLine("Pythagorean theorem only takes 2 numbers.");
					return;
				}
				
				result = Math.Sqrt(Math.Pow(numbers[0], 2) + Math.Pow(numbers[1], 2));
				break;
			case "sin":
				if(numbers.Length >= 2)
                {
                    //Check for 2 or more numbers
					Console.WriteLine("Can only Sin one number at a time.");
                    return;
                }
				//Math is hard
				result = Math.Sin(numbers[0] * Math.PI/180);
				break;
			case "rng":
				if(numbers.Length >=3)
				{
					Console.WriteLine("Can only accept 2 range values");
					return;
				}
				result = new Random().NextDouble() * (numbers[0] - numbers[1]) + numbers[1];
				break;
			default:
				//Default if the input is not a supported operand. This can't really get called as we check the operand after it gets entered.
				Console.WriteLine("Not a supported operation");
				Console.WriteLine("If you see this create a bug report on GitHub");
				return;
		}
	
		//Writing the result to console
		Console.WriteLine("Result: " + result);
	}
}

