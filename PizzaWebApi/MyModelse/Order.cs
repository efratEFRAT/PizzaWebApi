namespace MyModelse;

public class Order
{
    public string orderName { get; set;}
        public int pizzaId {get; set;}
        public string addres { get; set;}
           public Order(string orderName,int pizzaId,string addres)
        {
            this.orderName=orderName;
            this.pizzaId=pizzaId;
            this.addres=addres;
        }

}