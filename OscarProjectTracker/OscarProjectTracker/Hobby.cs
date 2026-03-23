namespace OscarProjectTracker;

using System.Collections.Generic;

class Hobby
{
    public string Name { get; set; }
    public List<Project> Projects { get; set; }

    public Hobby(string name)
    {
        Name = name;
        Projects = new List<Project>();
    }
}