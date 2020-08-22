namespace Calculator
{
    partial class AdvancedPlus
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
            this.wordBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // outputPanel
            // 
            this.outputPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputPanel.Size = new System.Drawing.Size(395, 31);
            // 
            // comboBox1
            // 
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // wordBox
            // 
            this.wordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordBox.Location = new System.Drawing.Point(20, 77);
            this.wordBox.Name = "wordBox";
            this.wordBox.Size = new System.Drawing.Size(395, 20);
            this.wordBox.TabIndex = 29;
            this.wordBox.Text = "Zero";
            this.wordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // AdvancedPlus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(434, 386);
            this.Controls.Add(this.wordBox);
            this.Name = "AdvancedPlus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdvancedPlus_FormClosing);
            this.Controls.SetChildIndex(this.button20, 0);
            this.Controls.SetChildIndex(this.button21, 0);
            this.Controls.SetChildIndex(this.button22, 0);
            this.Controls.SetChildIndex(this.button23, 0);
            this.Controls.SetChildIndex(this.outputPanel, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button7, 0);
            this.Controls.SetChildIndex(this.button6, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            this.Controls.SetChildIndex(this.button10, 0);
            this.Controls.SetChildIndex(this.button9, 0);
            this.Controls.SetChildIndex(this.button8, 0);
            this.Controls.SetChildIndex(this.button11, 0);
            this.Controls.SetChildIndex(this.button12, 0);
            this.Controls.SetChildIndex(this.button13, 0);
            this.Controls.SetChildIndex(this.button14, 0);
            this.Controls.SetChildIndex(this.button15, 0);
            this.Controls.SetChildIndex(this.button17, 0);
            this.Controls.SetChildIndex(this.button18, 0);
            this.Controls.SetChildIndex(this.button19, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.Title, 0);
            this.Controls.SetChildIndex(this.button16, 0);
            this.Controls.SetChildIndex(this.wordBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wordBox;
    }
}
