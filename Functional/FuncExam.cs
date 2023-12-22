namespace FuncExample;

public class FuncExam
{
    private readonly Func<Person, DateTime, string> SayHello = (Person p, DateTime today) =>
        $"{today} : {p.Name}";
    private IEnumerable<Func<Employee, string>> descriptors = new Func<Employee, string>[]
    {
        x => "First Name = " + x.FirstName,
        x => "Last Name = " + x.LastName,
        x => "Middle Name = " + string.Join(" ", x.MiddleNames),
    };

    public string DescribeEmployee(Employee e)
    {
        return string.Join(Environment.NewLine, descriptors.Select(x => x(e)));
    }

    public bool IsPasswordValid(string password)
    {
        if (password.Length <= 6)
        {
            return false;
        }
        if (password.Length > 20)
        {
            return false;
        }
        if (!password.Any(x => Char.IsLower(x)))
        {
            return false;
        }
        if (!password.Any(x => Char.IsUpper(x)))
        {
            return false;
        }
        if (!password.Any(x => Char.IsSymbol(x)))
        {
            return false;
        }
        if (
            password.Contains("Justin", StringComparison.OrdinalIgnoreCase)
            && password.Contains("Birber", StringComparison.OrdinalIgnoreCase)
        )
        {
            return false;
        }
        return true;
    }

    public bool IsPasswordValid2(string password) =>
        password.IsValid(
            new Func<string, bool>[]
            {
                x => x.Length > 6,
                x => x.Length <= 20,
                x => x.Any(y => Char.IsLower(y)),
                x => x.Any(y => Char.IsUpper(y)),
                x => x.Any(y => Char.IsSymbol(y)),
            }
        );

    public void Ex6()
    {
        var doctorLookup = new[] { (1, "ABC"), (2, "DBE"), (3, "ENF"), (4, "JFJFJ"), }.ToDictionary(
            x => x.Item1,
            x => x.Item2
        );
    }

    public IEnumerable<int> GenerateRandomNumbers()
    {
        var rnd = new Random();
        var returnValue = new List<int>();
        for (var i = 0; i < 100; i++)
        {
            returnValue.Add(rnd.Next(1, 100));
        }
        return returnValue;
    }
}

public static class FuncExtension
{
    public static bool IsValid<T>(this T @this, params Func<T, bool>[] rules) =>
        rules.All(x => x(@this));

    public static bool IsInvalid<T>(this T @this, params Func<T, bool>[] rules) =>
        !@this.IsValid(rules);

    public static MatchValueOrDefault<TInput, TOutput> Match<TInput, TOutput>(
        this TInput @this,
        params (Func<TInput, bool> IsMatch, Func<TInput, TOutput> Transform)[] matches
    )
    {
        var match = matches.FirstOrDefault(x => x.IsMatch(@this));
        var returnValue = match.Transform(@this) ?? default;
        return new MatchValueOrDefault<TInput, TOutput>(returnValue, @this);
    }

    public static Func<TKey, TValue?> ToLookup<TKey, TValue>(this IDictionary<TKey, TValue> @this)
    {
        return x => @this.TryGetValue(x, out TValue? value) ? value : default;
    }
}

public class MatchValueOrDefault<TInput, TOutput>
{
    private readonly TOutput value;
    private readonly TInput originalValue;

    public MatchValueOrDefault(TOutput value, TInput originalValue)
    {
        this.value = value;
        this.originalValue = originalValue;
    }
}

internal class Person
{
    public string? Name { get; internal set; }
}

public class Employee
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public IEnumerable<string> MiddleNames { get; set; } = new string[1];
}
