namespace Bank;

public class StandardBankAccount
{
    public decimal Balance { get; set; }
    public decimal InterestRate { get; set; }
}

public class PremiumBankAccount : StandardBankAccount
{
    public decimal BonusInterestRate { get; set; }
}

public class MillionaresBankAccount : StandardBankAccount
{
    public decimal OverflowBalance { get; set; }
}

public class MonopolyPlayerBankAccount : StandardBankAccount
{
    public decimal PassingGoBonus { get; set; }
    public object CurrentSquare { get; internal set; }
}

public class Bank
{
    public decimal CalculateNewBalance(StandardBankAccount sba)
    {
        if (sba.GetType() == typeof(PremiumBankAccount))
        {
            var pba = (PremiumBankAccount)sba;
            if (pba.Balance > 10000)
            {
                return pba.Balance * (pba.InterestRate + pba.BonusInterestRate);
            }
        }

        if (sba.GetType() == typeof(MillionaresBankAccount))
        {
            var mba = (MillionaresBankAccount)sba;
            return (mba.Balance * mba.InterestRate) + (mba.OverflowBalance * mba.InterestRate);
        }

        if (sba.GetType() == typeof(MonopolyPlayerBankAccount))
        {
            var mba = (MonopolyPlayerBankAccount)sba;
            return (mba.Balance * mba.InterestRate) + mba.PassingGoBonus;
        }
        return sba.Balance * sba.InterestRate;
    }

    public decimal CalculateNewBalance2(StandardBankAccount sba)
    {
        if (sba is PremiumBankAccount pba)
        {
            if (pba.Balance > 10000)
            {
                return pba.Balance * (pba.InterestRate + pba.BonusInterestRate);
            }
        }

        if (sba is MillionaresBankAccount mba)
        {
            return (mba.Balance * mba.InterestRate) + (mba.OverflowBalance * mba.InterestRate);
        }

        if (sba is MonopolyPlayerBankAccount vba)
        {
            return (vba.Balance * vba.InterestRate) + vba.PassingGoBonus;
        }
        return sba.Balance * sba.InterestRate;
    }

    public decimal CalculateNewBalance3(StandardBankAccount sba)
    {
        switch (sba)
        {
            case PremiumBankAccount pba when pba.Balance > 10000:
                return pba.Balance * (pba.InterestRate + pba.BonusInterestRate);
            case MillionaresBankAccount mba:
                return (mba.Balance * mba.InterestRate) + (mba.OverflowBalance * mba.InterestRate);
            case MonopolyPlayerBankAccount mba:
                return (mba.Balance * mba.InterestRate) + mba.PassingGoBonus;
            default:
                return sba.Balance * sba.InterestRate;
        }
    }

    public decimal CalculateNewBalance4(StandardBankAccount sba) =>
        (sba) switch
        {
            PremiumBankAccount { Balance: > 10000 } pba
                => pba.Balance * (pba.InterestRate + pba.BonusInterestRate),
            MillionaresBankAccount mba
                => (mba.Balance * mba.InterestRate) + (mba.OverflowBalance * mba.InterestRate),
            MonopolyPlayerBankAccount mba => (mba.Balance * mba.InterestRate) + mba.PassingGoBonus,
            _ => sba.Balance * sba.InterestRate
        };

    public decimal CalculateNewBalance5(StandardBankAccount sba) =>
        (sba) switch
        {
            PremiumBankAccount { Balance: > 10000 and <= 20000 } pba
                => pba.Balance * (pba.InterestRate + pba.BonusInterestRate),
            PremiumBankAccount { Balance: > 20000 } pba
                => pba.Balance * (pba.InterestRate + pba.BonusInterestRate * 1.25M),
            MillionaresBankAccount mba
                => (mba.Balance * mba.InterestRate) + (mba.OverflowBalance * mba.InterestRate),
            MonopolyPlayerBankAccount { CurrentSquare: not "In Jail" } mba
                => (mba.Balance * mba.InterestRate) + mba.PassingGoBonus,
            _ => sba.Balance * sba.InterestRate
        };

    public Person GetInput(string[] input)
    {
        var bladeRunner = new Movie("1", "2", new[] { "1", "2" });
        var bladeRunnerDirections = bladeRunner with { Title = "New Runner" };
        return new Person
        {
            FirstName = input.First(),
            LastName = input.Last(),
            MiddleNames = input is [_, .. var mns, _] ? mns : Enumerable.Empty<string>()
        };
    }
}

public record Movie(string Title, string Directory, IEnumerable<string> Cast);

public class Person
{
    public string FirstName { get; set; }
    public IEnumerable<string> MiddleNames { get; set; }
    public string LastName { get; set; }
}
