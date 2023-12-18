namespace CreationalPattern;

public class Room : MapSite
{
    private MapSite[] sides = new MapSite[4];
    private int roomNumber;

    public Room(int roomNumber)
    {
        this.roomNumber = roomNumber;
    }

    public MapSite GetSide(Direction direction)
    {
        return sides[(int)direction];
    }

    public void SetSide(Direction direction, MapSite site)
    {
        sides[(int)direction] = site;
    }

    public void Enter()
    {
        throw new NotImplementedException();



    }
}
