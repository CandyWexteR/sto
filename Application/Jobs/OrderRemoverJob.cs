using Core.Repositories;
using Quartz;

namespace Application.Jobs;

public class OrderRemoverJob : IJob
{
    private readonly IOrdersRepository _orders;
    private readonly IOrderItemsRepository _orderItems;
    private readonly IMarkedForRemoveOrdersRepository _toRemove;

    public OrderRemoverJob(IOrdersRepository orders, IOrderItemsRepository orderItems,
        IMarkedForRemoveOrdersRepository toRemove)
    {
        _orders = orders;
        _orderItems = orderItems;
        _toRemove = toRemove;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var items = 
            (await _toRemove.GetAllAsync())
            .OrderBy(v=>v.CreatedAt)
            .Take(10)
            .ToList();

        foreach (var item in items)
        {
            //TODO: message
            var order = await _orders.GetByIdAsync(item.Id) ?? throw new Exception();

            do
            {
                var toRemove = (await _orderItems.GetAllAsync()).Take(10).ToList();
                
                if (!toRemove.Any())
                    break;
                
                foreach (var orderItem in toRemove)
                {
                    await _orderItems.RemoveAsync(orderItem.Id);
                }
            } while (true);

            await _orders.RemoveAsync(item.Id);
        }
    }
}