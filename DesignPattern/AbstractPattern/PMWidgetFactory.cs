namespace AbstractPattern;

public class PMWidgetFactory : WidgetFactory
{
    public ScrollBar CreateScrollBar()
    {
        return new PMScrollbar();
    }

    public Window CreateWindow()
    {
        return new PMWindow();
    }
}
