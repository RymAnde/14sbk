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
            
        }

        private void Warning_2()  //предупреждение "Невозможно совершить отправку. Лифт уже на этом этаже" 
        {
            MessageBox.Show("Невозможно совершить отправку. Лифт уже на этом этаже", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void floor_3_Click(object sender, EventArgs e)
        {
            floor_3.Image = elevator_control_system.Properties.Resources._3_pushed;
            switch (Column)
            {
                case 1:
                    Form1.MainWindow.Control.cabin_1.CabinCall(3);
                    break;
                case 2:
                    Form1.MainWindow.Control.cabin_2.CabinCall(3);
                    break;
                case 3:
                    Form1.MainWindow.Control.cabin_3.CabinCall(3);
                    break;
            }
            timer_light.Start();
        }

        private void floor_2_Click(object sender, EventArgs e)
        {
            floor_2.Image = elevator_control_system.Properties.Resources._2_pushed;
            switch (Column)
            {
                case 1:
                    Form1.MainWindow.Control.cabin_1.CabinCall(2);
                    break;
                case 2:
                    Form1.MainWindow.Control.cabin_2.CabinCall(2);
                    break;
                case 3:
                    Form1.MainWindow.Control.cabin_3.CabinCall(2);
                    break;
            }
            timer_light.Start();
        }

        private void button3_Click(object sender, EventArgs e)  //эт кнопка 1 этажа, переимменуйте мне в падлу)
        {
            floor_1.Image = elevator_control_system.Properties.Resources._1_pushed;
            switch (Column)
            {
                case 1:
                    Form1.MainWindow.Control.cabin_1.CabinCall(1);
                    break;
                case 2:
                    Form1.MainWindow.Control.cabin_2.CabinCall(1);
                    break;
                case 3:
                    Form1.MainWindow.Control.cabin_3.CabinCall(1);
                    break;
            }
            timer_light.Start();
        }

        private void timer_light_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
