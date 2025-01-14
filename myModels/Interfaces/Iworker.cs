using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace myModels.Interfaces;

    public interface Iworker
    {
        public string getWorkerById(int id);
        public void postworker(int id,string fname,string lNmae,string password,string role);
        public void writeWorker(Worker w);
        public List<Worker> readWorker();
    }
