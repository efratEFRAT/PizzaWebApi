

using MyModelse;
using MyModelse.Interface;
namespace MyModelse.Interface;
public interface IorderManager
{
    void postOrdet(string orderName, int pizzaId, string addres, int num, int threeDig, string date);
    bool deleteOrder(string name);
    Task<bool> payPostAsync(Visa myVisa);
    Task PreparePizzaAsync();
    Task BillAsync(Order order);
    Task<bool> ProcessOrderAsync(Order order);
}
