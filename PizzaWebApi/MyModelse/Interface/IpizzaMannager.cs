namespace MyModelse.Interface{
public interface IpizzaMannager{
    List<ChanisPizza> getPizzaList();
    ChanisPizza getPizza(int id);
    ChanisPizza getPizzaByName(string name);
    void setPizza(string name,int id,bool ifGloten);
    bool deletePizza(int id);
    bool updatePizza(int id, bool ifGloten);

    

}
}