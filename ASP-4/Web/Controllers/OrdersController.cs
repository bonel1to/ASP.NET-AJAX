using ASP4.Web.Models;
using Microsoft.AspNetCore.Mvc;
using ASP4.Application.Orders.CancelOrder;
using ASP4.Application.Orders.CreateOrder;
using ASP4.Application.Orders.GetOrder;

namespace ASP4.Web.Controllers;

public sealed class OrdersController(
    CreateOrderUseCase createOrder,
    GetOrderUseCase getOrder,
    CancelOrderUseCase cancelOrder) : Controller
{
    [HttpGet]
    public IActionResult Create() => View(new CreateOrderViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateOrderViewModel model, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(model);

        var command = new CreateOrderCommand(
            model.CustomerEmail,
            model.Items.Select(item => new CreateOrderItem(item.ProductId, item.Quantity)).ToList());

        var result = await createOrder.ExecuteAsync(command, ct);
        if (!result.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, result.Error!.Message);
            return View(model);
        }

        return RedirectToAction(nameof(Details), new { id = result.Value });
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid id, CancellationToken ct)
    {
        var result = await getOrder.ExecuteAsync(new GetOrderQuery(id), ct);
        if (!result.IsSuccess)
            return NotFound(result.Error!.Message);

        var order = result.Value!;
        return View(new OrderDetailsViewModel
        {
            Id = order.Id,
            CustomerEmail = order.CustomerEmail,
            Total = order.Total,
            Status = order.Status.ToString(),
            CreatedAtUtc = order.CreatedAtUtc,
            CanBeCancelled = order.Status != ASP4.Domain.OrderStatus.Shipped &&
                             order.Status != ASP4.Domain.OrderStatus.Cancelled,
            Items = order.Items
                .Select(item => new OrderItemViewModel
                {
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                })
                .ToList()
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(Guid id, CancellationToken ct)
    {
        var result = await cancelOrder.ExecuteAsync(new CancelOrderCommand(id), ct);
        if (!result.IsSuccess)
            return NotFound(result.Error!.Message);

        return RedirectToAction(nameof(Details), new { id });
    }
}
