using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using porjectPizza.Interfaces;
using porjectPizza.models;
using PROJECTPIZZA;

namespace porjectPizza.Service
{
    public class orderService : Iorder
    {
       
         List<Order>OrderList=new List<Order>(){
             new Order("pizza binica",3,"shira",150),
         };
       

        public bool postOrder(string pizzaName, int count, string customerName)
        {
            
            
        }

        public double getPrice(string customerName)
        {
          
        }
    }
}