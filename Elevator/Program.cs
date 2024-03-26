using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    public class Program
    {
        static void Main(string[] args)
        {
            InputFromArr();
            Console.ReadLine();
        }
        static void InputFromArr()
        {
            Elevator elevator = new Elevator();

            string[] a = { "2U", "3D", "4U", "1", "5D", "6" };
            for (int i = 0; i < a.Length; i++)
            {
                elevator.Insert(a[i]);
            }
            elevator.Use_Elevator();
        }
        
    }
}
