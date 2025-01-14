using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myModels;
namespace Login.Interface;

    public interface Ilogin
    {
        Worker IsWorkerValid(string name, string password);
    }