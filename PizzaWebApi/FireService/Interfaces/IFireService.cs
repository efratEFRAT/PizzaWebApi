namespace FireService.Interfaces;

public interface IFireService<T>{
  
 List<T> Read(string path);
 void Write(T obj,string path);
 

}