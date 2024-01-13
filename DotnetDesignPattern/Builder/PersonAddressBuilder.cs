namespace DotnetDesignPattern.Builder;

public class PersonAddressBuilder : PersonBuilder
{
    public PersonAddressBuilder() : base() { }
    public PersonAddressBuilder(Person person) : base(person)
    {
    }

    public PersonAddressBuilder At(string streetName)
    {
        person.StreetAddress = streetName;
        return this;
    }

    public PersonAddressBuilder WithPostalCode(string postalCode)
    {
        person.PostCode = postalCode;
        return this;
    }

    public PersonAddressBuilder In(string city)
    {
        person.City = city;
        return this;
    }
}
