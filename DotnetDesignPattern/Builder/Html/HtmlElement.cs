using System.Text;

namespace DotnetDesignPattern.Builder.Html;

public class HtmlElement
{
    public string Name;
    public string Text;
    private readonly Lazy<List<HtmlElement>> elements = new();
    private const int indentSize = 2;

    public IReadOnlyList<HtmlElement> Elements => elements.Value;

    public HtmlElement() : this("", "") { }

    private HtmlElement(string name, string text)
    {
        Name = name;
        Text = text;
    }
    public static implicit operator HtmlElement(HtmlBuilder builder) => builder.Build();

    public static HtmlBuilder Create(string name) => HtmlBuilder.Init(name);

    public override string ToString()
    {
        return ToStringImpl(0);
    }

    private string ToStringImpl(int indent)
    {
        var sb = new StringBuilder();
        var i = new string(' ', indentSize * indent);
        sb.Append($"{i}<{Name}>\n");
        if (!string.IsNullOrWhiteSpace(Text))
        {
            sb.Append(new string(' ', indentSize * (indent + 1)));
            sb.Append(Text);
            sb.Append("\n");
        }
        foreach (var e in Elements)
        {
            sb.Append(e.ToStringImpl(indent + 1));
        }
        sb.Append($"{i}</{Name}>\n");
        return sb.ToString();
    }

    public class HtmlBuilder
    {
        private readonly string rootName;
        private HtmlElement root = new HtmlElement();

        public static HtmlBuilder Init(string rootName)
        {
            return new HtmlBuilder(rootName);
        }

        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.elements.Value.Add(e);
            return this;
        }

        public HtmlElement Build() => root;

        public override string ToString()
        {
            return root.ToString();
        }

        private HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            this.root.Name = rootName;
        }
    }
}
