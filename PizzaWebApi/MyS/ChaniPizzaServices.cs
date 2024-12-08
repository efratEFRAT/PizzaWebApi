using MyModelse;
using MyModelse.Interface;
using FireService;
using FireService.Interfaces;
namespace MyS;
public class ChanisPizzaServices:IpizzaMannager
{
    IFireService<ChanisPizza> _Ifile;
      // string path=@"L:\webAPI\הגשות\lesson6\תמי שיקוביצקי ואפרת מרקוביץ\PizzaWebApi\PizzaWebApi/file.json";

      // public ChanisPizzaServices(IFireService<ChanisPizza> Ifile){
      //       _Ifile = Ifile;
            
      // }
    List<ChanisPizza> p1=new List<ChanisPizza>()
    {
        new ChanisPizza("pizzaShemesh",1,true),
        new ChanisPizza("pizzaHot",2,false),
        new ChanisPizza("pizzaStory",3,true),
        new ChanisPizza("Shamenet",4,true)
    };
    public List<ChanisPizza> getPizzaList(){
      //    if(p1!=null)
      //     return p1;
      //     return null;
     List<ChanisPizza> p2 =  _Ifile.Read();
     if (p2!=null)
     {
      return p2;
     }
     return null;
    } 
    public ChanisPizza getPizza(int id){
      List<ChanisPizza> p3 =  _Ifile.Read();
      foreach (var i in p3)
            {
                if(i.pizzaId==id)
                  return i;
            }
            return null;
    }
    public ChanisPizza getPizzaByName(string name){
    List<ChanisPizza> p4 =  _Ifile.Read();
     foreach (var i in p4)
            {
                 if(i.pizzaName.Equals( name))
                  return i;
            }
            return null;
    }
    public void setPizza(string name,int id,bool ifGloten){
    ChanisPizza c1 = new ChanisPizza (name, id, ifGloten);
    _Ifile.Write(c1);
        
            
    }
public bool  deletePizza(int id){
      foreach (var i in p1)
            {
                  if (i.pizzaId == id)
                  {
                        p1.Remove(i);
                        return true;
                  }
            }

            return false;
}
 public bool updatePizza(int id, bool ifGloten)
      {

            foreach (var i in p1)
            {
                  if (i.pizzaId == id)
                  {
                        i.ifGloten = ifGloten;
                        return true;
                  }
            }

            return false;
      }


}
