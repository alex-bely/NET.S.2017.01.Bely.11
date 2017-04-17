using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            FirstListener first = new FirstListener();
            SecondListener second = new SecondListener();
            first.Register(timer);
            second.Register(timer);
            timer.StartTimer(3);
            Console.WriteLine("another attempt");
            first.Unregister(timer);
            timer.StartTimer(2);

            Console.ReadLine();

        }
    }
}
