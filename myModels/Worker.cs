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
        public Worker(int id,string firstName,string lastName){
            this.id=id;
            this.firstName=firstName;
            this.lastName=lastName;
        }
        
    }
