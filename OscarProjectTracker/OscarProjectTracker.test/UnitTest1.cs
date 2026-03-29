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

    //FR1.2 Manage Project Test
    
    //  FR1.2 Success Test    
    
    //  FR1.2 Failure Test
    
    //  FR1.2 Sanity Test


    //---------------
    //UC2: Record Progress
    //---------------

    //FR2.1 Add Progress Notes Test

    //  FR2.1 Success Test    
    
    //  FR2.1 Failure Test
    
    //  FR2.1 Sanity Test



    //FR2.2 Display Most Recent Progress Notes Test

    //  FR2.2 Success Test    
    
    //  FR2.2 Failure Test
    
    //  FR2.2 Sanity Test


    //---------------
    //UC3: Organize External Resources
    //---------------

    //FR3.1 attach or link external resources Test

    //  FR3.1 Success Test    
    
    //  FR3.1 Failure Test
    
    //  FR3.1 Sanity Test



    //FR3.2 organize resources using folders Test (not impemented as of V2.0.0)

    //  FR3.2 Success Test    
    
    //  FR3.2 Failure Test
    
    //  FR3.2 Sanity Test


    //---------------
    //UC4: View projects in a single dashboard
    //---------------

    //FR4.1 provide a dashboard listing all active projects Test

    //  FR4.1 Success Test    
    
    //  FR4.1 Failure Test
    
    //  FR4.1 Sanity Test



    //FR4.2 allow sorting and filtering by hobby, last updated date, or priority Test
    // (not implemented as of V2.0.0)

    //  FR4.2 Success Test    
    
    //  FR4.2 Failure Test
    
    //  FR4.2 Sanity Test


    //---------------
    //UC5: Set Reminders of goals for hobbies and projects
    //---------------

    //FR5.1 set reminders Test

    //  FR5.1 Success Test    
    
    //  FR5.1 Failure Test
    
    //  FR5.1 Sanity Test



    //FR5.2 notify user when a reminder is due Test

    //  FR5.2 Success Test    
    
    //  FR5.2 Failure Test
    
    //  FR5.2 Sanity Test



}
