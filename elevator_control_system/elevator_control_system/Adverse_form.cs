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
    public partial class Adverse_form : Form
    {
        public static Adverse_form Panel { get; set; }

        private int Column = 0;

        public Adverse_form(int Input)
        {
            InitializeComponent();
            Panel = this;
            Panel.label2.Text = Input.ToString();
            Column = Input;
        }

        private void Adverse_form_Load(object sender, EventArgs e)
        {
            timer_light.Stop();
        }

        
        private void Warning_2()  //предупреждение "Невозможно совершить отправку. Лифт уже на этом этаже" 
        {
            MessageBox.Show("Невозможно совершить отправку. Лифт уже на этом этаже", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void floor_3_Click(object sender, EventArgs e)
        {
            timer_light.Stop();
            timer_light.Start();

            switch (Column)
            {
                case 1:
                    if (Form1.MainWindow.Control.cabin_1.GetFloor() == 3)
                    {
                        Warning_2();
                        timer_light.Stop();
                    }
                    else
                    {
                        floor_3.Image = elevator_control_system.Properties.Resources._3_pushed;
                        Form1.MainWindow.Control.cabin_1.CabinCall(3);
                    }
                    break;
                
                    
                case 2:
                    if (Form1.MainWindow.Control.cabin_2.GetFloor() == 3)
                    {
                        Warning_2();
                        timer_light.Stop();
                    }
                    else
                    {
                        floor_3.Image = elevator_control_system.Properties.Resources._3_pushed;
                        Form1.MainWindow.Control.cabin_2.CabinCall(3);                        
                    }
                    break;
                
                case 3:
                    if (Form1.MainWindow.Control.cabin_3.GetFloor() == 3)
                    {
                        Warning_2();
                        timer_light.Stop();
                    }
                    else
                    {
                        floor_3.Image = elevator_control_system.Properties.Resources._3_pushed;
                        Form1.MainWindow.Control.cabin_3.CabinCall(3);
                    }
                    break;
                }
         }

        private void floor_2_Click(object sender, EventArgs e)
        {
            timer_light.Stop();
            timer_light.Start();

            switch (Column)
            {
                case 1:
                        if (Form1.MainWindow.Control.cabin_1.GetFloor() == 2)
                        {
                            Warning_2();
                            timer_light.Stop();
                        }
                        else
                        {
                            floor_2.Image = elevator_control_system.Properties.Resources._2_pushed;
                            Form1.MainWindow.Control.cabin_1.CabinCall(2);
                        }
                        break;
                    
                case 2:
                        if (Form1.MainWindow.Control.cabin_2.GetFloor() == 2)
                        {
                            Warning_2();
                            timer_light.Stop();
                        }
                        else
                        {
                            floor_2.Image = elevator_control_system.Properties.Resources._2_pushed;
                            Form1.MainWindow.Control.cabin_2.CabinCall(2);
                        }
                        break;
                   
                case 3:
                        if (Form1.MainWindow.Control.cabin_3.GetFloor() == 2)
                        {
                            Warning_2();
                            timer_light.Stop();
                        }
                        else
                        {
                            floor_2.Image = elevator_control_system.Properties.Resources._2_pushed;
                            Form1.MainWindow.Control.cabin_3.CabinCall(2);
                        }
                        break;
                    }
        }

        private void button3_Click(object sender, EventArgs e)  //эт кнопка 1 этажа, переимменуйте мне в падлу)
        {
            timer_light.Stop();
            timer_light.Start();

            switch (Column)
            {
                case 1:
                        if (Form1.MainWindow.Control.cabin_1.GetFloor() == 1)
                        {
                            Warning_2();
                            timer_light.Stop();
                        }
                        else
                        {
                            floor_1.Image = elevator_control_system.Properties.Resources._1_pushed;
                            Form1.MainWindow.Control.cabin_1.CabinCall(1);
                        }
                        break;
                    
                case 2:
                        if (Form1.MainWindow.Control.cabin_2.GetFloor() == 1)
                        {
                            Warning_2();
                            timer_light.Stop();
                        }
                        else
                        {
                            floor_1.Image = elevator_control_system.Properties.Resources._1_pushed;
                            Form1.MainWindow.Control.cabin_2.CabinCall(1);
                        }
                        break;
                    
                case 3:
                        if (Form1.MainWindow.Control.cabin_3.GetFloor() == 1)
                        {
                            Warning_2();
                            timer_light.Stop();
                        }
                        else
                        {
                            floor_1.Image = elevator_control_system.Properties.Resources._1_pushed;
                            Form1.MainWindow.Control.cabin_3.CabinCall(1);
                        }
                        break;
                    }
        }

        private void timer_light_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
