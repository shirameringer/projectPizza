// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
namespace myModels;

    public class Pizza
    {
        public int id { get; set; }

        public bool ifGloten { get; set; }

        public string pizzaName{ get; set; }
        public double price{get;set;}

       public Pizza(int id,bool ifgloten,string pizzaName,double price){
        this.id=id;
        this.ifGloten=ifGloten;
        this.pizzaName=pizzaName;
        this.price=price;
       }
       
    }
    

