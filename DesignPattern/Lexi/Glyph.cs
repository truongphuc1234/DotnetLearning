namespace Lexi;

public interface Glyph
{
    public void Draw(Window w);
    public Rect Bounds();
    public bool Intersect(Point p);
    public void Insert(Glyph glyph, int index);
    public void Remove(Glyph glyph);
    public Glyph Child(int index);
    public Glyph Parent();
}
