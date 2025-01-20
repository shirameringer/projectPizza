// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using myModels;
using myModels.Interfaces;
using fileScdervices.Interface;

namespace myServices;

public class workerService : Iworker
{
  private readonly IfileServices<Worker> _IFileService;
  public workerService(IfileServices<Worker> fileService)
    {
        
        _IFileService = fileService;
    }


  List<Worker> workerList = new List<Worker>(){
          new Worker(10,"shira","meringer","ggg","ggg"),

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
  public void postworker(int id, string fname, string lNmae, string password, string role)
  {
    workerList.Add(new Worker(id, fname, lNmae, password, role));


  }
  public void addWorker(Worker w)
  {
    _IFileService.Write(w);
  }
  public List<Worker> readWorker()
  {
    return _IFileService.Read();
  }

}
