namespace OscarProjectTracker;

public class Resource
{
    public string Label { get; set; }
    public string Url { get; set; }
    public string Tag { get; set; }

    
    public Resource(string label, string url, string tag = "")
    {
        Label = label;
        Url = url;
        Tag = tag;
    }

    public override string ToString() => $"{Label} [{Tag}]: {Url}";
}