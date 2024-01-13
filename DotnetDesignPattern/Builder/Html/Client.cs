namespace DotnetDesignPattern.Builder.Html ;

public class Client()
{
    public void TestSimpleHtmlBuilder()
    {
        HtmlElement element = HtmlElement
            .Create("ul")
            .AddChild("li", "hello")
            .AddChild("li", "world");
        var toStr2 = element.ToString();
    }
}
