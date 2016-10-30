namespace elevator_control_system
{
    partial class Adverse_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.floor_3 = new System.Windows.Forms.Button();
            this.floor_2 = new System.Windows.Forms.Button();
            this.floor_1 = new System.Windows.Forms.Button();
            this.timer_light = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // floor_3
            // 
            this.floor_3.BackColor = System.Drawing.Color.Transparent;
            this.floor_3.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.floor_3.FlatAppearance.BorderSize = 0;
            this.floor_3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.floor_3.Image = global::elevator_control_system.Properties.Resources._3;
            this.floor_3.Location = new System.Drawing.Point(55, 12);
            this.floor_3.Name = "floor_3";
            this.floor_3.Size = new System.Drawing.Size(82, 82);
            this.floor_3.TabIndex = 0;
            this.floor_3.UseVisualStyleBackColor = false;
            this.floor_3.Click += new System.EventHandler(this.floor_3_Click);
            // 
            // floor_2
            // 
            this.floor_2.BackColor = System.Drawing.Color.Transparent;
            this.floor_2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.floor_2.Image = global::elevator_control_system.Properties.Resources._2;
            this.floor_2.Location = new System.Drawing.Point(55, 100);
            this.floor_2.Name = "floor_2";
            this.floor_2.Size = new System.Drawing.Size(82, 82);
            this.floor_2.TabIndex = 1;
            this.floor_2.UseVisualStyleBackColor = false;
            this.floor_2.Click += new System.EventHandler(this.floor_2_Click);
            // 
            // floor_1
            // 
            this.floor_1.BackColor = System.Drawing.Color.Transparent;
            this.floor_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.floor_1.Image = global::elevator_control_system.Properties.Resources._1;
            this.floor_1.Location = new System.Drawing.Point(55, 188);
            this.floor_1.Name = "floor_1";
            this.floor_1.Size = new System.Drawing.Size(82, 82);
            this.floor_1.TabIndex = 2;
            this.floor_1.UseVisualStyleBackColor = false;
            this.floor_1.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer_light
            // 
            this.timer_light.Interval = 1000;
            this.timer_light.Tick += new System.EventHandler(this.timer_light_Tick);
            // 
            // Adverse_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::elevator_control_system.Properties.Resources.background1;
            this.ClientSize = new System.Drawing.Size(184, 281);
            this.Controls.Add(this.floor_1);
            this.Controls.Add(this.floor_2);
            this.Controls.Add(this.floor_3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Adverse_form";
            this.Text = "Выберите этаж";
            this.Load += new System.EventHandler(this.Adverse_form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button floor_3;
        private System.Windows.Forms.Button floor_2;
        private System.Windows.Forms.Button floor_1;
        private System.Windows.Forms.Timer timer_light;
    }
}