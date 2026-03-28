namespace OscarProjectTracker;

public static class Dashboard
{
    public static void Show(List<Hobby> hobbies)
    {
        Console.WriteLine("\n=== PROJECT DASHBOARD ===");

        var allProjects = hobbies
            .SelectMany(h => h.Projects.Select(p => (Hobby: h.Name, Project: p)))
            .OrderByDescending(p => p.Project.LastUpdated)
            .ToList();

        foreach (var entry in allProjects)
        {
            Console.WriteLine($"[{entry.Hobby}] {entry.Project.Name} (Updated: {entry.Project.LastUpdated})");
        }
    }
}