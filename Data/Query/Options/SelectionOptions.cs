namespace Data.Query.Options;

public class SelectionOptions : IOptions
{
    public SelectionOptions() { }

    /// <summary>
    /// Orders the variations in a random order 
    /// instead of using the last seen date.
    /// </summary>
    public bool Randomized { get; set; } = false;

    public bool HasData() => true;
}
