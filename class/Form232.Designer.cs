using System.Windows.Forms;

namespace @class
{
    partial class Form232
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(572, 32);
            this.label1.TabIndex = 21;
            this.label1.Text = "Возможные значения количественных признаков";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.textBox1.Location = new System.Drawing.Point(12, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(300, 32);
            this.textBox1.TabIndex = 25;
            this.textBox1.Text = "Единицы измерения";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 32);
            this.label2.TabIndex = 26;
            this.label2.Text = "Интервал значений";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Location = new System.Drawing.Point(12, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 118);
            this.panel1.TabIndex = 27;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.numericUpDown2.Location = new System.Drawing.Point(269, 69);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(118, 36);
            this.numericUpDown2.TabIndex = 31;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label4.Location = new System.Drawing.Point(3, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 32);
            this.label4.TabIndex = 30;
            this.label4.Text = "Конечное значение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 32);
            this.label3.TabIndex = 29;
            this.label3.Text = "Начальное значение";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.numericUpDown1.Location = new System.Drawing.Point(269, 17);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(118, 36);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(641, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 48);
            this.button1.TabIndex = 28;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(15, 401);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 48);
            this.button2.TabIndex = 29;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form232
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form232";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Классификатор деревьев";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Panel panel1;
        private NumericUpDown numericUpDown2;
        private Label label4;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private Button button1;
        private Button button2;
    }
}