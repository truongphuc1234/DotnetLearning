namespace CreationalPattern;

public class Client()
{
    public static void Execute()
    {
        var game = new MazeGame();
        var builder = new StandardMazeBuilder();
        game.CreateMaze(builder);
        var maze = builder.GetMaze();
    }
}
