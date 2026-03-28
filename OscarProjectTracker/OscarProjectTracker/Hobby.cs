namespace OscarProjectTracker;

using System.Collections.Generic;

public class Hobby
{
    public string Name { get; set; }
    public List<Project> Projects { get; set; } = new();

    public Hobby(string name)
    {
        Name = name;
    }

    public override string ToString() => Name;
}