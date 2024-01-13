namespace DotnetDesignPattern.Builder.Car;

public interface ISpecifyWheelSize
{
    public IBuildCar WithWheels(int size);
}
