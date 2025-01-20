using myModels;
using myModels.Interfaces;
using fileScdervices.Interface;

namespace myServices;

public class orderService : Iorder
{

    private readonly IfileServices<Order> _IFileService;
    public orderService(IfileServices<Order> fileService)
    {

        _IFileService = fileService;
    }

    List<Order> OrderList = new List<Order>(){
             new Order("pizza binica",3,"shira",150,123123121312123123,"12/09",998,"s0548543446@gmail.com"),
         };


    public async Task<string> postOrder(string pizzaName, int count, string customerName, double price, long creditNum, string validity, int threeDigit, string email)
    {
        Order myOrder = new Order(pizzaName, count, customerName, price, creditNum, validity, threeDigit, email);
        _IFileService.Write(myOrder);
        var toPay = toPayAsync();
        var makeingPizza = makeingPizzaAsync(myOrder);
        await toPay;
        printBill(myOrder);
        await makeingPizza;
        Console.WriteLine("you finished");
        return "you finished";

    }
    public async Task<string> toPayAsync()
    {
        Console.WriteLine("loading....");
        await Task.Delay(5000);
        Console.WriteLine("Successfuly paid");
        return "Successfuly paid";

    }

    public async Task<string> makeingPizzaAsync(Order o)
    {
        Console.WriteLine("starting to make your pizza....");
        for (int i = 1; i <= o.count; i++)
        {
            Console.WriteLine("make to dough..");
            await Task.Delay(2000);
            Console.WriteLine("puting extras");
            await Task.Delay(2000);
            Console.WriteLine("enter the oven");
            await Task.Delay(2000);
            Console.WriteLine($"the pizza {i} ");


        }

        return "the pizza is ready";

    }
    public void printBill(Order o)
    {
        Console.WriteLine($"pizzaName: {o.pizzaName} count: {o.count} price: {o.forPay}");

    }


}
