namespace OscarProjectTracker;

using System;
using System.Collections.Generic;

class Program
{
    static List<Hobby> hobbies = new List<Hobby>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Hobby Tracker ===");
            Console.WriteLine("1. Add Hobby");
            Console.WriteLine("2. Manage Projects");
            Console.WriteLine("3. Add Progress Notes");
            Console.WriteLine("4. View All Hobbies & Projects");
            Console.WriteLine("5. Exit");
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

        hobbies.Add(new Hobby(name));
        Console.WriteLine("Hobby added!");
    }

    // -----------------------------
    // FR-1.2: Create/Edit/Delete Projects
    // -----------------------------
    static void ManageProjects()
    {
        Hobby hobby = SelectHobby();
        if (hobby == null) return;

        Console.WriteLine($"\nManaging projects for: {hobby.Name}");
        Console.WriteLine("1. Add Project");
        Console.WriteLine("2. Edit Project");
        Console.WriteLine("3. Delete Project");
        Console.Write("Choose an option: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter project name: ");
                hobby.Projects.Add(new Project(Console.ReadLine()));
                Console.WriteLine("Project added!");
                break;

            case "2":
                Project pEdit = SelectProject(hobby);
                if (pEdit == null) return;

                Console.Write("Enter new project name: ");
                pEdit.Name = Console.ReadLine();
                Console.WriteLine("Project updated!");
                break;

            case "3":
                Project pDelete = SelectProject(hobby);
                if (pDelete == null) return;

                hobby.Projects.Remove(pDelete);
                Console.WriteLine("Project deleted!");
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    // -----------------------------
    // FR-2.1: Add Progress Notes
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
        Console.WriteLine("Progress note added!");
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
                Console.WriteLine($"  Project: {project.Name}");

                if (project.ProgressNotes.Count == 0)
                {
                    Console.WriteLine("    No progress notes.");
                }
                else
                {
                    Console.WriteLine("    Progress Notes:");
                    foreach (var note in project.ProgressNotes)
                    {
                        Console.WriteLine($"     - {note}");
                    }
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

// -----------------------------
// Data Models
// -----------------------------
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
