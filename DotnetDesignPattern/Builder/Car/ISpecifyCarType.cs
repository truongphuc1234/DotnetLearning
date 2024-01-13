namespace DotnetDesignPattern.Builder.Car;

public interface ISpecifyCarType
{
    public ISpecifyWheelSize OfType(CarType type);
}
