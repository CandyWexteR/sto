namespace Core.Models.Tickets;

public class Ticket
{
    public Ticket(Guid id, Guid vehicleId, TicketState ticketState, ulong cost)
    {
        Id = id;
        VehicleId = vehicleId;
        TicketState = ticketState;
        Cost = cost;
    }
    public Guid Id { get; protected set; }
    public Guid VehicleId { get; protected set; }
    public TicketState TicketState { get; protected set; }
    public ulong Cost { get; protected set; }

    public static Ticket Create(Guid id, Guid vehicleId)
    {
        //TODO: Валидация
        return new Ticket(id, vehicleId, TicketState.Created, 0);
    }

    public void UpdateInfo(Guid vehicleId, TicketState state, ulong cost)
    {
        if (state == TicketState.Created)
            //TODO: message
            throw new Exception("");

        if (TicketState == TicketState.Closed)
            //TODO: message
            throw new Exception("");

        VehicleId = vehicleId;
        TicketState = state;
        Cost = cost;
    }
}