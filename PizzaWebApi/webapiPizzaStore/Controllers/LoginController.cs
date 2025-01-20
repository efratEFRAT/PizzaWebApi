 using System;
 using System.Diagnostics;
 using System.Linq;
 using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyS;
using MyModelse;
using Login;
namespace webapiPizzaStore.Controllers;
    [Route("[controller]")]
public class LoginController: BaceController {


 Ilogin _identety;
 private readonly ILogger<LoginController> _logger;
public LoginController ( Ilogin identety,ILogger<LoginController> logger){
     _identety=  identety;
     _logger=logger;
}

[HttpPost]
[Route("[action]/{name}/{password}")]
public IActionResult Login(string name,int password){

   Worker w=_identety.IsExist(name,password);
   if(w==null){
    return Unauthorized("you not exsist");
   }
   var claims=new List<Claim>
   {
    new Claim("role",w.role),
   };
 
var token=LoginToken.GetToken(claims);
return new OkObjectResult(LoginToken.WriteToken(token));
}
   

}
