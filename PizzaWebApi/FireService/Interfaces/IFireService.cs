
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FireService.Interfaces;
{
public interface IFireService<T>
{
    //   void ReadWrite<T>(string path);
    List<T> Read();
    void Write(T obj);


}
}