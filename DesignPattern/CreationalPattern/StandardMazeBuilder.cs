namespace CreationalPattern;

public class StandardMazeBuilder : MazeBuilder
{
    private Maze currentMaze;

    public StandardMazeBuilder()
    {
        this.currentMaze = new Maze();
    }

    public override void BuildMaze()
    {
        currentMaze = new Maze();
    }

    public override Maze GetMaze()
    {
        return currentMaze;
    }

    public override void BuildRoom(int roomNo)
    {
        if (currentMaze.RoomNo(roomNo) is null)
        {
            var room = new Room(roomNo);
            currentMaze.AddRoom(room);
            room.SetSide(Direction.North, new Wall());
            room.SetSide(Direction.East, new Wall());
            room.SetSide(Direction.South, new Wall());
            room.SetSide(Direction.West, new Wall());
        }
    }

    public override void BuildDoor(int roomFrom, int roomTo)
    {
        var room1 = currentMaze.RoomNo(roomFrom);
        var room2 = currentMaze.RoomNo(roomTo);

        var door = new Door(room1, room2);

        room1.SetSide(CommonWall(room1, room2), door);
        room2.SetSide(CommonWall(room2, room1), door);
    }

    private Direction CommonWall(Room room1, Room room2)
    {
        return Direction.East;
    }


}
