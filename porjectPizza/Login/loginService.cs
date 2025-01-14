using System.Security.Claims;
using Login.Interface;
using myModels;
using myServices;


namespace Login.service;

public class LoginService : Ilogin
{
    List<Worker> workerList = new List<Worker>(){
          new Worker(10,"shira","meringer","ggg","jjj")

        };

    public Worker IsWorkerValid(string name, string password)
    {
       
        foreach (var w in workerList){
            if(w.firstName==name&&w.password==password){
                return w;
            }

        }
            return null;
    }
    

}