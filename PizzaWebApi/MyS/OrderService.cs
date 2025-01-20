using MyModelse;
using MyModelse.Interface;

using FireService;
using FireService.Interfaces;
namespace MyS;
public class OrderService : IorderManager
{
    IFireService<Order> _fileBill;
    public OrderService(IFireService<Order> fileBill)
    {
        _fileBill = fileBill;

    }
    List<Order> o1 = new List<Order>()
    {

    };

    public void postOrdet(string orderName, int pizzaId, string addres, int num, int threeDig, string date)
    {
        Order o = new Order(orderName, pizzaId, addres, num, threeDig, date);
        o1.Add(o);
    }
    public bool deleteOrder(string name)
    {
        foreach (var i in o1)
        {
            if (i.orderName == name)
            {
                o1.Remove(i);
                return true;
            }

        }
        return false;
    }
    public async Task<bool> payPostAsync(Visa myVisa)
    {
        Console.WriteLine("Processing payment...");
        await Task.Delay(5000);
        Console.WriteLine("finish pay");
        return true;
    }
    public async Task PreparePizzaAsync()
    {
        Console.WriteLine("Processing preparing the pizza...");
        await Task.Delay(15000);
        Console.WriteLine("finish pizza");
    }


    public async Task BillAsync(Order order)
    {

        _fileBill.Write(order);
    }
    public async Task<bool> ProcessOrderAsync(Order order)
    {

        bool paymentSuccessful = await payPostAsync(order.myVisa);
        if (!paymentSuccessful)
        {
            return false;
        }


        await PreparePizzaAsync();


        await BillAsync(order);

        return true;
    }

}


