namespace MPOS.view
{
    partial class PayForm
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.payTypeTitleLable = new System.Windows.Forms.Label();
            this.realCashLabel = new System.Windows.Forms.Label();
            this.chargeLabel = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(470, 270);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.payTypeTitleLable);
            this.panel2.Size = new System.Drawing.Size(470, 36);
            // 
            // panel3
            // 
            this.panel3.Size = new System.Drawing.Size(470, 234);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.message);
            this.panel4.Controls.Add(this.chargeLabel);
            this.panel4.Controls.Add(this.realCashLabel);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.textBox2);
            this.panel4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Size = new System.Drawing.Size(464, 228);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(108, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(147, 24);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "应收";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "实收";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "找零";
            // 
            // payTypeTitleLable
            // 
            this.payTypeTitleLable.AutoSize = true;
            this.payTypeTitleLable.Location = new System.Drawing.Point(12, 9);
            this.payTypeTitleLable.Name = "payTypeTitleLable";
            this.payTypeTitleLable.Size = new System.Drawing.Size(42, 16);
            this.payTypeTitleLable.TabIndex = 0;
            this.payTypeTitleLable.Text = "收银";
            // 
            // realCashLabel
            // 
            this.realCashLabel.AutoSize = true;
            this.realCashLabel.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.realCashLabel.ForeColor = System.Drawing.Color.Red;
            this.realCashLabel.Location = new System.Drawing.Point(101, 26);
            this.realCashLabel.Name = "realCashLabel";
            this.realCashLabel.Size = new System.Drawing.Size(77, 29);
            this.realCashLabel.TabIndex = 6;
            this.realCashLabel.Text = "0.00";
            // 
            // chargeLabel
            // 
            this.chargeLabel.AutoSize = true;
            this.chargeLabel.ForeColor = System.Drawing.Color.Red;
            this.chargeLabel.Location = new System.Drawing.Point(106, 145);
            this.chargeLabel.Name = "chargeLabel";
            this.chargeLabel.Size = new System.Drawing.Size(58, 21);
            this.chargeLabel.TabIndex = 7;
            this.chargeLabel.Text = "0.00";
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.message.ForeColor = System.Drawing.Color.Red;
            this.message.Location = new System.Drawing.Point(261, 90);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(0, 14);
            this.message.TabIndex = 8;
            // 
            // PayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 270);
            this.Name = "PayForm";
            this.Text = "CashPayForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.Label chargeLabel;
        public System.Windows.Forms.Label realCashLabel;
        public System.Windows.Forms.Label payTypeTitleLable;
        public System.Windows.Forms.Label message;
    }
}