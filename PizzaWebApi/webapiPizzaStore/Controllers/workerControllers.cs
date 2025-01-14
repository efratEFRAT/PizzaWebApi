using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using MyModelse.Interface;

namespace webapiPizzaStore.Controllers;
public class WorkerController : BaceController
{
    IworkerManager _worker;

    public WorkerController(IworkerManager worker)
    {
         _worker=worker;
    }
    [Route("[action]")]
    [HttpPost]
    public void postworker(string name, int id)
    {
        _worker.postworker(name,id);
    }

    [Route("[action]")]
    [HttpPut]
    public IActionResult putworker(string name,int id)
    {

        if (_worker.putworker(name,id) == true)
        {
            return Ok("GOOD");
        }
        else
        {
            return NotFound();
        }

    }
}