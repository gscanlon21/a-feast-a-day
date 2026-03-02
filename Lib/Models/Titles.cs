using Microsoft.AspNetCore.Components;

namespace Lib.Models;

public record Titles(MarkupString Header, MarkupString? Description, MarkupString? Footer)
{
    public Titles(string header) : this(new MarkupString(header), null, null) { }
    public Titles(string header, string description) : this(new MarkupString(header), new MarkupString(description), null) { }
    public Titles(string header, string description, string footer) : this(new MarkupString(header), new MarkupString(description), new MarkupString(footer)) { }
};
