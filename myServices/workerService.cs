// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using myModels;
using myModels.Interfaces;

namespace myServices;

  public class workerService:Iworker
  {
    List<Worker> workerList = new List<Worker>(){
          new Worker(10,"shira","meringer"),

        };

    public string getWorkerById(int id)
    {
      foreach (var i in workerList)
      {
        if (i.id == id)
        {
          return i.firstName;
        }
      }
      return null;
    }
    public void postworker(int id, string fname, string lNmae)
    {
       workerList.Add(new Worker(id,fname,lNmae)) ;
       

    }

  }
