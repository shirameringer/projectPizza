using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace porjectPizza.Interfaces
{
    public interface Iorder
    {
        bool postOrder(string pizzaName,int count,string customerName);
        double getPrice(string customerName);

    }
}