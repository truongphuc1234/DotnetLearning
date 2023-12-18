namespace Lexi;

public class Composition : Glyph
{
    List<Glyph> children = new();
    Compositor compositor;
    public Rect Bounds()
    {
        throw new NotImplementedException();
    }

    public Glyph Child(int index)
    {
        throw new NotImplementedException();
    }

    public void Draw(Window w)
    {
        throw new NotImplementedException();
    }

    public void Insert(Glyph glyph, int index)
    {

        children.Insert(index, glyph);

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
