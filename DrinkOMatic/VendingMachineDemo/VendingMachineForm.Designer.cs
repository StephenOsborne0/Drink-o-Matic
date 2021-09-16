
namespace VendingMachineDemo
{
    partial class VendingMachineForm
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
            this.CoffeeButton = new System.Windows.Forms.Button();
            this.LemonTeaButton = new System.Windows.Forms.Button();
            this.HotChocolateButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.RefundButton = new System.Windows.Forms.Button();
            this.InsertOnePoundButton = new System.Windows.Forms.Button();
            this.DisplayTextBox = new System.Windows.Forms.TextBox();
            this.LogRTB = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MoneyInsertedTextBox = new System.Windows.Forms.TextBox();
            this.InsertFiftyPenceButton = new System.Windows.Forms.Button();
            this.InsertTwentyPenceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CoffeeButton
            // 
            this.CoffeeButton.Location = new System.Drawing.Point(338, 12);
            this.CoffeeButton.Name = "CoffeeButton";
            this.CoffeeButton.Size = new System.Drawing.Size(89, 23);
            this.CoffeeButton.TabIndex = 0;
            this.CoffeeButton.Text = "Coffee";
            this.CoffeeButton.UseVisualStyleBackColor = true;
            this.CoffeeButton.Click += new System.EventHandler(this.CoffeeButton_Click);
            // 
            // LemonTeaButton
            // 
            this.LemonTeaButton.Location = new System.Drawing.Point(338, 41);
            this.LemonTeaButton.Name = "LemonTeaButton";
            this.LemonTeaButton.Size = new System.Drawing.Size(89, 23);
            this.LemonTeaButton.TabIndex = 0;
            this.LemonTeaButton.Text = "Lemon Tea";
            this.LemonTeaButton.UseVisualStyleBackColor = true;
            this.LemonTeaButton.Click += new System.EventHandler(this.LemonTeaButton_Click);
            // 
            // HotChocolateButton
            // 
            this.HotChocolateButton.Location = new System.Drawing.Point(338, 70);
            this.HotChocolateButton.Name = "HotChocolateButton";
            this.HotChocolateButton.Size = new System.Drawing.Size(89, 23);
            this.HotChocolateButton.TabIndex = 0;
            this.HotChocolateButton.Text = "Hot Chocolate";
            this.HotChocolateButton.UseVisualStyleBackColor = true;
            this.HotChocolateButton.Click += new System.EventHandler(this.HotChocolateButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Enabled = false;
            this.CancelButton.Location = new System.Drawing.Point(338, 125);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(89, 23);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // RefundButton
            // 
            this.RefundButton.Location = new System.Drawing.Point(338, 310);
            this.RefundButton.Name = "RefundButton";
            this.RefundButton.Size = new System.Drawing.Size(89, 23);
            this.RefundButton.TabIndex = 0;
            this.RefundButton.Text = "Refund";
            this.RefundButton.UseVisualStyleBackColor = true;
            this.RefundButton.Click += new System.EventHandler(this.RefundButton_Click);
            // 
            // InsertOnePoundButton
            // 
            this.InsertOnePoundButton.Location = new System.Drawing.Point(338, 223);
            this.InsertOnePoundButton.Name = "InsertOnePoundButton";
            this.InsertOnePoundButton.Size = new System.Drawing.Size(89, 23);
            this.InsertOnePoundButton.TabIndex = 0;
            this.InsertOnePoundButton.Text = "Insert £1";
            this.InsertOnePoundButton.UseVisualStyleBackColor = true;
            this.InsertOnePoundButton.Click += new System.EventHandler(this.InsertOnePoundButton_Click);
            // 
            // DisplayTextBox
            // 
            this.DisplayTextBox.Location = new System.Drawing.Point(12, 12);
            this.DisplayTextBox.Name = "DisplayTextBox";
            this.DisplayTextBox.Size = new System.Drawing.Size(313, 20);
            this.DisplayTextBox.TabIndex = 1;
            // 
            // LogRTB
            // 
            this.LogRTB.Location = new System.Drawing.Point(12, 41);
            this.LogRTB.Name = "LogRTB";
            this.LogRTB.Size = new System.Drawing.Size(313, 381);
            this.LogRTB.TabIndex = 2;
            this.LogRTB.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MoneyInsertedTextBox
            // 
            this.MoneyInsertedTextBox.Location = new System.Drawing.Point(338, 197);
            this.MoneyInsertedTextBox.Name = "MoneyInsertedTextBox";
            this.MoneyInsertedTextBox.Size = new System.Drawing.Size(89, 20);
            this.MoneyInsertedTextBox.TabIndex = 3;
            // 
            // InsertFiftyPenceButton
            // 
            this.InsertFiftyPenceButton.Location = new System.Drawing.Point(338, 252);
            this.InsertFiftyPenceButton.Name = "InsertFiftyPenceButton";
            this.InsertFiftyPenceButton.Size = new System.Drawing.Size(89, 23);
            this.InsertFiftyPenceButton.TabIndex = 0;
            this.InsertFiftyPenceButton.Text = "Insert 50p";
            this.InsertFiftyPenceButton.UseVisualStyleBackColor = true;
            this.InsertFiftyPenceButton.Click += new System.EventHandler(this.InsertFiftyPenceButton_Click);
            // 
            // InsertTwentyPenceButton
            // 
            this.InsertTwentyPenceButton.Location = new System.Drawing.Point(338, 281);
            this.InsertTwentyPenceButton.Name = "InsertTwentyPenceButton";
            this.InsertTwentyPenceButton.Size = new System.Drawing.Size(89, 23);
            this.InsertTwentyPenceButton.TabIndex = 0;
            this.InsertTwentyPenceButton.Text = "Insert 20p";
            this.InsertTwentyPenceButton.UseVisualStyleBackColor = true;
            this.InsertTwentyPenceButton.Click += new System.EventHandler(this.InsertTwentyPenceButton_Click);
            // 
            // VendingMachineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 434);
            this.Controls.Add(this.MoneyInsertedTextBox);
            this.Controls.Add(this.LogRTB);
            this.Controls.Add(this.DisplayTextBox);
            this.Controls.Add(this.InsertTwentyPenceButton);
            this.Controls.Add(this.InsertFiftyPenceButton);
            this.Controls.Add(this.InsertOnePoundButton);
            this.Controls.Add(this.RefundButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.HotChocolateButton);
            this.Controls.Add(this.LemonTeaButton);
            this.Controls.Add(this.CoffeeButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(455, 473);
            this.MinimumSize = new System.Drawing.Size(455, 473);
            this.Name = "VendingMachineForm";
            this.Text = "Drink o Matic";
            this.Load += new System.EventHandler(this.VendingMachine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CoffeeButton;
        private System.Windows.Forms.Button LemonTeaButton;
        private System.Windows.Forms.Button HotChocolateButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button RefundButton;
        private System.Windows.Forms.Button InsertOnePoundButton;
        private System.Windows.Forms.TextBox DisplayTextBox;
        private System.Windows.Forms.RichTextBox LogRTB;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox MoneyInsertedTextBox;
        private System.Windows.Forms.Button InsertFiftyPenceButton;
        private System.Windows.Forms.Button InsertTwentyPenceButton;
    }
}

