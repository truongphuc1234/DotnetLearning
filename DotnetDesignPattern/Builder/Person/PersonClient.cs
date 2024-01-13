namespace DotnetDesignPattern.Builder.Person;

public class PersonClient
{
    public void CreateSimplePerson()
    {
        var pb = new PersonBuilder();
        Person p = pb
            .Lives
            .At("123 Nguyen Luong Bang")
            .In("Danang")
            .WithPostalCode("123456")
            .Works
            .At("Pracs")
            .AsA("Engineer")
            .Earning(12000);
    }
}
