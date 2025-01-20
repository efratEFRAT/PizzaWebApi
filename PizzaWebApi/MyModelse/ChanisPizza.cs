// using System.ComponentModel.DataAnnotations;

namespace MyModelse;
public class ChanisPizza
{


        public string pizzaName { get; set; }

        public int pizzaId {get; set;}

        public bool ifGloten{ get; set; }
        public ChanisPizza(string pizzaName,int pizzaId,bool ifGloten)
        {
            this.pizzaName=pizzaName;
            this.pizzaId=pizzaId;
            this.ifGloten=ifGloten;
        }
}