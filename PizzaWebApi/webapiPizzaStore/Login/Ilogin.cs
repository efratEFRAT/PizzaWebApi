using MyModelse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Login;
public interface Ilogin
{
    public Worker IsExist(string name,int password);

}
