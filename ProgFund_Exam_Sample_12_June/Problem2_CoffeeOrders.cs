using System;
using System.Globalization;
using System.Threading;

public class CoffeeOrders
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
        int coffeeNumber = int.Parse(Console.ReadLine());
        decimal totalPrice = 0;

        for (int i = 0; i < coffeeNumber; i++)
        {
            decimal price = decimal.Parse(Console.ReadLine());
            DateTime month = DateTime.Parse(Console.ReadLine());
            decimal count = decimal.Parse(Console.ReadLine());

            //((daysInMonth * capsulesCount) * pricePerCapsule)
            decimal daysInMonth = DateTime.DaysInMonth(month.Year,month.Month);
            decimal currentPrice = (daysInMonth*count)*price;
            Console.WriteLine("The price for the coffee is: ${0:F2}", currentPrice);
            totalPrice += currentPrice;
        }
        Console.WriteLine("Total: ${0:F2}", totalPrice);
    }
}