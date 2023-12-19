namespace CreationalPattern;

public class MazeBuilder
{
    public virtual void BuildMaze() { }
    public virtual void BuildDoor(int roomFrom, int roomTo) { }
    public virtual void BuildRoom(int roomNo) { }
    public virtual Maze GetMaze()
    {
        return new Maze();
    }
}
