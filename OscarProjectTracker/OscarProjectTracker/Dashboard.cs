namespace OscarProjectTracker;

public static class Dashboard
{
    public static void Show(List<Hobby> hobbies, string filterHobby = null, string sortBy = "lastUpdated")
    {
        Console.WriteLine("\n=== PROJECT DASHBOARD ===");

        var allProjects = hobbies
            .SelectMany(h => h.Projects.Select(p => (Hobby: h.Name, Project: p)))
            .ToList();

        // FILTER
        if (!string.IsNullOrWhiteSpace(filterHobby))
        {
            allProjects = allProjects
                .Where(p => p.Hobby.Equals(filterHobby, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // SORT
        allProjects = sortBy switch
        {
            "priority" => allProjects.OrderByDescending(p => p.Project.Priority).ToList(),
            "lastUpdated" => allProjects.OrderByDescending(p => p.Project.LastUpdated).ToList(),
            _ => allProjects
        };

        foreach (var entry in allProjects)
        {
            Console.WriteLine(
                $"[{entry.Hobby}] {entry.Project.Name} (Priority {entry.Project.Priority}, Updated: {entry.Project.LastUpdated})");
        }
    }
}