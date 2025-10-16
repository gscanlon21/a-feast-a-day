namespace Data.Entities.Microbiome;

internal class DistinctCondition
{
    public int Taxon { get; set; }

    // varchar(1)
    public string Direction { get; set; } = string.Empty;
}

