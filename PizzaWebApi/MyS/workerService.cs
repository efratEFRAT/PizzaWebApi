using MyModelse;
using MyModelse.Interface;

using FireService;
using FireService.Interfaces;
namespace MyS;
public class workerService : IworkerManager
{

    IFireService<Worker>  _workFile;
    public workerService(IFireService<Worker> workFile)
    {
        _workFile = workFile;

    }
    List<Worker> W1 = new List<Worker>();
    public void postworker(string name,int id,int  password,string  role)
    {
        Worker W = new Worker(name, id,password,role);
        _workFile.Write(W);
    }
    public bool putworker(string name,int id,int  password,string  role)
    {
        foreach (var i in W1)
        {
            if (i.id == id)
            {
                i.name = name;
                return true;
            }

        }
        return false;
    }
    public  List<Worker> readWorker(){
        var ListWorker= _workFile.Read();
        return ListWorker;
    }

}
