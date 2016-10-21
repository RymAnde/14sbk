namespace elevator_control_system
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.left_door_1 = new System.Windows.Forms.PictureBox();
            this.left_door_2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.left_door_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_door_2)).BeginInit();
            this.SuspendLayout();
            // 
            // left_door_1
            // 
            this.left_door_1.Image = global::elevator_control_system.Properties.Resources.left_door;
            this.left_door_1.Location = new System.Drawing.Point(118, 38);
            this.left_door_1.Name = "left_door_1";
            this.left_door_1.Size = new System.Drawing.Size(33, 110);
            this.left_door_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.left_door_1.TabIndex = 0;
            this.left_door_1.TabStop = false;
            // 
            // left_door_2
            // 
            this.left_door_2.Image = global::elevator_control_system.Properties.Resources.left_door;
            this.left_door_2.Location = new System.Drawing.Point(266, 38);
            this.left_door_2.Name = "left_door_2";
            this.left_door_2.Size = new System.Drawing.Size(33, 110);
            this.left_door_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.left_door_2.TabIndex = 1;
            this.left_door_2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::elevator_control_system.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.left_door_2);
            this.Controls.Add(this.left_door_1);
            this.Name = "Form1";
            this.Text = "Программа управления лифтами";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.left_door_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_door_2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox left_door_1;
        private System.Windows.Forms.PictureBox left_door_2;
    }
}

