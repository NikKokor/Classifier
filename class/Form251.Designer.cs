using System.Windows.Forms;

namespace @class
{
    partial class Form251
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.button4.Location = new System.Drawing.Point(332, 225);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 48);
            this.button4.TabIndex = 44;
            this.button4.Text = "<";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.button3.Location = new System.Drawing.Point(332, 291);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 48);
            this.button3.TabIndex = 43;
            this.button3.Text = ">";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox3
            // 
            this.listBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 25;
            this.listBox3.Location = new System.Drawing.Point(415, 176);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(290, 204);
            this.listBox3.TabIndex = 42;
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 25;
            this.listBox2.Location = new System.Drawing.Point(12, 176);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(290, 204);
            this.listBox2.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label3.Location = new System.Drawing.Point(415, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 25);
            this.label3.TabIndex = 40;
            this.label3.Text = "Выбранные значения признака";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label2.Location = new System.Drawing.Point(12, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 25);
            this.label2.TabIndex = 39;
            this.label2.Text = "Список возможных значений";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(641, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 48);
            this.button1.TabIndex = 38;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 32);
            this.label1.TabIndex = 37;
            this.label1.Text = "Выбор значений признака класса";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label5.Location = new System.Drawing.Point(13, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 30);
            this.label5.TabIndex = 47;
            // 
            // Form251
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form251";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Классификатор деревьев";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

        #endregion
        private Button button4;
        private Button button3;
        private ListBox listBox3;
        private ListBox listBox2;
        private Label label3;
        private Label label2;
        private Button button1;
        private Label label1;
        private Label label5;
    }
}