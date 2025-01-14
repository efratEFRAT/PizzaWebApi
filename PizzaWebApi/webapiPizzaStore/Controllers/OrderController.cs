using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using MyModelse.Interface;
using MyModelse;
namespace webapiPizzaStore.Controllers;
public class OrderController : BaceController
{
    private readonly IorderManager _Order;
    

    public OrderController(IorderManager order)
    {
        _Order = order;
    }
    public void PostOrdet(string orderName, int pizzaId, string addres, int num, int threeDig, string date)
    {
        _Order.postOrdet(orderName, pizzaId, addres, num, threeDig, date);
    }

    [Route("[action]")]
    [HttpDelete]
    public IActionResult deleteOrder(string name)
    {

        if (_Order.deleteOrder(name) == true)
        {
            return Ok("jtfd");
        }
        else
        {
            return NotFound();
        }

    }
[Route("[action]")]
[HttpPost]
public async Task<IActionResult> PlaceOrderAsync(string orderName, int pizzaId, string address, int num, int threeDig, string date)
{
    // יצירת אובייקט הזמנה
    Order order1 = new Order(orderName, pizzaId, address, num, threeDig, date);

 


    if(result)
    {
        return Ok("Order processed successfully.");
    }
    else
    {
        return BadRequest("Order failed.");
    }
}
}

