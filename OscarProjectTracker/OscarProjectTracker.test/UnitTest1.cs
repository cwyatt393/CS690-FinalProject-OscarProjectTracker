namespace OscarProjectTracker.test;

using Xunit;
using OscarProjectTracker;
using System.Collections.Generic;
using System.Linq;

public class UnitTest1
{
    //---------------
    //UC1: Track Hobby Projects
    //---------------

    //FR1.1 Add Hobby Test
    
    //  FR1.1 Success Test    
    [Fact]
    public void Test_AddHobby_ReturnsTrue()
    {
        // Arrange
        var hobbies = new List<Hobby>();
        string hobbyName = "Painting";

        // Act
        hobbies.Add(new Hobby(hobbyName));

        // Bool check: did the hobby get added?
        bool wasAdded = hobbies.Any(h => h.Name == hobbyName);

        // Assert
        Assert.True(wasAdded);
    }

    //FR    1.1 Failure Test
    [Fact]
    public void Test_AddHobby_Fails_WhenNameIsEmpty()
    {
        // Arrange
        var hobbies = new List<Hobby>();
        string hobbyName = "";   // invalid name

        // Act
        if (!string.IsNullOrWhiteSpace(hobbyName))
        {
            hobbies.Add(new Hobby(hobbyName));
        }

        // Bool check: hobby should NOT be added
        bool wasAdded = hobbies.Any(h => h.Name == hobbyName);

        // Assert
        Assert.False(wasAdded);
    }

    //  FR1.1 Sanity Test
    [Fact]
    public void Test_AddHobby_SanityCheck()
    {
        // Arrange
        var hobbies = new List<Hobby>();
        string hobbyName = "Painting";

        // Act
        hobbies.Add(new Hobby(hobbyName));

        // Bool check: hobby should be present
        bool wasAdded = hobbies.Any(h => h.Name == hobbyName);

        // Assert
        Assert.True(wasAdded);
    }

    //FR1.2 Add Project Test
    
    //  FR1.2 Success Test
    [Fact]
    public void Test_AddProject_Success()
    {
        // Arrange
        var hobby = new Hobby("Guitar");
        string projectName = "Practice Chords";

        // Act
        hobby.Projects.Add(new Project(projectName));

        // Bool check: project should be present
        bool wasAdded = hobby.Projects.Any(p => p.Name == projectName);

        // Assert
        Assert.True(wasAdded);
    }   
    
    //  FR1.2 Failure Test
    [Fact]
    public void Test_AddProject_Fails_WhenNameIsEmpty()
    {
        // Arrange
        var hobby = new Hobby("Guitar");
        string projectName = "";   // invalid project name

        // Act
        if (!string.IsNullOrWhiteSpace(projectName))
        {
            hobby.Projects.Add(new Project(projectName));
        }

        // Bool check: project should NOT be added
        bool wasAdded = hobby.Projects.Any(p => p.Name == projectName);

        // Assert
        Assert.False(wasAdded);
    }
    
    //  FR1.2 Sanity Test
    [Fact]
    public void Test_AddProject_SanityCheck()
    {
        // Arrange
        var hobby = new Hobby("Guitar");
        string projectName = "Practice Scales";

        // Act
        hobby.Projects.Add(new Project(projectName));

        // Bool check: project should be present
        bool wasAdded = hobby.Projects.Any(p => p.Name == projectName);

        // Assert
        Assert.True(wasAdded);
    }

    //---------------
    //UC2: Record Progress
    //---------------

    //FR2.1 Add Progress Notes Test

    //  FR2.1 Success Test
    [Fact]
    public void Test_AddProgressNote_Success()
    {
        // Arrange
        var project = new Project("Learn C#");
        string note = "Completed Chapter 1";

        // Act
        project.ProgressNotes.Add(note);

        // Bool check: note should be present
        bool wasAdded = project.ProgressNotes.Contains(note);

        // Assert
        Assert.True(wasAdded);
    }    
    
    //  FR2.1 Failure Test
    [Fact]
    public void Test_AddProgressNote_Fails_WhenNoteIsEmpty()
    {
        // Arrange
        var project = new Project("Learn C#");
        string note = "";   // invalid note

        // Act
        if (!string.IsNullOrWhiteSpace(note))
        {
            project.ProgressNotes.Add(note);
        }

        // Bool check: note should NOT be added
        bool wasAdded = project.ProgressNotes.Contains(note);

        // Assert
        Assert.False(wasAdded);
    }

    //  FR2.1 Sanity Test
    [Fact]
    public void Test_AddProgressNote_SanityCheck()
    {
        // Arrange
        var project = new Project("Learn C#");
        string note = "Finished lesson 1";

        // Act
        project.ProgressNotes.Add(note);

        // Bool check: note should be present
        bool wasAdded = project.ProgressNotes.Contains(note);

        // Assert
        Assert.True(wasAdded);
    }



    //FR2.2 Display Most Recent Progress Notes Test

    //  FR2.2 Success Test
    [Fact]
    public void Test_MostRecentProgressUpdate_Success()
    {
        // Arrange
        var project = new Project("Learn C#");

        string firstNote = "Finished lesson 1";
        string secondNote = "Finished lesson 2"; // this should become the most recent

        // Act
        project.ProgressNotes.Add(firstNote);
        project.ProgressNotes.Add(secondNote);

        // Bool check: most recent note should match the last one added
        bool isMostRecentCorrect = project.ProgressNotes.Last() == secondNote;

        // Assert
        Assert.True(isMostRecentCorrect);
    }    
    
    //  FR2.2 Failure Test
    [Fact]
    public void Test_MostRecentProgressUpdate_Fails_WhenNoNotesExist()
    {
        // Arrange
        var project = new Project("Learn C#");

        // Act
        // No notes added

        // Bool check: there should NOT be a most recent note
        bool hasMostRecent = project.ProgressNotes.Any();

        // Assert
        Assert.False(hasMostRecent);
    }
    
    //  FR2.2 Sanity Test
    [Fact]
    public void Test_MostRecentProgressUpdate_SanityCheck()
    {
        // Arrange
        var project = new Project("Learn C#");
        string note = "Finished lesson 1";

        // Act
        project.ProgressNotes.Add(note);

        // Bool check: the most recent note should match the one added
        bool isMostRecentCorrect = project.ProgressNotes.Last() == note;

        // Assert
        Assert.True(isMostRecentCorrect);
    }


    //---------------
    //UC3: Organize External Resources
    //---------------

    //FR3.1 attach or link external resources Test

    //  FR3.1 Success Test
    [Fact]
    public void Test_AddResource_Success()
    {
        // Arrange
        var project = new Project("Oil Painting");
        var resource = new Resource("Color Guide", "https://example.com/colors");

        // Act
        project.Resources.Add(resource);

        // Bool check: resource should be present
        bool wasAdded = project.Resources.Any(r => r.Label == "Color Guide");

        // Assert
        Assert.True(wasAdded);
    }    
    
    //  FR3.1 Failure Test
    [Fact]
    public void Test_AddResource_Fails_WhenLabelIsEmpty()
    {
        // Arrange
        var project = new Project("Oil Painting");
        string label = "";   // invalid label
        string url = "https://example.com/colors";

        // Act
        if (!string.IsNullOrWhiteSpace(label))
        {
            project.Resources.Add(new Resource(label, url));
        }

        // Bool check: resource should NOT be added
        bool wasAdded = project.Resources.Any(r => r.Label == label);

        // Assert
        Assert.False(wasAdded);
    }
    
    //  FR3.1 Sanity Test
    [Fact]
    public void Test_AddResource_SanityCheck()
    {
        // Arrange
        var project = new Project("Oil Painting");
        var resource = new Resource("Brush Guide", "https://example.com/brushes");

        // Act
        project.Resources.Add(resource);

        // Bool check: resource should be present
        bool wasAdded = project.Resources.Any(r => r.Label == "Brush Guide");

        // Assert
        Assert.True(wasAdded);
    }



    //FR3.2 organize resources using folders Test (not impemented as of V2.0.0)

    //  FR3.2 Success Test    
    
    //  FR3.2 Failure Test
    
    //  FR3.2 Sanity Test


    //---------------
    //UC4: View projects in a single dashboard
    //---------------

    //FR4.1 provide a dashboard listing all active projects Test

    //  FR4.1 success test
    [Fact]
    public void Test_DashboardSummary_Success()
    {
        // Arrange
        var hobby = new Hobby("Guitar");
        hobby.Projects.Add(new Project("Practice Scales"));
        var hobbies = new List<Hobby> { hobby };

        // Act
        Dashboard.Show(hobbies);

        bool result = true; // If no exception is thrown, success

        // Assert
        Assert.True(result);
    }

    //  FR4.1 failure test
    [Fact]
    public void Test_DashboardSummary_Failure_WhenHobbyListIsNull()
    {
        // Arrange
        List<Hobby> hobbies = null;

        bool result = false;

        // Act
        try
        {
            Dashboard.Show(hobbies);
            result = true; // If it somehow doesn't throw, that's a failure
        }
        catch
        {
            result = false; // Expected behavior: null list should fail
        }

        // Assert
        Assert.False(result);
    }

    //  FR4.1 sanity test
    [Fact]
    public void Test_DashboardSummary_SanityCheck()
    {
        // Arrange
        var hobby = new Hobby("Piano");
        hobby.Projects.Add(new Project("Chord Drills"));
        var hobbies = new List<Hobby> { hobby };

        // Act
        Dashboard.Show(hobbies);

        bool result = true; // If it runs normally, sanity passes

        // Assert
        Assert.True(result);
    }


    //FR4.2 allow sorting and filtering by hobby, last updated date, or priority Test
    // (not implemented as of V2.0.0)

    //  FR4.2 Success Test    
    
    //  FR4.2 Failure Test
    
    //  FR4.2 Sanity Test


    //---------------
    //UC5: Set Reminders of goals for hobbies and projects
    //---------------

    //FR5.1 set reminders Test

    //  FR5.1 success test
    [Fact]
    public void Test_AddReminder_Success()
    {
        // Arrange
        var project = new Project("Guitar Practice");
        var reminder = new Reminder(DateTime.Now.AddDays(1), "Practice scales");

        // Act
        project.Reminder = reminder;

        bool result = project.Reminder == reminder;

        // Assert
        Assert.True(result);
    }

    //  FR5.1 failure test
    [Fact]
    public void Test_AddReminder_Failure_WhenReminderIsNull()
    {
        // Arrange
        var project = new Project("Guitar Practice");

        // Act
        project.Reminder = null;

        bool result = project.Reminder == null;

        // Assert
        Assert.True(result);
    }

    //  FR5.1 sanity test
    [Fact]
    public void Test_AddReminder_SanityCheck()
    {
        // Arrange
        var project = new Project("Guitar Practice");
        var reminder = new Reminder(DateTime.Now.AddDays(2), "Warm-up exercises");

        // Act
        project.Reminder = reminder;

        bool result = project.Reminder != null;

        // Assert
        Assert.True(result);
    }


    //FR5.2 notify user when a reminder is due Test

    //  FR5.2 Success Test    
    
    //  FR5.2 Failure Test
    
    //  FR5.2 Sanity Test



}
