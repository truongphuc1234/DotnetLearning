namespace DotnetDesignPattern.Builder.Person;

public class PersonJobBuilder : PersonBuilder
{
    public PersonJobBuilder() : base() { }
    public PersonJobBuilder(Person person) : base(person)
    {
    }
    public PersonJobBuilder At(string companyName)
    {
        person.CompanyName = companyName;
        return this;
    }
    public PersonJobBuilder AsA(string position)
    {
        person.Position = position;
        return this;
    }
    public PersonJobBuilder Earning(int earning)
    {
        person.AnnualIncome = earning;
        return this;
    }
}
