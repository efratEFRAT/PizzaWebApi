using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using MyModelse.Interface;
namespace webapiPizzaStore.Controllers;
public class OrderController : BaceController
{
    IorderManager _Order;

    public OrderController(IorderManager order)
    {
        _Order = order;
    }
    [Route("[action]")]
    [HttpPost]
    public void postOrdet(string orderName, int pizzaId, string addres)
    {
        _Order.postOrdet(orderName, pizzaId, addres);
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
}