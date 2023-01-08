namespace QuanLySieuThiDienMay
{
    partial class TaoPhieuNhap
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
            this.tb_sum_bill = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_add_cart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbb_Employee = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cbb_Product = new System.Windows.Forms.ComboBox();
            this.cbb_Category = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_import_detail = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_ChotPN = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tb_giaNhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_import_detail)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_sum_bill
            // 
            this.tb_sum_bill.Location = new System.Drawing.Point(592, 444);
            this.tb_sum_bill.Name = "tb_sum_bill";
            this.tb_sum_bill.Size = new System.Drawing.Size(100, 22);
            this.tb_sum_bill.TabIndex = 44;
            this.tb_sum_bill.Text = "0\r\n";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(711, 358);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 51);
            this.button5.TabIndex = 43;
            this.button5.Text = "Thay đổi";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(711, 289);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 42);
            this.button4.TabIndex = 42;
            this.button4.Text = "Xóa";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_add_cart
            // 
            this.btn_add_cart.Location = new System.Drawing.Point(711, 215);
            this.btn_add_cart.Name = "btn_add_cart";
            this.btn_add_cart.Size = new System.Drawing.Size(89, 52);
            this.btn_add_cart.TabIndex = 41;
            this.btn_add_cart.Text = "Thêm vào giỏ hàng";
            this.btn_add_cart.UseVisualStyleBackColor = true;
            this.btn_add_cart.Click += new System.EventHandler(this.btn_add_cart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 39;
            this.label6.Text = "Nhân viên";
            // 
            // cbb_Employee
            // 
            this.cbb_Employee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Employee.FormattingEnabled = true;
            this.cbb_Employee.Location = new System.Drawing.Point(139, 36);
            this.cbb_Employee.Name = "cbb_Employee";
            this.cbb_Employee.Size = new System.Drawing.Size(92, 24);
            this.cbb_Employee.TabIndex = 38;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(676, 120);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 22);
            this.numericUpDown1.TabIndex = 37;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(610, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Số lượng";
            // 
            // cbb_Product
            // 
            this.cbb_Product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Product.FormattingEnabled = true;
            this.cbb_Product.Location = new System.Drawing.Point(576, 39);
            this.cbb_Product.Name = "cbb_Product";
            this.cbb_Product.Size = new System.Drawing.Size(175, 24);
            this.cbb_Product.TabIndex = 34;
            // 
            // cbb_Category
            // 
            this.cbb_Category.DisplayMember = "0";
            this.cbb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Category.FormattingEnabled = true;
            this.cbb_Category.Location = new System.Drawing.Point(297, 39);
            this.cbb_Category.Name = "cbb_Category";
            this.cbb_Category.Size = new System.Drawing.Size(175, 24);
            this.cbb_Category.TabIndex = 33;
            this.cbb_Category.ValueMember = "0";
            this.cbb_Category.SelectedValueChanged += new System.EventHandler(this.cbb_Category_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "Tên hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Loại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(514, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tổng tiền";
            // 
            // dgv_import_detail
            // 
            this.dgv_import_detail.AllowUserToAddRows = false;
            this.dgv_import_detail.AllowUserToDeleteRows = false;
            this.dgv_import_detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_import_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_import_detail.Location = new System.Drawing.Point(149, 153);
            this.dgv_import_detail.Name = "dgv_import_detail";
            this.dgv_import_detail.ReadOnly = true;
            this.dgv_import_detail.RowHeadersWidth = 51;
            this.dgv_import_detail.RowTemplate.Height = 24;
            this.dgv_import_detail.Size = new System.Drawing.Size(543, 268);
            this.dgv_import_detail.TabIndex = 29;
            this.dgv_import_detail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_bill_detail_CellClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(407, 478);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 49);
            this.button2.TabIndex = 28;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_ChotPN
            // 
            this.btn_ChotPN.Location = new System.Drawing.Point(270, 478);
            this.btn_ChotPN.Name = "btn_ChotPN";
            this.btn_ChotPN.Size = new System.Drawing.Size(103, 49);
            this.btn_ChotPN.TabIndex = 27;
            this.btn_ChotPN.Text = "Chốt phiếu nhập";
            this.btn_ChotPN.UseVisualStyleBackColor = true;
            this.btn_ChotPN.Click += new System.EventHandler(this.btn_ChotPN_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(149, 118);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(194, 20);
            this.radioButton1.TabIndex = 46;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Hàng này chưa có trong kho";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tb_giaNhap
            // 
            this.tb_giaNhap.Location = new System.Drawing.Point(474, 120);
            this.tb_giaNhap.Name = "tb_giaNhap";
            this.tb_giaNhap.Size = new System.Drawing.Size(100, 22);
            this.tb_giaNhap.TabIndex = 47;
            this.tb_giaNhap.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 48;
            this.label4.Text = "Giá nhập";
            // 
            // TaoPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 550);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_giaNhap);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.tb_sum_bill);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_add_cart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbb_Employee);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbb_Product);
            this.Controls.Add(this.cbb_Category);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_import_detail);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_ChotPN);
            this.Name = "TaoPhieuNhap";
            this.Text = "TaoPhieuNhap";
            this.Load += new System.EventHandler(this.TaoPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_import_detail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_sum_bill;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_add_cart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbb_Employee;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbb_Product;
        private System.Windows.Forms.ComboBox cbb_Category;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_import_detail;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_ChotPN;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox tb_giaNhap;
        private System.Windows.Forms.Label label4;
    }
}