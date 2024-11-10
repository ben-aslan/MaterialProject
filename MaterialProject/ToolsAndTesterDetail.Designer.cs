namespace MaterialProject
{
    partial class ToolsAndTesterDetail
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
            this.tatDescriptionTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tatPartNoTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.table1IdTxt = new System.Windows.Forms.TextBox();
            this.idtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tatDescriptionTxt
            // 
            this.tatDescriptionTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.tatDescriptionTxt.Location = new System.Drawing.Point(222, 181);
            this.tatDescriptionTxt.Name = "tatDescriptionTxt";
            this.tatDescriptionTxt.Size = new System.Drawing.Size(446, 34);
            this.tatDescriptionTxt.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("W_nazanin Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(3, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 35);
            this.label10.TabIndex = 31;
            this.label10.Text = "DESCRIPTION:";
            // 
            // tatPartNoTxt
            // 
            this.tatPartNoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.tatPartNoTxt.Location = new System.Drawing.Point(192, 124);
            this.tatPartNoTxt.Name = "tatPartNoTxt";
            this.tatPartNoTxt.Size = new System.Drawing.Size(211, 34);
            this.tatPartNoTxt.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("W_nazanin Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(63, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 35);
            this.label9.TabIndex = 32;
            this.label9.Text = "PARTNO:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(488, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 34);
            this.button2.TabIndex = 48;
            this.button2.Text = "DELETE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(488, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 34);
            this.button1.TabIndex = 47;
            this.button1.Text = "UPDATE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // table1IdTxt
            // 
            this.table1IdTxt.Enabled = false;
            this.table1IdTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.table1IdTxt.Location = new System.Drawing.Point(192, 73);
            this.table1IdTxt.Name = "table1IdTxt";
            this.table1IdTxt.Size = new System.Drawing.Size(211, 34);
            this.table1IdTxt.TabIndex = 46;
            // 
            // idtxt
            // 
            this.idtxt.Enabled = false;
            this.idtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.idtxt.Location = new System.Drawing.Point(192, 18);
            this.idtxt.Name = "idtxt";
            this.idtxt.Size = new System.Drawing.Size(211, 34);
            this.idtxt.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("W_nazanin Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(141, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 35);
            this.label1.TabIndex = 43;
            this.label1.Text = "ID:";
            // 
            // ToolsAndTesterDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 238);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.table1IdTxt);
            this.Controls.Add(this.idtxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tatDescriptionTxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tatPartNoTxt);
            this.Controls.Add(this.label9);
            this.Name = "ToolsAndTesterDetail";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "TOOL AND TESTER DETAIL";
            this.Load += new System.EventHandler(this.ToolsAndTestersDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tatDescriptionTxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tatPartNoTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox table1IdTxt;
        private System.Windows.Forms.TextBox idtxt;
        private System.Windows.Forms.Label label1;
    }
}