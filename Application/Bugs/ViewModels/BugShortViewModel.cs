using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.Bugs.ViewModels;

public class BugShortViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}