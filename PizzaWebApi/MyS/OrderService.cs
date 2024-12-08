using MyModelse;
using MyModelse.Interface;
namespace MyS;
public class OrderService : IorderManager
{
    List<Order> o1 = new List<Order>();


    public void postOrdet(string orderName, int pizzaId, string addres)
    {
        Order o = new Order(orderName, pizzaId, addres);
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

    // public string orderName { get; set;}
    //     public int pizzaId {get; set;}
    //     public string addres { get; set;}
    //        public Order(string orderName,int pizzaId,string addres)
    //     {
    //         this.orderName=orderName;
    //         this.pizzaId=pizzaId;
    //         this.addres=addres;
    //     }

}
