
using System;

Console.WriteLine("------- Strategy design pattern -------");   
Console.WriteLine();


var numbers = new List<int> { 10, 14, -100, 55, 17, 22 };

var filteringStrategySelector = new FilteringStrategySelector();

Console.WriteLine(@"Select filters: ");
Console.WriteLine(string.Join(Environment.NewLine, filteringStrategySelector.FilteringStrategiesName));


var userInput = Console.ReadLine();

var fiteringStrategy = new FilteringStrategySelector().Select(userInput);
var result = new Filter().FilterBy(fiteringStrategy, numbers);


Print(result);
var words = new[] { "apple", "banana", "cherry", "date" };
var justWordsFiltered = new Filter().FilterBy(word => word.StartsWith("a"), words);

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
        { "Positive", number => number > 0 },
        { "Negative", number => number < 0 },
        { "All", number => true }
    };
    
    public IEnumerable<string> FilteringStrategiesName => _strategies.Keys;

    public Func<int, bool> Select(string filterByType)
    {

        if(!_strategies.ContainsKey(filterByType))
        {
            throw new NotSupportedException($"{filterByType} is not supported filter at this moment.");
        }
        return _strategies[filterByType];
    }
}

public class Filter
{
    public IEnumerable<T> FilterBy<T>(Func<T, bool> predicate, IEnumerable<T> numbers)
    {
        var result = new List<T>();

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