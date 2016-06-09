using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PartyReservationFilterModule
{
    public static void Main()
    {
        Func<int, int> firstFunc = x => x + 1;
        firstFunc += x => x + 2;
        firstFunc += x => x + 3;

        Console.WriteLine(firstFunc(1));
    }
}