﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Elevator
{
    public class Elevator
    {
        private static Dictionary<string, bool> D_elevator = new Dictionary<string, bool>(); 
        private static Dictionary<string, int> Floor = new Dictionary<string, int>();
        public int Position { get; set; } // vị trí thang máy hiện tại
        private bool Directions; //true = up, false = down
        private List<int> Up;
        private List<int> Down;
        private Queue<string> Input;
        public bool Use; // Thể hiện trạng thái hoạt động của thang máy
        public Elevator(int pos) 
        {
            Input = new Queue<string>();
            Up = new List<int>();
            Down = new List<int>();
            Use = true;
            Position = pos;
            D_elevator.Add("1", false);
            D_elevator.Add("2D", false);
            D_elevator.Add("3D", false);
            D_elevator.Add("4D", false);
            D_elevator.Add("5D", false);
            D_elevator.Add("2U", true);
            D_elevator.Add("3U", true);
            D_elevator.Add("4U", true);
            D_elevator.Add("5U", true);
            D_elevator.Add("6", true);

            Floor.Add("1", 1);
            Floor.Add("2D", 2);
            Floor.Add("3D", 3);
            Floor.Add("4D", 4);
            Floor.Add("5D", 5);
            Floor.Add("2U", 2);
            Floor.Add("3U", 3);
            Floor.Add("4U", 4);
            Floor.Add("5U", 5);
            Floor.Add("6", 6);
        }
        public void Insert(string buttom)
        {
            Input.Enqueue(buttom);
            InsertE();
        }
        private void InsertE()
        {
            string decision = Input.Dequeue();
            if (D_elevator[decision]) 
            {
                InsertU(Floor[decision]);
            }
            else
            {
                InsertD(Floor[decision]);
            }
        }
        private void InsertU(int buttom)
        {
            foreach(int c in Up)
            {
                if (c == buttom)
                    return;
            }
            Up.Add(buttom);
            Up.Sort();
        }
        private void InsertD(int buttom)
        {
            foreach(int c in Down)
            {
                if (c == buttom)
                    return;
            }
            Down.Add(buttom);
            Down.Sort();
        }

        public void Use_Elevator()
        {
            Directions = SetDirections();
            while (Use && (Up.Count > 0 || Down.Count > 0))
            {
                ScanE();
            }
        }
        private bool SetDirections()
        {
            if (Up.Count > 0 && Down.Count == 0)
            {
                if (Position > Up[0])
                {
                    InsertD(Up[0]);
                    Up.RemoveAt(0);                    
                    return false;
                }                   
                return true;
            }
            if (Up.Count == 0 && Down.Count > 0)
            {
                if (Position < Down[Down.Count -1])
                {
                    InsertU(Down[Down.Count - 1]);
                    Down.RemoveAt(Down.Count - 1);
                    return true;
                }
                return false;
            }
            if (Up.Count > 0 && Down.Count > 0)
            {
                if (Position >= Down[Down.Count - 1])
                    return false;
                else return true;
            }
            return true;
        }
        private void ScanE()
        {                       
            if (Up.Count > 0 && Directions)
            {               
                for (int i = 0; i < Up.Count();)
                {                   
                    if (Position < Up[i])   
                    {
                        Position = Up[i];
                        Run(Position);
                        Up.RemoveAt(i);
                        ShowList();
                    }
                    else
                    {
                        i++;                                               
                    }                   
                }                                      
                Directions = SetDirections();
            }
            if (Down.Count > 0 && !Directions)
            {                
                for (int i = Down.Count - 1; i >= 0; i--)
                {                    
                    if (Position > Down[i])
                    {
                        Position = Down[i];
                        Run(Position);
                        Down.RemoveAt(i);  
                        ShowList();
                    }                   
                }                                      
                Directions = SetDirections();
            }
        }       
        private void Run(int floor)
        {                      
            Console.WriteLine("Moving to floor " + floor);
        }
        private void ShowList()
        {
            Console.Write("UP: ");
            if (Up.Count > 0)
            {
                for (int i = 0; i < Up.Count; i++)
                {
                    Console.Write(Up[i]+ "  ");
                }
            }
            else
                Console.Write("NULL");
            
            Console.WriteLine();
            Console.Write("DOWN: ");
            if (Down.Count > 0)
            {
                for (int i = 0; i < Down.Count; i++)
                {
                    Console.Write(Down[i]+ "  ");
                }
            }
            else
                Console.Write("NULL");
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(300);
        }
    }
}
