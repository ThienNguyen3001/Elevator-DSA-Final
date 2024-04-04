using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    public class Elevator
    {
        private static Dictionary<string, bool> D_elevator = new Dictionary<string, bool>();
        private static Dictionary<string, int> Floor = new Dictionary<string, int>();
        public int Head; // vị trí thang máy hiện tại
        private bool Directions; //true = up, false = down
        private List<int> Up;
        private List<int> Down;
        private Queue<string> Input;
        public bool Use;
        public Elevator() 
        {
            Input = new Queue<string>();
            Up = new List<int>();
            Down = new List<int>();
            Head = 1;
            Use = true;

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
            InsertE(buttom);
        }
        private void InsertE(string buttom)
        {
            
            while(Input.Count > 0)
            {
                string check = Input.Dequeue();
                if (D_elevator[check])
                {
                    InsertU(Floor[check]);
                }
                else
                {
                    InsertD(Floor[check]);
                }
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
            Up = InsertionSort(Up);
        }
        private void InsertD(int buttom)
        {
            foreach(int c in Down)
            {
                if (c == buttom)
                    return;
            }
            Down.Add(buttom);
            Down = InsertionSort(Down);
        }
        private List<int> InsertionSort(List<int> a)
        {
            if (a.Count == 0) { return null; }
            for (int i = 1; i < a.Count; i++)
            {
                int key = a[i];               
                int j = i - 1;
              
                while (j >= 0 && a[j] > key)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = key;
            }
            return a;
        }
        public void Use_Elevator()
        {           
                if (Up.Count > 0 && Down.Count > 0)
                {
                    if (Head >= Down[Down.Count - 1])
                        Directions = false;
                    else Directions = true;
                }
                if (Up.Count > 0 && Down.Count == 0)
                {
                    Directions = true;
                }
                if (Up.Count == 0 && Down.Count > 0)
                {
                    Directions = false;
                }
                while (Use && (Up.Count > 0 || Down.Count > 0))
                {
                    ScanE();
                }                     
        }
        private void ScanE()
        {
            while (Up.Count > 0 && Directions)
            {
                for (int i = 0; i < Up.Count();)
                {                   
                    if (Head < Up[i])
                    {
                        Head = Up[i];
                        Run(Head);
                        Up.RemoveAt(i);
                    }
                    else
                    {                        
                        if (i == Up.Count - 1 && Down.Count > 0)
                        {
                            if (Head == Down[Down.Count -1])
                                Down.RemoveAt(Down.Count - 1);                           
                            break;
                        }
                        i++;
                    }         
                }
                Directions = !Directions;
            }
            while (Down.Count > 0 && !Directions)
            {
                for (int i = Down.Count - 1; i >= 0; i--)
                {                    
                    if (Head > Down[i])
                    {
                        Head = Down[i];
                        Run(Head);
                        Down.RemoveAt(i);
                        if (i == 0 && Up.Count > 0)
                        {
                            if(Head == Up[0])
                                Up.RemoveAt(0);
                            break;
                        }                                                  
                    }                   
                }
                Directions = !Directions;
            }
        }       
        private void Run(int floor)
        {
            if(Head == 1 || Head == 6)
            {
                Directions = !Directions;
            }
            
            Console.WriteLine("Moving to floor " + floor);
        }
    }
}
