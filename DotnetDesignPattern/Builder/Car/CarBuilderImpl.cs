namespace DotnetDesignPattern.Builder.Car;

public class CarBuilderImpl : ISpecifyCarType, ISpecifyWheelSize, IBuildCar
{
    private readonly Car car = new Car();

    public Car Build()
    {
        return car;
    }

    public ISpecifyWheelSize OfType(CarType type)
    {
        car.Type = type;
        return this;
    }

    public IBuildCar WithWheels(int size)
    {
        car.WheelSize = size;
        return this;
    }
}
