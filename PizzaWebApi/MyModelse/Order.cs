using MyModelse.Interface;

namespace MyModelse;
public class Order
{
    public string orderName { get; set; }
    public int pizzaId { get; set; }
    public string addres { get; set; }
    public Visa myVisa { get; set; }    
  public Order(string orderName, int pizzaId, string addres,int num, int threeDig, string date )
    {
        this.orderName = orderName;
        this.pizzaId = pizzaId;
        this.addres = addres;
       this.myVisa=new Visa(num,threeDig,date); 
    }

}