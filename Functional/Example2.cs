namespace Example2;

public class ComplexCustomObject
{
    public int PropertyA { get; internal set; }
    public int PropertyB { get; internal set; }
    public int PropertyC { get; internal set; }
    public int PropertyD { get; internal set; }
}

public class DataSource
{
    public int Something { get; internal set; }
    public int SomethingElse { get; internal set; }
    public int Ping { get; internal set; }
    public int Pong { get; internal set; }
    public bool AlternativeTuesday { get; internal set; }
    public int CaptainKirk { get; internal set; }
    public int MrSpock { get; internal set; }
    public int NumberOne { get; internal set; }
    public int CaptainPicard { get; internal set; }
}

public class DataStore2
{

    public ComplexCustomObject NewMethod()
    {
        var dataSource = GetSourceData();
        var obj = new ComplexCustomObject();
        obj.PropertyA = dataSource.Something + dataSource.SomethingElse;
        obj.PropertyB = dataSource.Ping + dataSource.Pong;
        if (dataSource.AlternativeTuesday)
        {
            obj.PropertyC = dataSource.CaptainKirk;
            obj.PropertyD = dataSource.MrSpock;
        }
        else
        {
            obj.PropertyC = dataSource.CaptainPicard;
            obj.PropertyD = dataSource.NumberOne;
        }
        return obj;
    }

    private ComplexCustomObject MakeObject(DataSource source)
    {
        return new ComplexCustomObject
        {

            PropertyA = source.Something + source.SomethingElse,
            PropertyB = source.Ping + source.Pong,
            PropertyC = source.AlternativeTuesday ? source.CaptainKirk : source.CaptainPicard,
            PropertyD = source.AlternativeTuesday ? source.MrSpock : source.NumberOne,
        };
    }

    private DataSource GetSourceData()
    {
        return new DataSource();
    }
}
