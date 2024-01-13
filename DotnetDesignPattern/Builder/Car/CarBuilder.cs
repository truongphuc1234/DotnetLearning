namespace DotnetDesignPattern.Builder.Car;

public class CarBuilder
{
    public static ISpecifyCarType Create()
    {
        return new Impl();
    }
}
