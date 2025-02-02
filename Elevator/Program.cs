using System;

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
            Elevator elevator = new Elevator(3);

            // Test case
            //string[] a = { "2U", "3D", "5U", "1" };
            //string[] a = { "5D", "3D" };
            //string[] a = { "3U", "5D" };
            //string[] a = { "4D", "5D" };
            //string[] a = { "2U", "3D", "3U", "2D", "5D", "5U", "4D" };
            string[] a = { "2D", "3D", "3U", "2D", "5D", "5U", "4U" };
            //string[] a = { "3U", "5D", "6", "4U", "6", "4D", "5U", "1", "2D", "1" };

            for (int i = 0; i < a.Length; i++)
            {
                elevator.Insert(a[i]);
            }
            elevator.Use_Elevator();
            Console.WriteLine("Done");
        }        
    }
}
