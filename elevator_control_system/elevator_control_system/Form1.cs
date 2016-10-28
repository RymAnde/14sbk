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
    public partial class Form1 : Form
    {     
        public Controller Control = new Controller();
        public Cabin cabin_1 = new Cabin();
        public Cabin cabin_2 = new Cabin();
        public Cabin cabin_3 = new Cabin();

        public Form1()
        {
            InitializeComponent();            
        }
        //анимация открытия дверей, передаётся левая и правая дверь, которые надо открыть
        private void Open_doors(System.Windows.Forms.PictureBox left_door, System.Windows.Forms.PictureBox right_door)
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
        private void Close_doors(System.Windows.Forms.PictureBox left_door, System.Windows.Forms.PictureBox right_door)
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
        private void Switch_led_tored(System.Windows.Forms.PictureBox led)
        {
            led.Image = elevator_control_system.Properties.Resources.red_led;
        }
        //перреключения лампочки лифта на красный
        private void Switch_led_togreen(System.Windows.Forms.PictureBox led)
        {
            led.Image = elevator_control_system.Properties.Resources.green_led;
        }
        //предупреждение в отдельном окне "Лифт уже вызван"
        private void Warning_1()
        {
            MessageBox.Show("Лифт уже вызван", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            // Open_doors(left_door_1_1, right_door_1_1);
            // Open_doors(left_door_2_2, right_door_2_2);
            // Open_doors(left_door_3_3, right_door_3_3);
            // Call_adverse_form();           
        }
        private void call_button_1_Click(object sender, EventArgs e)
        {           
            Control.Call(1);
        }

        private void call_button_2_Click(object sender, EventArgs e)
        {
            Control.Call(2);
        }

        private void call_buton_3_Click(object sender, EventArgs e)
        {
            Control.Call(3);
        }
    }
}
