using System.Net;
using System.Security.AccessControl;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using FireService.Interfaces;
namespace FireService;

public class ReadWrite<T>:IFireService<T>
{
    // public readonly string _path;
    
    // public ReadWrite(string path)
    // {
    //     _path= path;
    // }
         
   

    

    public List<T> Read(string path)
    {  // _path = path;
        var list = new List<T>();
        var text = File.ReadAllText(path);
        if (!string.IsNullOrEmpty(text))
        {
            list = JsonConvert.DeserializeObject<List<T>>(text);
        }
        return list;
    }
    
    public void Write(T obj,string path)
    {  // _path = path;
        var list = Read(path);
        list.Add(obj);
        File.WriteAllText(path, JsonConvert.SerializeObject(list));
    }


}
