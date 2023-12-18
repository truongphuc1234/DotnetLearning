namespace CreationalPattern;

public class Door : MapSite
{
    Room room1;
    Room room2;
    bool isOpen;

    public Door(Room room1, Room room2)
    {
        this.room1 = room1;
        this.room2 = room2;
    }

    public void Enter()
    {
    }

    public Room OtherSideRoom(Room room)
    {
        if (room == room1)
        {
            return room2;
        }
        return room1;
    }
}
