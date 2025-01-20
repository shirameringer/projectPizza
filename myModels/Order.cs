using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;

namespace myModels;

public class Order
{
    public string pizzaName { get; set; }
    public int count { get; set; }
    public double forPay { get; set; }
    public string customerName { get; set; }
    public CreditCard cardDetails { get; set; }
    public string email { get; set; }
    public Order(string name, int count, string customerName, double forPay, long creditNum, string validity, int threeDigit, string email)
    {
        this.cardDetails = new CreditCard(creditNum, validity, threeDigit);
        this.pizzaName = name;
        this.count = count;
        this.forPay = forPay;
        this.customerName = customerName;
        this.email = email;
    }
    public Order()
    {
        this.cardDetails = new CreditCard(123456789, "02/08", 258);
        this.pizzaName = "orginal";
        this.count = 0;
        this.forPay = 0;
        this.customerName = "hhh";
        this.email = "jjjj";

    }
}
