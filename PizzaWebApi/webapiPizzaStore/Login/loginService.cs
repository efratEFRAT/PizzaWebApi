
using FireService;
using FireService.Interfaces;
using MyS;
using MyModelse;
namespace Login;

public class loginService:Ilogin
{
  IFireService<Worker> _workFile;
  public loginService(IFireService<Worker> workFile){

   _workFile =workFile;
  }

    
  public Worker IsExist(string name,int password){

   List<Worker> WorkList= _workFile.Read();
    foreach (var w in WorkList){
   
    if(w.name==name&& w.password==password){
           return w;

    }}
    return null;
  }
}