namespace Application.Bugs.InputModels;

public class BugInputModel
{
    public Guid TicketId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}