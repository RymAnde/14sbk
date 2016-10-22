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
        public Adverse_form()
        {
            InitializeComponent();
           
        }

        private void Adverse_form_Load(object sender, EventArgs e)
        {

        }
        //предупреждение "Невозможно совершить отправку. Лифт уже на этом этаже" 
        private void Warning_2()
        {
            MessageBox.Show("Невозможно совершить отправку. Лифт уже на этом этаже", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void floor_3_Click(object sender, EventArgs e)
        {
            floor_3.Image = elevator_control_system.Properties.Resources._3_pushed;
            //здесь код выполнения
            timer_light.Start();
            
        }

        private void floor_2_Click(object sender, EventArgs e)
        {
            floor_2.Image = elevator_control_system.Properties.Resources._2_pushed;
            //здесь код выполнения
            timer_light.Start();
        }

        private void button3_Click(object sender, EventArgs e)//эт кнопка 1 этажа, переимменуйте мне в падлу)
        {
            floor_1.Image = elevator_control_system.Properties.Resources._1_pushed;
            //здесь код выполнения
            timer_light.Start();
        }

        private void timer_light_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
