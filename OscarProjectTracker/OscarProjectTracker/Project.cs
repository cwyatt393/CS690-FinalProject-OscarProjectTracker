namespace OscarProjectTracker;

using System.Collections.Generic;

public class Project
{
    public string Name { get; set; }
    public List<string> ProgressNotes { get; set; } = new();
    public List<Resource> Resources { get; set; } = new();
    public Reminder Reminder { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.Now;
    public int Priority { get; set; } = 0;   // (0=none, 1=low, 2=med, 3=high)

    public Project(string name)
    {
        Name = name;
    }

    public bool IsReminderDue()
    {
        return Reminder != null && Reminder.DueDate <= DateTime.Now;
    }

}
