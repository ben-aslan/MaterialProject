namespace MaterialProject
{
    partial class NdtHome
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
            this.ndtsGridView = new System.Windows.Forms.DataGridView();
            this.addAccessPanelBtn = new System.Windows.Forms.Button();
            this.typeTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDTsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDBDataSet = new MaterialProject.MyDBDataSet();
            this.nDTsTableAdapter = new MaterialProject.MyDBDataSetTableAdapters.NDTsTableAdapter();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ndtsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDTsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ndtsGridView
            // 
            this.ndtsGridView.AllowUserToAddRows = false;
            this.ndtsGridView.AllowUserToDeleteRows = false;
            this.ndtsGridView.AllowUserToOrderColumns = true;
            this.ndtsGridView.AutoGenerateColumns = false;
            this.ndtsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ndtsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn});
            this.ndtsGridView.DataSource = this.nDTsBindingSource;
            this.ndtsGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ndtsGridView.Location = new System.Drawing.Point(0, 165);
            this.ndtsGridView.Name = "ndtsGridView";
            this.ndtsGridView.ReadOnly = true;
            this.ndtsGridView.RowHeadersWidth = 51;
            this.ndtsGridView.RowTemplate.Height = 24;
            this.ndtsGridView.Size = new System.Drawing.Size(1002, 217);
            this.ndtsGridView.TabIndex = 1;
            this.ndtsGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ndtsGridView_CellContentDoubleClick);
            this.ndtsGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ndtsGridView_KeyDown);
            // 
            // addAccessPanelBtn
            // 
            this.addAccessPanelBtn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.addAccessPanelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAccessPanelBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addAccessPanelBtn.Location = new System.Drawing.Point(364, 11);
            this.addAccessPanelBtn.Name = "addAccessPanelBtn";
            this.addAccessPanelBtn.Size = new System.Drawing.Size(102, 34);
            this.addAccessPanelBtn.TabIndex = 21;
            this.addAccessPanelBtn.Text = "ADD";
            this.addAccessPanelBtn.UseVisualStyleBackColor = false;
            this.addAccessPanelBtn.Click += new System.EventHandler(this.addAccessPanelBtn_Click);
            // 
            // typeTxt
            // 
            this.typeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.typeTxt.Location = new System.Drawing.Point(116, 8);
            this.typeTxt.Name = "typeTxt";
            this.typeTxt.Size = new System.Drawing.Size(211, 34);
            this.typeTxt.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("W_nazanin Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(7, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 35);
            this.label4.TabIndex = 22;
            this.label4.Text = "TYPE :";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "TYPE";
            this.typeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nDTsBindingSource
            // 
            this.nDTsBindingSource.DataMember = "NDTs";
            this.nDTsBindingSource.DataSource = this.myDBDataSet;
            // 
            // myDBDataSet
            // 
            this.myDBDataSet.DataSetName = "MyDBDataSet";
            this.myDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nDTsTableAdapter
            // 
            this.nDTsTableAdapter.ClearBeforeFill = true;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button6.Location = new System.Drawing.Point(491, 11);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(190, 34);
            this.button6.TabIndex = 32;
            this.button6.Text = "REFRESH";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(12, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 34);
            this.button1.TabIndex = 33;
            this.button1.Text = "DELETE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NdtHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 382);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.addAccessPanelBtn);
            this.Controls.Add(this.typeTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ndtsGridView);
            this.Name = "NdtHome";
            this.Text = "NdtHome";
            this.Load += new System.EventHandler(this.NdtHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ndtsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDTsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ndtsGridView;
        private MyDBDataSet myDBDataSet;
        private System.Windows.Forms.BindingSource nDTsBindingSource;
        private MyDBDataSetTableAdapters.NDTsTableAdapter nDTsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button addAccessPanelBtn;
        private System.Windows.Forms.TextBox typeTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button1;
    }
}