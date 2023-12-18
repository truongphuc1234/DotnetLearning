namespace AbstractPattern;

public class MotifWidgetFactory : WidgetFactory
{
    public ScrollBar CreateScrollBar()
    {
        return new MotifScrollBar();
    }

    public Window CreateWindow()
    {
        return new MotifWindow();
    }
}
