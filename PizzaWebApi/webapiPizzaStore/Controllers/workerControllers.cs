using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using MyModelse.Interface;
using MyModelse;
namespace webapiPizzaStore.Controllers;
public class WorkerController : BaceController
{
    IworkerManager _worker;

    public WorkerController(IworkerManager worker)
    {
         _worker=worker;
    }
    [Route("[action]/{name}/{id}/{password}/{role}")]
    [HttpPost]
    [Authorize(Policy = "superWorker")]
    public void Writeworker(string name,int id,int password ,string  role)
    {
        _worker.postworker(name,id,password,role);
    }

     [Route("[action]/{name}/{id}/{password}/{role}")]
     [HttpPut]
   
     public IActionResult ChangeNameworker(string name,int id,int password,string role)
    {

        if (_worker.putworker(name,id,password,role) == true)
        {
            return Ok("Name change successful.");

        }
        else
        {
            return NotFound("The worker could not be found or updated.");
        }

    }
}