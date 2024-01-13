namespace DotnetDesignPattern.Builder.Car;

public class Car
{
    public CarType Type;
    public int WheelSize;
}


public class CarClient
{
    public void Execute()
    {
        var car = CarBuilder
            .Create()
            .OfType(CarType.CrossOver)
            .WithWheels(18)
            .Build();
    }
}
