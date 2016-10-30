using elevator_control_system;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elevator_control_system
{
    public class Controller
    {
        public Cabin cabin_1 = new Cabin();        
        public Cabin cabin_2 = new Cabin();
        public Cabin cabin_3 = new Cabin();

        public void SetColumns()
        {
            cabin_1.SetColumn(1);
            cabin_2.SetColumn(2);
            cabin_3.SetColumn(3);
        }

        public bool Call(int Input)
        {
            if (cabin_1.GetQueue(Input) || cabin_2.GetQueue(Input) || cabin_3.GetQueue(Input))
                // Один из лифтов уже вызван на этот этаж
                return false;
            else
            {
                if (cabin_1.GetStatus())
                {
                    cabin_1.CabinCall(Input);
                    cabin_1.Move();
                }
                else
                {
                    if (cabin_2.GetStatus())
                    {
                        cabin_2.CabinCall(Input);
                        cabin_2.Move();
                    }
                    else
                    {
                        //if (cabin_3.GetStatus())
                        {
                            cabin_3.CabinCall(Input);
                            cabin_3.Move();
                        }
                    }
                }
                return true;
            }
        }
    }
}