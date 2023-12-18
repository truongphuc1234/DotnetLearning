namespace CreationalPattern;

public class EnchantedMazeFactory : MazeFactory
{

    public override Room MakeRoom(int roomNo)
    {
        return new EnchantedRoom(roomNo, CastSpell());
    }

    public override Door MakeDoor(Room r1, Room r2)
    {
        return new DoorNeedingSpell(r1, r2);
    }

    private Spell CastSpell()
    {
        return new Spell();
    }
}
