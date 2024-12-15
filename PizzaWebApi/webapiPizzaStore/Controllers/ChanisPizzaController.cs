using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FireService;
using FireService.Interfaces;
using MyModelse;
using MyModelse.Interface;
namespace webapiPizzaStore.Controllers;
public class ChanisPizzaController :BaceController
{
       IpizzaMannager _chanisPizza;
      
      public ChanisPizzaController(IpizzaMannager pizza)
      {
        _chanisPizza=pizza;   
      }

      [Route("[action]")]
      [HttpGet]
      public IActionResult getPizzaList()
      {
            var p1 = _chanisPizza.getPizzaList();
            if (p1 != null)
                  Ok(p1);
            return NotFound("pizza list!!!!");
      }


      [Route("[action]/{id}")]
      [HttpGet]
      public IActionResult getPizza(int id)
      {
            var p1 =_chanisPizza.getPizza(id);
            if (p1 != null)
                  return Ok(p1);
            return NotFound("pizza list!!!!");

      }

      [Route("~/[controller]/getPizzaByName/{name}")]
      [HttpGet]
      public IActionResult getPizzaByName(string name)
      {

          var p1 =_chanisPizza.getPizzaByName (name);
            if (p1 != null)
                  return Ok(p1);

            return NotFound("there is no pizza with this name!!!!");
      }

      [Route("[action]/{name}/{id}/{ifGloten}")]
      [HttpPost]
      public void setPizza(string name, int id, bool ifGloten)
      {
         _chanisPizza.setPizza(name,id,ifGloten);
          
      }

      [Route("[action]/{id}")]
      [HttpDelete]
      public IActionResult deletePizza(int id)
      {
            bool p1 =_chanisPizza.deletePizza (id);
                if(p1)
                        return Ok();
            

            return NotFound("there is no pizza with this id!!!!");
      }


      [Route("[action]/{id}/{ifGloten}")]
      [HttpPut]
      public IActionResult updatePizza(int id, bool ifGloten)
      {

       
              bool p1 =_chanisPizza.updatePizza (id,ifGloten);
                  if (p1)
                  {
                       
                        return Ok("we update!!!");
                  }
          

            return NotFound("there is no pizza with this id!!!!");
      }
}

