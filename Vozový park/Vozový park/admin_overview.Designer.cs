namespace Vozový_park
{
    partial class admin_overview
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 99);
            this.button1.TabIndex = 0;
            this.button1.Text = "Správa uživatelů";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addUser_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(49, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 90);
            this.button2.TabIndex = 1;
            this.button2.Text = "Správa vozů";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.addCar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(476, 51);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(231, 99);
            this.button3.TabIndex = 2;
            this.button3.Text = "Přehled uživatelů a jejich rezervací";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.userOverview_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(476, 205);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(231, 90);
            this.button4.TabIndex = 3;
            this.button4.Text = "Přehled vozů a jejich rezervací";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.carOverview_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(49, 337);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(231, 90);
            this.button5.TabIndex = 4;
            this.button5.Text = "Vytvoření rezervace";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.adminCreate_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(286, 337);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(184, 90);
            this.button6.TabIndex = 5;
            this.button6.Text = "Zrušení rezervace";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.adminCancel_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(286, 205);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(184, 90);
            this.button7.TabIndex = 6;
            this.button7.Text = "Náklady na údržbu";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.nakladyNaUdrzbu_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(286, 51);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(184, 99);
            this.button8.TabIndex = 7;
            this.button8.Text = "Změna hesla uživateli";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(520, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Poslední přihlášeni:";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(713, 404);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 10;
            this.button9.Text = "Odhlásit";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.return_OnClick);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(476, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 89);
            this.label6.TabIndex = 14;
            // 
            // admin_overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "admin_overview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin přehled";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.admin_overview_FormClosing);
            this.Load += new System.EventHandler(this.admin_overview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label6;
    }
}