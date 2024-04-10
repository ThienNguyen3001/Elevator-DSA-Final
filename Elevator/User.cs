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
        private bool isUserActive = true;
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
        public void StopUser()
        {
            isUserActive = false; // Thiết lập biến để kết thúc vòng lặp trong hàm User_inE
        }

        public void User_inE(int Head, int k)
        {
            if (k >= 1 && k <= 6)
            {
                if (k > elevator.position)
                {
                    elevator.Insert(UserU[k]);
                }
                else
                {
                    elevator.Insert(UserD[k]);
                }
            }
            else
            {
                Console.WriteLine("kochay");
            }
        }        
    }
}
