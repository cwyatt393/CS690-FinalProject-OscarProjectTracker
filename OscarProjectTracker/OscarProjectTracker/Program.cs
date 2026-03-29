namespace OscarProjectTracker;

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Hobby> hobbies = DataStore.Load();

    static void Main()
    {
        // Check reminders on startup
        CheckReminders();

        bool running = true;

        while (running)
        {
            ReminderChecker.Check(hobbies);

            Console.WriteLine("1. Add Hobby");
            Console.WriteLine("2. Manage Projects");
            Console.WriteLine("3. Add Progress Notes");
            Console.WriteLine("4. View All Hobbies & Projects");
            Console.WriteLine("5. Add Resource to Project");
            Console.WriteLine("6. View Dashboard");
            Console.WriteLine("7. Set Reminder");
            Console.WriteLine("8. View Resources by Tag");   // NEW
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddHobby();
                    break;

                case "2":
                    ManageProjects();
                    break;

                case "3":
                    AddProgressNotes();
                    break;

                case "4":
                    ViewAll();
                    break;

                case "5":
                    AddResource();
                    break;

                case "6":
                    ShowDashboard();
                    break;

                case "7":
                    SetReminder();
                    break;

                case "8":
                    ViewResourcesByTag();
                    break;

                case "9":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    // -----------------------------
    // FR-1.1: Add Hobby
    // -----------------------------
    static void AddHobby()
    {
        Console.Write("Enter hobby name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Hobby name cannot be empty.");
            return;
        }

        hobbies.Add(new Hobby(name));
        DataStore.Save(hobbies);

        Console.WriteLine("Hobby added!");
    }

    // -----------------------------
    // FR-1.2: Manage Projects
    // -----------------------------
    static void ManageProjects()
    {
        Hobby hobby = SelectHobby();
        if (hobby == null) return;

        Console.WriteLine($"\nManaging projects for: {hobby.Name}");
        Console.WriteLine("1. Add Project");
        Console.WriteLine("2. Edit Project");
        Console.WriteLine("3. Delete Project");
        Console.WriteLine("4. Set Project Priority");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter project name: ");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Project name cannot be empty.");
                    return;
                }

                hobby.Projects.Add(new Project(name));
                DataStore.Save(hobbies);

                Console.WriteLine("Project added!");
                break;

            case "2":
                Project pEdit = SelectProject(hobby);
                if (pEdit == null) return;

                Console.Write("Enter new project name: ");
                pEdit.Name = Console.ReadLine();
                pEdit.LastUpdated = DateTime.Now;

                DataStore.Save(hobbies);
                Console.WriteLine("Project updated!");
                break;

            case "3":
                Project pDelete = SelectProject(hobby);
                if (pDelete == null) return;

                hobby.Projects.Remove(pDelete);
                DataStore.Save(hobbies);

                Console.WriteLine("Project deleted!");
                break;

            case "4":
                Project pPriority = SelectProject(hobby);
                if (pPriority == null) return;

                Console.WriteLine("Set priority: 1 = Low, 2 = Medium, 3 = High");
                Console.Write("Enter priority (1-3): ");
                string priorityInput = Console.ReadLine();

                if (int.TryParse(priorityInput, out int priority) &&
                    priority >= 1 && priority <= 3)
                {
                    pPriority.Priority = priority;
                    pPriority.LastUpdated = DateTime.Now;
                    DataStore.Save(hobbies);
                    Console.WriteLine("Priority updated!");
                }
                else
                {
                    Console.WriteLine("Invalid priority.");
                }
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    // -----------------------------
    // FR-2.1: Add Progress Notes
    // FR-2.2: Show most recent update
    // -----------------------------
    static void AddProgressNotes()
    {
        Hobby hobby = SelectHobby();
        if (hobby == null) return;

        Project project = SelectProject(hobby);
        if (project == null) return;

        Console.Write("Enter progress note: ");
        string note = Console.ReadLine();

        project.ProgressNotes.Add(note);
        project.LastUpdated = DateTime.Now;

        DataStore.Save(hobbies);
        Console.WriteLine("Progress note added!");
    }

    // -----------------------------
    // FR-3.1: Add Resource to Project
    // FR-3.2: Organize Resources with Tags
    // -----------------------------

    static void AddResource()
    {
        Hobby hobby = SelectHobby();
        if (hobby == null) return;

        Project project = SelectProject(hobby);
        if (project == null) return;

        Console.Write("Enter resource label: ");
        string label = Console.ReadLine();

        Console.Write("Enter URL or file path: ");
        string url = Console.ReadLine();

        Console.Write("Enter a tag/folder name (optional): ");
        string tag = Console.ReadLine();

        project.Resources.Add(new Resource(label, url, tag));
        project.LastUpdated = DateTime.Now;

        DataStore.Save(hobbies);
        Console.WriteLine("Resource added!");
    }

    // ViewResourceByTag
    static void ViewResourcesByTag()
    {
        Console.Write("Enter tag/folder name to search: ");
        string tag = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(tag))
        {
            Console.WriteLine("Tag cannot be empty.");
            return;
        }

        var matches = new List<(Hobby Hobby, Project Project, Resource Resource)>();

        foreach (var hobby in hobbies)
        {
            foreach (var project in hobby.Projects)
            {
                foreach (var resource in project.Resources)
                {
                    if (!string.IsNullOrWhiteSpace(resource.Tag) &&
                        resource.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase))
                    {
                        matches.Add((hobby, project, resource));
                    }
                }
            }
        }

        if (matches.Count == 0)
        {
            Console.WriteLine($"No resources found with tag '{tag}'.");
            return;
        }

        Console.WriteLine($"\nResources with tag '{tag}':");
        foreach (var match in matches)
        {
            Console.WriteLine($"[{match.Hobby.Name}] {match.Project.Name} -> {match.Resource}");
        }
    }


    // -----------------------------
    // FR-4.1: Dashboard
    // FR-4.2: Sorting/Filtering Dashboard
    // -----------------------------

    static void ShowDashboard()
    {
        Console.WriteLine("\nDashboard Options:");
        Console.WriteLine("1. Sort by Last Updated");
        Console.WriteLine("2. Sort by Priority");
        Console.WriteLine("3. Filter by Hobby");
        Console.Write("Choose an option: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Dashboard.Show(hobbies, sortBy: "lastUpdated");
                break;

            case "2":
                Dashboard.Show(hobbies, sortBy: "priority");
                break;

            case "3":
                Console.Write("Enter hobby name to filter: ");
                string hobbyName = Console.ReadLine();
                Dashboard.Show(hobbies, filterHobby: hobbyName);
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    // -----------------------------
    // FR-5.1: Set Reminder
    // -----------------------------
    static void SetReminder()
    {
        Hobby hobby = SelectHobby();
        if (hobby == null) return;

        Project project = SelectProject(hobby);
        if (project == null) return;

        Console.Write("Enter reminder message: ");
        string msg = Console.ReadLine();

        Console.Write("Enter due date (YYYY-MM-DD): ");
        DateTime due = DateTime.Parse(Console.ReadLine());

        project.Reminder = new Reminder(due, msg);
        DataStore.Save(hobbies);

        Console.WriteLine("Reminder set!");
    }

    // -----------------------------
    // FR-5.2: Notify When Reminder is Due
    // -----------------------------
    static void CheckReminders()
    {
        foreach (var hobby in hobbies)
        {
            foreach (var project in hobby.Projects)
            {
                if (project.Reminder != null &&
                    project.Reminder.DueDate <= DateTime.Now)
                {
                    Console.WriteLine($"\n⚠ REMINDER: {project.Name} — {project.Reminder.Message}");
                }
            }
        }
    }

    // -----------------------------
    // View All
    // -----------------------------
    static void ViewAll()
    {
        if (hobbies.Count == 0)
        {
            Console.WriteLine("No hobbies found.");
            return;
        }

        foreach (var hobby in hobbies)
        {
            Console.WriteLine($"\nHobby: {hobby.Name}");

            if (hobby.Projects.Count == 0)
            {
                Console.WriteLine("  No projects yet.");
                continue;
            }

            foreach (var project in hobby.Projects)
            {
                Console.WriteLine($"  Project: {project.Name} (Priority {project.Priority})");

                if (project.ProgressNotes.Count > 0)
                {
                    Console.WriteLine($"    Most Recent: {project.ProgressNotes.Last()}");
                }

                if (project.Resources.Count > 0)
                {
                    Console.WriteLine("    Resources:");
                    foreach (var r in project.Resources)
                        Console.WriteLine($"     - {r}");
                }

                if (project.Reminder != null)
                {
                    Console.WriteLine($"    Reminder: {project.Reminder}");
                }
            }
        }
    }

    // -----------------------------
    // Helper: Select Hobby
    // -----------------------------
    static Hobby SelectHobby()
    {
        if (hobbies.Count == 0)
        {
            Console.WriteLine("No hobbies available.");
            return null;
        }

        Console.WriteLine("\nSelect a hobby:");
        for (int i = 0; i < hobbies.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {hobbies[i].Name}");
        }

        Console.Write("Enter number: ");
        if (int.TryParse(Console.ReadLine(), out int index) &&
            index >= 1 && index <= hobbies.Count)
        {
            return hobbies[index - 1];
        }

        Console.WriteLine("Invalid selection.");
        return null;
    }

    // -----------------------------
    // Helper: Select Project
    // -----------------------------
    static Project SelectProject(Hobby hobby)
    {
        if (hobby.Projects.Count == 0)
        {
            Console.WriteLine("No projects available.");
            return null;
        }

        Console.WriteLine("\nSelect a project:");
        for (int i = 0; i < hobby.Projects.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {hobby.Projects[i].Name}");
        }

        Console.Write("Enter number: ");
        if (int.TryParse(Console.ReadLine(), out int index) &&
            index >= 1 && index <= hobby.Projects.Count)
        {
            return hobby.Projects[index - 1];
        }

        Console.WriteLine("Invalid selection.");
        return null;
    }
}