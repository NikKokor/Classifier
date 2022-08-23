using System.Windows.Forms;

namespace @class
{
    partial class Form2
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
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.button7.Location = new System.Drawing.Point(641, 401);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(131, 48);
            this.button7.TabIndex = 1;
            this.button7.Text = "Назад";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button21_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(68, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(284, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Классы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(68, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(284, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "Признаки";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(439, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(284, 72);
            this.button3.TabIndex = 4;
            this.button3.Text = "Возможные значения признаков";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.button5.Location = new System.Drawing.Point(68, 277);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(284, 44);
            this.button5.TabIndex = 6;
            this.button5.Text = "Признаки класса";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.button6.Location = new System.Drawing.Point(439, 190);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(284, 72);
            this.button6.TabIndex = 7;
            this.button6.Text = "Значения признаков   класса";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Редактирование значений";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button7);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Классификатор деревьев";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button7;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button5;
        private Button button6;
        private Label label1;
    }
}