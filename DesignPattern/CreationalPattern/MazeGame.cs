namespace CreationalPattern;

public class MazeGame
{
    public Maze CreateMaze()
    {
        var maze = new Maze();
        var r1 = new Room(1);
        var r2 = new Room(2);
        var door = new Door(r1, r2);
        maze.AddRoom(r1);
        maze.AddRoom(r2);

        r1.SetSide(Direction.North, new Wall());
        r1.SetSide(Direction.East, door);
        r1.SetSide(Direction.South, new Wall());
        r1.SetSide(Direction.West, new Wall());

        r2.SetSide(Direction.North, new Wall());
        r2.SetSide(Direction.East, new Wall());
        r2.SetSide(Direction.South, new Wall());
        r2.SetSide(Direction.West, door);

        return maze;
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

