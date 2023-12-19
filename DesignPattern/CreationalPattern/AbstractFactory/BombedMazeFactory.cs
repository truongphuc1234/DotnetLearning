
namespace CreationalPattern;

public class BombedMazeFactory : MazeFactory
{

    public override Wall MakeWall()
    {
        return new BombedWall();
    }

    public override Room MakeRoom(int roomNo)
    {
        return new RoomWithABomb(roomNo);
    }
}
