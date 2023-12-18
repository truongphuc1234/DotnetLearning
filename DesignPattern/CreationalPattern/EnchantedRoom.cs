namespace CreationalPattern;

public class EnchantedRoom : Room
{
    private Spell spell;

    public EnchantedRoom(int roomNumber, Spell spell) : base(roomNumber)
    {
        this.spell = spell;
    }
}
