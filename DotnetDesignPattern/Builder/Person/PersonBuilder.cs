namespace DotnetDesignPattern.Builder.Person;

public abstract class PersonBuilder
{
    protected Person person;

    public PersonBuilder()
    {
        this.person = new Person();
    }

    protected PersonBuilder(Person person)
    {
        this.person = person;
    }

    public PersonAddressBuilder Lives => new PersonAddressBuilder();
    public PersonJobBuilder Works => new PersonJobBuilder();

    public static implicit operator Person(PersonBuilder personBuilder)
    {
        return personBuilder.person;
    }
}
