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
using elevator_control_system.Properties;

namespace elevator_control_system
{
    public partial class Form1 : Form
    {
        public static Form1 MainWindow { get; set; }

        public Form1()
        {
            InitializeComponent();
            MainWindow = this;
            RefreshAll();
        }

        public Controller Control = new Controller();

        //анимация открытия дверей, передаётся левая и правая дверь, которые надо открыть
        public void Open_doors(System.Windows.Forms.PictureBox left_door, System.Windows.Forms.PictureBox right_door)
        {
            left_door.Image = elevator_control_system.Properties.Resources.Invisible;
            right_door.Image = elevator_control_system.Properties.Resources.Invisible;
            /*left_door.Visible = false;
            right_door.Visible = false;
            left_door.Refresh();
            right_door.Refresh(); */

            /*open_door_timer.Interval = 50;
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
            open_door_timer.Start();*/
        }

        //анимация закрытия  дверей, передаётся левая и правая дверь, которые надо закрыть
        public void Close_doors(System.Windows.Forms.PictureBox left_door, System.Windows.Forms.PictureBox right_door)
        {
            left_door.Image = elevator_control_system.Properties.Resources.left_door;
            right_door.Image = elevator_control_system.Properties.Resources.right_door;

            /* left_door.Visible = true;
             right_door.Visible = true;
             left_door.Refresh();
             right_door.Refresh();*/

            /*open_door_timer.Interval = 50;
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
            open_door_timer.Start();*/
        }

        public void Call_adverse_form(int Input)
        {
            Adverse_form CabinInputPanel = new Adverse_form(Input);
            CabinInputPanel.Show();
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
            MessageBox.Show("Лифт уже вызван на этот этаж", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Control.SetColumns();          
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
            if (Control.cabin_1.GetDoors())
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

            if (Control.cabin_1.GetMovement())
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
            if (Control.cabin_2.GetDoors())
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
            if (Control.cabin_2.GetMovement())
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
            if (Control.cabin_3.GetDoors())
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
            if (Control.cabin_3.GetMovement())
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

        public void RefreshAll()
        {
            Refresh_1();
            Refresh_2();
            Refresh_3();
        }

        public void Refresh(int Input)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((Control.cabin_1.GetFloor() == 1) && (Control.cabin_1.GetDoors()))
            {
                Call_adverse_form(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((Control.cabin_2.GetFloor() == 1) && (Control.cabin_2.GetDoors()))
            {
                Call_adverse_form(2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((Control.cabin_3.GetFloor() == 1) && (Control.cabin_3.GetDoors()))
            {
                Call_adverse_form(3);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((Control.cabin_1.GetFloor() == 2) && (Control.cabin_1.GetDoors()))
            {
                Call_adverse_form(1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((Control.cabin_2.GetFloor() == 2) && (Control.cabin_2.GetDoors()))
            {
                Call_adverse_form(2);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if ((Control.cabin_3.GetFloor() == 2) && (Control.cabin_3.GetDoors()))
            {
                Call_adverse_form(3);
            }
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            if ((Control.cabin_1.GetFloor() == 3) && (Control.cabin_1.GetDoors()))
            {
                Call_adverse_form(1);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if ((Control.cabin_2.GetFloor() == 3) && (Control.cabin_2.GetDoors()))
            {
                Call_adverse_form(2);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if ((Control.cabin_3.GetFloor() == 3) && (Control.cabin_3.GetDoors()))
            {
                Call_adverse_form(3);
            }
        }
    }
}

