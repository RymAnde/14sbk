using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elevator_control_system
{
    public partial class Form1 : Form
    {     
        public Controller Control = new Controller();

        public Form1()
        {
            InitializeComponent();            
        }
        //анимация открытия дверей, передаётся левая и правая дверь, которые надо открыть
        public void Open_doors(System.Windows.Forms.PictureBox left_door, System.Windows.Forms.PictureBox right_door)
        {
            open_door_timer.Interval = 50;
            int count = 0;
            int max = 40;
            open_door_timer.Tick += new EventHandler((o, ev) =>
            {
                Point loc_1 = left_door.Location;
                Point loc_2 = right_door.Location;
                loc_1.Offset(-1, 0);
                loc_2.Offset(1, 0);
                left_door.Location = loc_1;
                right_door.Location = loc_2;

                count++;
                if (count == max)
                {
                    Timer t = o as Timer; // можно тут просто воспользоваться timer
                    t.Stop();
                }
            });
            open_door_timer.Start();
        }
        //анимация закрытия  дверей, передаётся левая и правая дверь, которые надо закрыть
        public void Close_doors(System.Windows.Forms.PictureBox left_door, System.Windows.Forms.PictureBox right_door)
        {
            open_door_timer.Interval = 50;
            int count = 0;
            int max = 40;
            open_door_timer.Tick += new EventHandler((o, ev) =>
            {
                Point loc_1 = left_door.Location;
                Point loc_2 = right_door.Location;
                loc_1.Offset(1, 0);
                loc_2.Offset(-1, 0);
                left_door.Location = loc_1;
                right_door.Location = loc_2;

                count++;
                if (count == max)
                {
                    Timer t = o as Timer; // можно тут просто воспользоваться timer
                    t.Stop();
                }
            });
            open_door_timer.Start();
        }
        private void Call_adverse_form()
        {
            Adverse_form f = new Adverse_form();
            f.Show();
        }

        //перреключения лампочки лифта на красный
        public void Switch_led_tored(System.Windows.Forms.PictureBox led)
        {
            led.Image = elevator_control_system.Properties.Resources.red_led;
        }
        //перреключения лампочки лифта на красный
        public void Switch_led_togreen(System.Windows.Forms.PictureBox led)
        {
            led.Image = elevator_control_system.Properties.Resources.green_led;
        }
        //предупреждение в отдельном окне "Лифт уже вызван"
        public void Warning_1()
        {
            MessageBox.Show("Лифт уже вызван/двигается на этот этаж", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            Control.SetColumns();

            timer1.Start();
            //Open_doors(left_door_1_1, right_door_1_1);
            //Open_doors(left_door_1_2, right_door_1_2);
            //Open_doors(left_door_1_3, right_door_1_3);
            //Call_adverse_form();           
        }
        private void call_button_1_Click(object sender, EventArgs e)
        {
            
            if (!Control.Call(1))
                Warning_1();
        }

        private void call_button_2_Click(object sender, EventArgs e)
        {
            if (!Control.Call(2))
                Warning_1();
        }

        private void call_buton_3_Click(object sender, EventArgs e)
        {   
            if (!Control.Call(3))
                Warning_1();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        public void Refresh_1()
        {
            if (Control.cabin_1.Doors)
                switch (Control.cabin_1.GetFloor())
                {
                    case 1:
                        Open_doors(left_door_1_1, right_door_1_1);
                        break;
                    case 2:
                        Open_doors(left_door_2_1, right_door_2_1);
                        break;
                    case 3:
                        Open_doors(left_door_3_1, right_door_3_1);
                        break;
                }
            else
            {
                switch (Control.cabin_1.GetFloor())
                {
                    case 1:
                        Close_doors(left_door_1_1, right_door_1_1);
                        break;
                    case 2:
                        Close_doors(left_door_2_1, right_door_2_1);
                        break;
                    case 3:
                        Close_doors(left_door_3_1, right_door_3_1);
                        break;
                }
            }

            if (Control.cabin_1.IsMoving)
                switch (Control.cabin_1.GetFloor())
                {
                    case 1:
                        Switch_led_tored(led_1_1);
                        break;
                    case 2:
                        Switch_led_tored(led_2_1);
                        break;
                    case 3:
                        Switch_led_tored(led_3_1);
                        break;
                }
            else
            {
                switch (Control.cabin_1.GetFloor())
                {
                    case 1:
                        Switch_led_togreen(led_1_1);
                        break;
                    case 2:
                        Switch_led_togreen(led_2_1);
                        break;
                    case 3:
                        Switch_led_togreen(led_3_1);
                        break;
                }
            }
        }

        public void Refresh_2()
        {
            if (Control.cabin_2.Doors)
                switch (Control.cabin_2.GetFloor())
                {
                    case 1:
                        Open_doors(left_door_1_2, right_door_1_2);
                        break;
                    case 2:
                        Open_doors(left_door_2_2, right_door_2_2);
                        break;
                    case 3:
                        Open_doors(left_door_3_2, right_door_3_2);
                        break;
                }
            else
            {
                switch (Control.cabin_2.GetFloor())
                {
                    case 1:
                        Close_doors(left_door_1_2, right_door_1_2);
                        break;
                    case 2:
                        Close_doors(left_door_2_2, right_door_2_2);
                        break;
                    case 3:
                        Close_doors(left_door_3_2, right_door_3_2);
                        break;
                }
            }
            if (Control.cabin_2.IsMoving)
                switch (Control.cabin_2.GetFloor())
                {
                    case 1:
                        Switch_led_tored(led_1_2);
                        break;
                    case 2:
                        Switch_led_tored(led_2_2);
                        break;
                    case 3:
                        Switch_led_tored(led_3_2);
                        break;
                }
            else
            {
                switch (Control.cabin_2.GetFloor())
                {
                    case 1:
                        Switch_led_togreen(led_1_2);
                        break;
                    case 2:
                        Switch_led_togreen(led_2_2);
                        break;
                    case 3:
                        Switch_led_togreen(led_3_2);
                        break;
                }
            }
        }

        public void Refresh_3()
        {
            if (Control.cabin_3.Doors)
                switch (Control.cabin_3.GetFloor())
                {
                    case 1:
                        Open_doors(left_door_1_3, right_door_1_3);
                        break;
                    case 2:
                        Open_doors(left_door_2_3, right_door_2_3);
                        break;
                    case 3:
                        Open_doors(left_door_3_3, right_door_3_3);
                        break;
                }
            else
            {
                switch (Control.cabin_3.GetFloor())
                {
                    case 1:
                        Close_doors(left_door_1_3, right_door_1_3);
                        break;
                    case 2:
                        Close_doors(left_door_2_3, right_door_2_3);
                        break;
                    case 3:
                        Close_doors(left_door_3_3, right_door_3_3);
                        break;
                }
            }
            if (Control.cabin_3.IsMoving)
                switch (Control.cabin_3.GetFloor())
                {
                    case 1:
                        Switch_led_tored(led_1_3);
                        break;
                    case 2:
                        Switch_led_tored(led_2_3);
                        break;
                    case 3:
                        Switch_led_tored(led_3_3);
                        break;
                }
            else
            {
                switch (Control.cabin_3.GetFloor())
                {
                    case 1:
                        Switch_led_togreen(led_1_3);
                        break;
                    case 2:
                        Switch_led_togreen(led_2_3);
                        break;
                    case 3:
                        Switch_led_togreen(led_3_3);
                        break;
                }
            }
        }

        public bool Refresh(int Input)
        {
            switch (Input)
            {
                case 1:
                    Refresh_1();
                    break;
                case 2:
                    Refresh_2();
                    break;
                case 3:
                    Refresh_3();
                    break;
            }
        return true;
        }      
    }
}

