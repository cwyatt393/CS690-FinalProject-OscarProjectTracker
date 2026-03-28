namespace OscarProjectTracker;

public class Reminder
{
    public DateTime DueDate { get; set; }
    public string Message { get; set; }

    public Reminder(DateTime dueDate, string message)
    {
        DueDate = dueDate;
        Message = message;
    }

    public override string ToString() =>
        $"Reminder due {DueDate.ToShortDateString()}: {Message}";
}