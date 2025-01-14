// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
namespace myModels;

    public class Worker
    {
        public int id{get;set;}
        public string firstName{get;set;}
        public string lastName{get;set;}
        public string password{get;set;}
        public string role{get;set;}
        public Worker(int id,string firstName,string lastName,string password,string role){
            this.id=id;
            this.firstName=firstName;
            this.lastName=lastName;
            this.password=password;
            this.role=role;
        }
        
    }
