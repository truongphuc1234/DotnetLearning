
namespace CreationalPattern;

public class MazeGame
{
    public Maze CreateMaze()
    {
        var maze = MakeMaze();
        Room r1 = MakeRoom(1);
        var r2 = MakeRoom(2);
        var door = MakeDoor(r1, r2);
        maze.AddRoom(r1);
        maze.AddRoom(r2);

        r1.SetSide(Direction.North, MakeWall());
        r1.SetSide(Direction.East, door);
        r1.SetSide(Direction.South, MakeWall());
        r1.SetSide(Direction.West, MakeWall());

        r2.SetSide(Direction.North, MakeWall());
        r2.SetSide(Direction.East, MakeWall());
        r2.SetSide(Direction.South, MakeWall());
        r2.SetSide(Direction.West, door);

        return maze;
    }

    private Maze MakeMaze()
    {
        return new Maze();
    }

    protected virtual Room MakeRoom(int roomNo)
    {
        return new Room(roomNo);
    }

    protected virtual Door MakeDoor(Room roomFrom, Room roomTo)
    {
        return new Door(roomFrom, roomTo);
    }

    protected virtual Wall MakeWall()
    {
        return new Wall();
    }

    public Maze CreateMaze(MazeFactory factory)
    {
        var maze = factory.MakeMaze();
        var r1 = factory.MakeRoom(1);
        var r2 = factory.MakeRoom(2);
        var door = factory.MakeDoor(r1, r2);
        maze.AddRoom(r1);
        maze.AddRoom(r2);

        r1.SetSide(Direction.North, factory.MakeWall());
        r1.SetSide(Direction.East, door);
        r1.SetSide(Direction.South, factory.MakeWall());
        r1.SetSide(Direction.West, factory.MakeWall());

        r2.SetSide(Direction.North, factory.MakeWall());
        r2.SetSide(Direction.East, factory.MakeWall());
        r2.SetSide(Direction.South, factory.MakeWall());
        r2.SetSide(Direction.West, door);

        return maze;
    }

    public Maze CreateMaze(MazeBuilder builder)
    {
        builder.BuildMaze();
        builder.BuildRoom(1);
        builder.BuildDoor(1, 2);
        return builder.GetMaze();
    }
}

