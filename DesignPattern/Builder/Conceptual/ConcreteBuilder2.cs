
namespace Builder.Conceptual;

public class ConcreteBuilder2 : Builder
{
    public void BuildPart()
    {

    }

    public Product GetProduct2()
    {
        return new Product();
    }
}
