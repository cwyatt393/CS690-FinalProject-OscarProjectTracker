namespace OscarProjectTracker;

using System.Collections.Generic;

public class Project
{
    public string Name { get; set; }
    public List<string> ProgressNotes { get; set; } = new();
    public List<Resource> Resources { get; set; } = new();   // NEW
    public Reminder Reminder { get; set; }                   // NEW
    public DateTime LastUpdated { get; set; } = DateTime.Now; // NEW

    public Project(string name)
    {
        Name = name;
    }

}
