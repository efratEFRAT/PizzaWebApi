

public class Worker
{
        public string name { get; set; }

        public int id {get; set;}
         public string  role{ get; set; }
      
         public int  password { get; set; }

        public Worker(string name,int id,int  password,string  role)
        {
            this.name=name;
            this.id=id;
            this.password=password;
            this.role=role;
          
        }
}