

public  interface IworkerManager{
  void postworker(string name,int id,int  password,string  role);
  bool putworker(string name,int id,int  password,string  role);
  List<Worker> readWorker();
}