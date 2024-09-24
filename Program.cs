
using System;

Console.WriteLine("------- Strategy design pattern -------");   
Console.WriteLine();

Console.WriteLine(@"Select filters: 
1. Even numbers
2. Odd numbers
3. Positive numbers");


var numbers = new List<int> { 10, 14, -100, 55, 17, 22 };
List<int> result;


var userInput = Console.ReadLine();
switch(userInput)
{
    case "Even":
        result = SelectEven(numbers);
        break;
    case "Odd":
        result = SelectOdd(numbers);
        break;
    case "Positive":
        result = SelectPositive(numbers);
        break;
    default:
        throw new NotSupportedException($"{userInput} is not supported filter at this moment.");
}
Print(result);

Console.ReadKey();

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(", ", numbers));
}

List<int> SelectEven(List<int> numbers)
{
    var result = new List<int>();

    foreach (var number in numbers)
    {
        if (number % 2 == 0)
        {
            result.Add(number);
        }
    }

    return result;
}

List<int> SelectOdd(List<int> numbers)
{
    var result = new List<int>();

    foreach (var number in numbers)
    {
        if (number % 2 != 0)
        {
            result.Add(number);
        }
    }

    return result;
}

List<int> SelectPositive(List<int> numbers)
{
    var result = new List<int>();

    foreach (var number in numbers)
    {
        if (number > 0)
        {
            result.Add(number);
        }
    }

    return result;
}