
using System;

Console.WriteLine("------- Strategy design pattern -------");   
Console.WriteLine();

Console.WriteLine(@"Select filters: 
1. Even numbers
2. Odd numbers
3. Positive numbers");


var numbers = new List<int> { 10, 14, -100, 55, 17, 22 };

var userInput = Console.ReadLine();

var fiteringStrategy = new FilteringStrategySelector().Select(userInput);
List<int> result = new NumbersFilter().FilterBy(fiteringStrategy, numbers);


Print(result);

Console.ReadKey();

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(", ", numbers));
}

public class FilteringStrategySelector
{

    private readonly Dictionary<string, Func<int, bool>> _strategies = new Dictionary<string, Func<int, bool>>
    {
        { "Even", number => number % 2 == 0 },
        { "Odd", number => number % 2 != 0 },
        { "Positive", number => number > 0 }
    };

    public Func<int, bool> Select(string filterByType)
    {

        if(!_strategies.ContainsKey(filterByType))
        {
            throw new NotSupportedException($"{filterByType} is not supported filter at this moment.");
        }
        return _strategies[filterByType];
    }
}

public class NumbersFilter
{
    public List<int> FilterBy(Func<int, bool> predicate, List<int> numbers)
    {
        var result = new List<int>();

        foreach (var number in numbers)
        {
            if (predicate(number))
            {
                result.Add(number);
            }
        }

        return result;
    }
}