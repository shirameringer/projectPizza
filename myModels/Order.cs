using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myModels;

    public class Order
    {
        public string pizzaName{get;set;}
        public int count{get;set;}
        public double forPay{get;set;}
        public string customerName{get;set;}
        public Order(string name,int count,string customerName,double forPay){
            this.pizzaName=name;
            this.count=count;
            this.forPay=forPay;
            this.customerName=customerName;
        }
    }
