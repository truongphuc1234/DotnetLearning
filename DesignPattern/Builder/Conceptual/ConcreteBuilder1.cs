namespace Builder.Conceptual;

public class ConcreteBuilder1 : Builder
{
    public void BuildPart()
    {

    }

    public Product GetProduct1()
    {
        return new Product();
    }
}
