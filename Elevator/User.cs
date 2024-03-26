using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    public class User
    {
        private Elevator elevator; // Thêm một thuộc tính Elevator vào lớp User
        static Dictionary<int, string> UserU = new Dictionary<int, string>();
        static Dictionary<int, string> UserD = new Dictionary<int, string>();
        public User(Elevator elevator) // Thêm một constructor nhận Elevator làm tham số
        {
            this.elevator = elevator;

            UserU.Add(6, "6");
            UserU.Add(2, "2U");
            UserU.Add(3, "3U");
            UserU.Add(4, "4U");
            UserU.Add(5, "5U");

            UserD.Add(1, "1");
            UserD.Add(2, "2D");
            UserD.Add(3, "3D");
            UserD.Add(4, "4D");
            UserD.Add(5, "5D");
        }
              
        static void User_inE(Elevator elevator)
        {
            while (elevator.Use)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                int k = int.Parse(key.KeyChar.ToString()); ;
                if (k < 1 || k > 6)
                {
                    continue;
                }
                else
                {
                    if (k > elevator.Head)
                    {
                        elevator.Insert(UserU[k]);
                    }
                    else
                    {
                        elevator.Insert(UserD[k]);
                    }
                }
            }
        }

    }
}
