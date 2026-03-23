namespace OscarProjectTracker;

using System.Collections.Generic;

class Project
{
    public string Name { get; set; }
    public List<string> ProgressNotes { get; set; }

    public Project(string name)
    {
        Name = name;
        ProgressNotes = new List<string>();
    }
}