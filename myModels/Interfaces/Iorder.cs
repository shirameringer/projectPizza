using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace myModels.Interfaces;

    public interface Iorder
    {
        Task<string> postOrder(string pizzaName,int count,string customerName,double price,long creditNum,string validity,int threeDigit,string email);
        Task<string> toPayAsync();
        Task<string> makeingPizzaAsync(Order o);
        void printBill(Order o);
    }
