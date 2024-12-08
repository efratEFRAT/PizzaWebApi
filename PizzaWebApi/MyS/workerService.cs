using MyModelse;
using MyModelse.Interface;
namespace MyS;
public class workerService : IworkerManager
{
    List<Worker> W1 = new List<Worker>();
    public void postworker(string name, int id)
    {
        Worker W = new Worker(name,id);
        W1.Add(W);
    }
    public bool putworker(string name, int id)
    {
        foreach (var i in W1)
        {
            if (i.id == id)
            {
                i.name=name;
                return true;
            }

        }
        return false;
    }


}
