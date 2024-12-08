
using FireService.Interfaces;
using Newtonsoft.Json;
namespace FireService;

public class ReadWrite<T>:IFireService<T>
{
     private readonly string _path;

    public ReadWrite(string path) => _path = path;





    public List<T> Read()
    { 
        var list = new List<T>();
        var text = File.ReadAllText(_path);
        if (!string.IsNullOrEmpty(text))
        {
            list = JsonConvert.DeserializeObject<List<T>>(text);
        }
        return list;
    }
    
    public void Write(T obj)
    {  
        var list = Read();
        list.Add(obj);
        File.WriteAllText(_path, JsonConvert.SerializeObject(list));
    }


}
