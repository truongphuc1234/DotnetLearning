namespace Lexi;

public class Rectangle : Glyph
{
    int x0, y0, x1, y1;

    List<Glyph> childs = new();
    Glyph? parent;

    public Rect Bounds()
    {
        return new Rect
        {
            X0 = x0,
            X1 = x1,
            Y1 = y1,
            Y0 = y0
        };
    }

    public Glyph Child(int index)
    {
        return childs[index];
    }

    public void Draw(Window w)
    {
        w.DrawRect(x0, x1, y0, y1);
    }

    public void Insert(Glyph glyph, int index)
    {
        childs.Insert(index, glyph);
        Console.WriteLine($"Insert glyph at {index}");
    }

    public bool Intersect(Point p)
    {
        throw new NotImplementedException();
    }

    public Glyph Parent()
    {
        throw new NotImplementedException();
    }

    public void Remove(Glyph glyph)
    {
        throw new NotImplementedException();
    }
}
