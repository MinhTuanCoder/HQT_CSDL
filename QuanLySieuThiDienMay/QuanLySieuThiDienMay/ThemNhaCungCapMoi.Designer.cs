namespace QuanLySieuThiDienMay
{
    partial class ThemNhaCungCapMoi
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
            this.btn_update_supplier = new System.Windows.Forms.Button();
            this.btn_add_supplier = new System.Windows.Forms.Button();
            this.tb_DiaChi_NCC = new System.Windows.Forms.TextBox();
            this.tb_SDT_NCC = new System.Windows.Forms.TextBox();
            this.tb_Ten_NCC = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_update_supplier
            // 
            this.btn_update_supplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_update_supplier.Location = new System.Drawing.Point(407, 185);
            this.btn_update_supplier.Name = "btn_update_supplier";
            this.btn_update_supplier.Size = new System.Drawing.Size(75, 38);
            this.btn_update_supplier.TabIndex = 73;
            this.btn_update_supplier.Text = "Hủy";
            this.btn_update_supplier.UseVisualStyleBackColor = true;
            this.btn_update_supplier.Click += new System.EventHandler(this.btn_update_supplier_Click);
            // 
            // btn_add_supplier
            // 
            this.btn_add_supplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_add_supplier.Location = new System.Drawing.Point(260, 185);
            this.btn_add_supplier.Name = "btn_add_supplier";
            this.btn_add_supplier.Size = new System.Drawing.Size(84, 38);
            this.btn_add_supplier.TabIndex = 72;
            this.btn_add_supplier.Text = "Thêm";
            this.btn_add_supplier.UseVisualStyleBackColor = true;
            this.btn_add_supplier.Click += new System.EventHandler(this.btn_add_supplier_Click);
            // 
            // tb_DiaChi_NCC
            // 
            this.tb_DiaChi_NCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tb_DiaChi_NCC.Location = new System.Drawing.Point(488, 21);
            this.tb_DiaChi_NCC.Multiline = true;
            this.tb_DiaChi_NCC.Name = "tb_DiaChi_NCC";
            this.tb_DiaChi_NCC.Size = new System.Drawing.Size(212, 136);
            this.tb_DiaChi_NCC.TabIndex = 71;
            // 
            // tb_SDT_NCC
            // 
            this.tb_SDT_NCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tb_SDT_NCC.Location = new System.Drawing.Point(212, 72);
            this.tb_SDT_NCC.Name = "tb_SDT_NCC";
            this.tb_SDT_NCC.Size = new System.Drawing.Size(100, 27);
            this.tb_SDT_NCC.TabIndex = 70;
            // 
            // tb_Ten_NCC
            // 
            this.tb_Ten_NCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tb_Ten_NCC.Location = new System.Drawing.Point(212, 24);
            this.tb_Ten_NCC.Name = "tb_Ten_NCC";
            this.tb_Ten_NCC.Size = new System.Drawing.Size(174, 27);
            this.tb_Ten_NCC.TabIndex = 69;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label15.Location = new System.Drawing.Point(74, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 20);
            this.label15.TabIndex = 68;
            this.label15.Text = "Số điện thoại";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label14.Location = new System.Drawing.Point(403, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 20);
            this.label14.TabIndex = 67;
            this.label14.Text = "Địa chỉ ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.Location = new System.Drawing.Point(48, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 20);
            this.label13.TabIndex = 66;
            this.label13.Text = "Tên nhà cung cấp";
            // 
            // ThemNhaCungCapMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 259);
            this.Controls.Add(this.btn_update_supplier);
            this.Controls.Add(this.btn_add_supplier);
            this.Controls.Add(this.tb_DiaChi_NCC);
            this.Controls.Add(this.tb_SDT_NCC);
            this.Controls.Add(this.tb_Ten_NCC);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Name = "ThemNhaCungCapMoi";
            this.Text = "ThemNhaCungCapMoi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_update_supplier;
        private System.Windows.Forms.Button btn_add_supplier;
        private System.Windows.Forms.TextBox tb_DiaChi_NCC;
        private System.Windows.Forms.TextBox tb_SDT_NCC;
        private System.Windows.Forms.TextBox tb_Ten_NCC;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}