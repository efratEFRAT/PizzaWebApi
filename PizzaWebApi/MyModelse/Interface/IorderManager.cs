namespace MyModelse.Interface;
public interface IorderManager{
 void postOrdet(string orderName, int pizzaId, string addres);
 bool deleteOrder(string name);   
    


}