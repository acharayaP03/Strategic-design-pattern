﻿
using System;

Console.WriteLine("------- Strategy design pattern -------");   
Console.WriteLine();

Console.WriteLine(@"Select filters: 
1. Even numbers
2. Odd numbers
3. Positive numbers");


var numbers = new List<int> { 10, 14, -100, 55, 17, 22 };

var userInput = Console.ReadLine();
List<int> result = new NumbersFilter().FilterBy(userInput, numbers);


Print(result);

Console.ReadKey();

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(", ", numbers));
}



public class NumbersFilter
{
    public List<int> FilterBy(string filterByType, List<int> numbers)
    {
        switch(filterByType)
        {
            case "Even":
                return  SelectEven(numbers);
            case "Odd":
               return SelectOdd(numbers);
                
            case "Positive":
                return SelectPositive(numbers);
            
            default:
                throw new NotSupportedException($"{filterByType} is not supported filter at this moment.");
        }
    }

    private List<int> SelectEven(List<int> numbers)
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

    private List<int> SelectOdd(List<int> numbers)
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

    private List<int> SelectPositive(List<int> numbers)
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
}