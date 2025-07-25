using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSphere.Models;

namespace ShopSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemControllers : ControllerBase
    {
        private readonly OrderItemDBContext _OrderDBContext;
        public OrderItemControllers(OrderItemDBContext OrderDBContext)
        {
            _OrderDBContext = OrderDBContext;
        }
        [HttpGet("GetOrder")]
        public async Task<IActionResult> GetOrder()
        {
            try
            {
                var result = await (from order in _OrderDBContext.orders
                                    join item in _OrderDBContext.order_items
                                    on order.order_id equals item.order_id
                                    orderby order.order_id
                                    select new
                                    {
                                        order_id = order.order_id,
                                        state = item.state,
                                        product_name = item.product_name,
                                        quantity = item.quantity
                                    }).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetOrderID")]
        public async Task<IActionResult> GetOrderID(int Order_id)
        {
            try
            {
                if (Order_id == 0)
                {
                    return BadRequest("Please Enter Order Id ");
                }
                var result = await (from orders in _OrderDBContext.orders
                                    join item in _OrderDBContext.order_items
                                    on orders.order_id equals item.order_id
                                    where orders.order_id == Order_id
                                    select new
                                    {
                                        order_id = orders.order_id,
                                        state = item.state,
                                        product_name = item.product_name,
                                        quantity = item.quantity
                                    }).ToListAsync();

                if (result == null)
                {
                    return NotFound($"Order with ID {Order_id} not found.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] orders orders)
        {
            try
            {
                if (orders.order_id != 0)
                {
                    return BadRequest("Default value is 0 "!);
                }
                else
                {
                   
                        _OrderDBContext.orders.Add(orders);
                        await _OrderDBContext.SaveChangesAsync();
                        return Ok(orders);
                    
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        [HttpPost("CreateOrderItems")]
        public async Task<IActionResult> CreateOrderItems([FromBody] order_items order_items)
        {
            try
            {
                if (order_items.order_id == 0)
                {
                    return BadRequest(" Enter Order Id ");
                }
                else
                {
                    bool exists = await _OrderDBContext.orders
                       .AnyAsync(o => o.order_id == order_items.order_id);

                    if (exists)
                    {
                        _OrderDBContext.order_items.Add(order_items);
                        await _OrderDBContext.SaveChangesAsync();
                        return Ok(order_items);
                    }
                    else
                    {
                        return BadRequest("Can you please Create Order Request First !...");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        [HttpPut("UpdateOrderDetails")]
        public async Task<IActionResult> UpdateOrderDetails(int item_id, [FromBody] order_items order_items)
        {
            try
            {
                if(order_items.item_id!=0)
                {
                    return NotFound($" Please don't enter value in Item Id because it is Autoincrement Field !!!!!!");
                }

                var existingItem = await _OrderDBContext.order_items.FindAsync(item_id);

                if (existingItem == null || order_items.order_id == 0)
                {
                    return NotFound($" Please Enter Order Item ID AND Order Id ");
                }
                bool exists = await _OrderDBContext.orders
                      .AnyAsync(o => o.order_id == order_items.order_id);

                if (exists)
                {

                    existingItem.order_id = order_items.order_id;
                    existingItem.product_name = order_items.product_name;
                    existingItem.quantity = order_items.quantity;
                    existingItem.state = order_items.state;

                    await _OrderDBContext.SaveChangesAsync();

                    return Ok($"Record Updated !!!");

                }
                else
                {
                    return BadRequest("Can you please Create Order Request First !...");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteOrderItem")]
        public async Task<IActionResult> DeleteOrderItem(int orderItemId)
        {
            try
            {
                if (orderItemId == 0)
                {
                    return BadRequest("Please Enter Order Item Id ");
                }
                var Item = await _OrderDBContext.order_items.Where(x => x.item_id == orderItemId)
                    .ExecuteDeleteAsync();

                if (Item == 0)
                {
                    return NotFound($"Order Item ID {orderItemId} not found.");
                }

                return Ok($"Order Item ID {orderItemId} Deleted Successfully  !!.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
