using DemoAppConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAppConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Class1 class1 = new Class2();
            class1.MyProperty = 10; // class1.setInt(10); (java like)
            int a = class1.MyProperty;

            // Read only
            //class1.MyProperty1 = 10;
            Console.ReadKey();
        }
    }
}
