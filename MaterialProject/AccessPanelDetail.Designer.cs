namespace MaterialProject
{
    partial class AccessPanelDetail
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
            this.accessNoTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.idtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.table1IdTxt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // accessNoTxt
            // 
            this.accessNoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.accessNoTxt.Location = new System.Drawing.Point(181, 81);
            this.accessNoTxt.Name = "accessNoTxt";
            this.accessNoTxt.Size = new System.Drawing.Size(211, 34);
            this.accessNoTxt.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("W_nazanin Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(-4, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 35);
            this.label4.TabIndex = 21;
            this.label4.Text = "ACCESSNO:";
            // 
            // idtxt
            // 
            this.idtxt.Enabled = false;
            this.idtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.idtxt.Location = new System.Drawing.Point(181, 21);
            this.idtxt.Name = "idtxt";
            this.idtxt.Size = new System.Drawing.Size(211, 34);
            this.idtxt.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("W_nazanin Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(107, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 35);
            this.label1.TabIndex = 23;
            this.label1.Text = "ID:";
            // 
            // table1IdTxt
            // 
            this.table1IdTxt.Enabled = false;
            this.table1IdTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.table1IdTxt.Location = new System.Drawing.Point(181, 149);
            this.table1IdTxt.Name = "table1IdTxt";
            this.table1IdTxt.Size = new System.Drawing.Size(211, 34);
            this.table1IdTxt.TabIndex = 26;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(497, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 34);
            this.button2.TabIndex = 28;
            this.button2.Text = "DELETE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(497, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 34);
            this.button1.TabIndex = 27;
            this.button1.Text = "UPDATE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AccessPanelDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 233);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.table1IdTxt);
            this.Controls.Add(this.idtxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accessNoTxt);
            this.Controls.Add(this.label4);
            this.Name = "AccessPanelDetail";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "ACCESS PANELS DETAIL";
            this.Load += new System.EventHandler(this.AccessPanelDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox accessNoTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox idtxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox table1IdTxt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}