// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using myModels.models;
// using myModels.Interfaces;
using myModels;
using myModels.Interfaces;

namespace myServices;

    public class orderService : Iorder
    {
       
         List<Order>OrderList=new List<Order>(){
             new Order("pizza binica",3,"shira",150),
         };
       

        public void postOrder(string pizzaName, int count, string customerName)
        {
           OrderList.Add(new Order(pizzaName,count,customerName,150.6));
            
        }

       
    }
