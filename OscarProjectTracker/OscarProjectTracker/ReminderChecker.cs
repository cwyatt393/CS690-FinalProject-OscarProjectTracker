namespace OscarProjectTracker;

public static class ReminderChecker
{
    public static void Check(List<Hobby> hobbies)
    {
        foreach (var hobby in hobbies)
        {
            foreach (var project in hobby.Projects)
            {
                if (project.IsReminderDue())
                {
                    Console.WriteLine($"\n🔔 REMINDER: [{hobby.Name}] {project.Name} — {project.Reminder.Message}");
                }
            }
        }
    }
}