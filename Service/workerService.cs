using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using porjectPizza.models;

namespace porjectPizza.Service
{
  public class workerService
  {
    List<Worker> workerList = new List<Worker>(){
          new Worker(10,"shira","meringer"),

        };

    public Worker getWorkerById(int id)
    {
      foreach (var i in type)
      {
        if (i.id == id)
        {
          return i;
        }
      }
      return null;
    }
    public void postworker(int id, string fname, string lNmae)
    {
        Worker( id,fname,lname);
       

    }

  }
}