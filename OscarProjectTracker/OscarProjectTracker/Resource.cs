namespace OscarProjectTracker;

public class Resource
{
    public string Label { get; set; }
    public string Url { get; set; }

    public Resource(string label, string url)
    {
        Label = label;
        Url = url;
    }

    public override string ToString() => $"{Label}: {Url}";
}