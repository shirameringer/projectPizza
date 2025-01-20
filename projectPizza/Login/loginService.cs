using System.Security.Claims;
using fileScdervices.Interface;
using Login.Interface;
using myModels;
using myServices;


namespace Login.service;

public class LoginService : Ilogin
{
    readonly IfileServices<Worker> worker;
    public LoginService(IfileServices<Worker> w)
    {
        worker = w;
    }

    public Worker IsWorkerValid(string name, string password)
    {
        List<Worker> workerList = worker.Read();
        foreach (var w in workerList)
        {
            if (w.firstName == name && w.password == password)
            {
                return w;
            }

        }
        return null;
    }


}