namespace Application.Orders.ViewModels;

public class OrderViewModel
{
    public Guid Id { get;  set; }
    public string Title { get;  set; }
    public string? Description { get;  set; }
    public DateTime CreatedAt { get;  set; }
    public DateTime? OrderDelivered { get;  set; }
    public Guid ResponsibleUserId { get;  set; }
    public List<OrderedItemViewModel> OrderItems { get; set; }
}