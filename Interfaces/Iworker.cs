using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace porjectPizza.Interfaces
{
    public interface Iworker
    {
        public string getWorkerById(int id);
        public void postworker(int id,string fname,string lNmae);
    }
}