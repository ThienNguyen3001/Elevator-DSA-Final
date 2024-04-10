using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            string[] a = { "1", "3D", "3U", "2D", "5D", "6", "4D" };
            //string[] a = { "2D", "3D", "3U", "2D", "5D", "5U", "4D" };
            //string[] a = { "2U", "3D", "3U", "2D", "6", "5U", "4D" };
            //string[] a = { "2U", "3D", "3U", "2D", "5D", "5U", "4D" };
            //string[] a = { "2U", "3D", "3U","2D", "5D", "5U", "4D" };
            for (int i = 0; i < a.Length; i++)
            {
                elevator.Insert(a[i]);
            }
            elevator.Use_Elevator();

        }        
    }
}
