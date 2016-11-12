namespace MPOS.view
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.centerPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.shopCodeLabel = new System.Windows.Forms.Label();
            this.cashierLabel = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.orderCodeLabel = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.buttomPanel = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lastDisAmountLabel = new System.Windows.Forms.Label();
            this.lastCountLabel = new System.Windows.Forms.Label();
            this.lastAmountLabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.currentProductUnit = new System.Windows.Forms.Label();
            this.currentProductNameLabel = new System.Windows.Forms.Label();
            this.currentProductPriceLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.barcodeInput = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.disamountLabel = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.ipAddressLabel = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.Label();
            this.netStateImage = new System.Windows.Forms.PictureBox();
            this.mainPanel.SuspendLayout();
            this.centerPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.buttomPanel.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netStateImage)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(224)))), ((int)(((byte)(253)))));
            this.mainPanel.Controls.Add(this.centerPanel);
            this.mainPanel.Controls.Add(this.buttomPanel);
            this.mainPanel.Controls.Add(this.titlePanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 562);
            this.mainPanel.TabIndex = 0;
            // 
            // centerPanel
            // 
            this.centerPanel.Controls.Add(this.panel1);
            this.centerPanel.Controls.Add(this.panel2);
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point(0, 41);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(1000, 399);
            this.centerPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 322);
            this.panel1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.price,
            this.count,
            this.discount,
            this.disprice,
            this.amount,
            this.disamount});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(224)))), ((int)(((byte)(253)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1000, 322);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "商品名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 300;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "单价(元)";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // count
            // 
            this.count.DataPropertyName = "count";
            this.count.HeaderText = "数量";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // discount
            // 
            this.discount.DataPropertyName = "discount";
            this.discount.HeaderText = "折扣(%)";
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            // 
            // disprice
            // 
            this.disprice.DataPropertyName = "disprice";
            this.disprice.HeaderText = "折后单价(元)";
            this.disprice.Name = "disprice";
            this.disprice.ReadOnly = true;
            this.disprice.Width = 120;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "小计";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // disamount
            // 
            this.disamount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.disamount.DataPropertyName = "disamount";
            this.disamount.HeaderText = "优惠";
            this.disamount.Name = "disamount";
            this.disamount.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(1000, 77);
            this.panel2.TabIndex = 2;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Controls.Add(this.shopCodeLabel);
            this.panel11.Controls.Add(this.cashierLabel);
            this.panel11.Controls.Add(this.label31);
            this.panel11.Controls.Add(this.label30);
            this.panel11.Controls.Add(this.dateLabel);
            this.panel11.Controls.Add(this.orderCodeLabel);
            this.panel11.Controls.Add(this.label27);
            this.panel11.Controls.Add(this.label26);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel11.ForeColor = System.Drawing.Color.DimGray;
            this.panel11.Location = new System.Drawing.Point(5, 5);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(3);
            this.panel11.Size = new System.Drawing.Size(764, 67);
            this.panel11.TabIndex = 3;
            // 
            // shopCodeLabel
            // 
            this.shopCodeLabel.AutoSize = true;
            this.shopCodeLabel.Location = new System.Drawing.Point(70, 10);
            this.shopCodeLabel.Name = "shopCodeLabel";
            this.shopCodeLabel.Size = new System.Drawing.Size(44, 16);
            this.shopCodeLabel.TabIndex = 23;
            this.shopCodeLabel.Text = "1001";
            // 
            // cashierLabel
            // 
            this.cashierLabel.AutoSize = true;
            this.cashierLabel.Location = new System.Drawing.Point(70, 40);
            this.cashierLabel.Name = "cashierLabel";
            this.cashierLabel.Size = new System.Drawing.Size(42, 16);
            this.cashierLabel.TabIndex = 22;
            this.cashierLabel.Text = "张三";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(3, 39);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(68, 16);
            this.label31.TabIndex = 20;
            this.label31.Text = "收银员:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(4, 11);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(69, 16);
            this.label30.TabIndex = 19;
            this.label30.Text = "门  店:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(248, 42);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(122, 16);
            this.dateLabel.TabIndex = 14;
            this.dateLabel.Text = "2016年3月24日";
            // 
            // orderCodeLabel
            // 
            this.orderCodeLabel.AutoSize = true;
            this.orderCodeLabel.Location = new System.Drawing.Point(247, 13);
            this.orderCodeLabel.Name = "orderCodeLabel";
            this.orderCodeLabel.Size = new System.Drawing.Size(233, 16);
            this.orderCodeLabel.TabIndex = 13;
            this.orderCodeLabel.Text = "2016101700231001100300001";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(187, 42);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(77, 16);
            this.label27.TabIndex = 12;
            this.label27.Text = "日  期：";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(186, 14);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(76, 16);
            this.label26.TabIndex = 11;
            this.label26.Text = "单据号：";
            // 
            // buttomPanel
            // 
            this.buttomPanel.BackColor = System.Drawing.Color.Transparent;
            this.buttomPanel.Controls.Add(this.panel7);
            this.buttomPanel.Controls.Add(this.panel6);
            this.buttomPanel.Controls.Add(this.panel5);
            this.buttomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttomPanel.Location = new System.Drawing.Point(0, 440);
            this.buttomPanel.Name = "buttomPanel";
            this.buttomPanel.Padding = new System.Windows.Forms.Padding(5);
            this.buttomPanel.Size = new System.Drawing.Size(1000, 122);
            this.buttomPanel.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(239)))));
            this.panel7.Controls.Add(this.panel4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.ForeColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(328, 5);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(3);
            this.panel7.Size = new System.Drawing.Size(199, 112);
            this.panel7.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(224)))), ((int)(((byte)(253)))));
            this.panel4.Controls.Add(this.lastDisAmountLabel);
            this.panel4.Controls.Add(this.lastCountLabel);
            this.panel4.Controls.Add(this.lastAmountLabel);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(193, 106);
            this.panel4.TabIndex = 0;
            // 
            // lastDisAmountLabel
            // 
            this.lastDisAmountLabel.AutoSize = true;
            this.lastDisAmountLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lastDisAmountLabel.Location = new System.Drawing.Point(92, 79);
            this.lastDisAmountLabel.Name = "lastDisAmountLabel";
            this.lastDisAmountLabel.Size = new System.Drawing.Size(39, 14);
            this.lastDisAmountLabel.TabIndex = 5;
            this.lastDisAmountLabel.Text = "0.00";
            // 
            // lastCountLabel
            // 
            this.lastCountLabel.AutoSize = true;
            this.lastCountLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lastCountLabel.Location = new System.Drawing.Point(91, 45);
            this.lastCountLabel.Name = "lastCountLabel";
            this.lastCountLabel.Size = new System.Drawing.Size(15, 14);
            this.lastCountLabel.TabIndex = 4;
            this.lastCountLabel.Text = "0";
            // 
            // lastAmountLabel
            // 
            this.lastAmountLabel.AutoSize = true;
            this.lastAmountLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lastAmountLabel.ForeColor = System.Drawing.Color.Red;
            this.lastAmountLabel.Location = new System.Drawing.Point(90, 7);
            this.lastAmountLabel.Name = "lastAmountLabel";
            this.lastAmountLabel.Size = new System.Drawing.Size(62, 24);
            this.lastAmountLabel.TabIndex = 3;
            this.lastAmountLabel.Text = "0.00";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(14, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 14);
            this.label18.TabIndex = 2;
            this.label18.Text = "上单优惠：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "上单数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "上单合计：";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(239)))));
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(5, 5);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.panel6.Size = new System.Drawing.Size(323, 112);
            this.panel6.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(224)))), ((int)(((byte)(253)))));
            this.panel3.Controls.Add(this.currentProductUnit);
            this.panel3.Controls.Add(this.currentProductNameLabel);
            this.panel3.Controls.Add(this.currentProductPriceLabel);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.barcodeInput);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 106);
            this.panel3.TabIndex = 0;
            // 
            // currentProductUnit
            // 
            this.currentProductUnit.AutoSize = true;
            this.currentProductUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentProductUnit.Location = new System.Drawing.Point(50, 79);
            this.currentProductUnit.Name = "currentProductUnit";
            this.currentProductUnit.Size = new System.Drawing.Size(21, 14);
            this.currentProductUnit.TabIndex = 15;
            this.currentProductUnit.Text = "瓶";
            // 
            // currentProductNameLabel
            // 
            this.currentProductNameLabel.AutoSize = true;
            this.currentProductNameLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentProductNameLabel.Location = new System.Drawing.Point(45, 47);
            this.currentProductNameLabel.Name = "currentProductNameLabel";
            this.currentProductNameLabel.Size = new System.Drawing.Size(21, 14);
            this.currentProductNameLabel.TabIndex = 14;
            this.currentProductNameLabel.Text = "无";
            // 
            // currentProductPriceLabel
            // 
            this.currentProductPriceLabel.AutoSize = true;
            this.currentProductPriceLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentProductPriceLabel.ForeColor = System.Drawing.Color.Red;
            this.currentProductPriceLabel.Location = new System.Drawing.Point(148, 73);
            this.currentProductPriceLabel.Name = "currentProductPriceLabel";
            this.currentProductPriceLabel.Size = new System.Drawing.Size(62, 24);
            this.currentProductPriceLabel.TabIndex = 13;
            this.currentProductPriceLabel.Text = "0.00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(110, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 14);
            this.label11.TabIndex = 12;
            this.label11.Text = "单价：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 11;
            this.label10.Text = "规格：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 10;
            this.label9.Text = "品名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "条码：";
            // 
            // barcodeInput
            // 
            this.barcodeInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.barcodeInput.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barcodeInput.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.barcodeInput.Location = new System.Drawing.Point(58, 7);
            this.barcodeInput.Name = "barcodeInput";
            this.barcodeInput.Size = new System.Drawing.Size(250, 24);
            this.barcodeInput.TabIndex = 6;
            this.barcodeInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.barcodeInput_KeyPress);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(239)))));
            this.panel5.Controls.Add(this.disamountLabel);
            this.panel5.Controls.Add(this.label24);
            this.panel5.Controls.Add(this.countLabel);
            this.panel5.Controls.Add(this.label22);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.amountLabel);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel5.Location = new System.Drawing.Point(656, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(339, 112);
            this.panel5.TabIndex = 0;
            // 
            // disamountLabel
            // 
            this.disamountLabel.AutoSize = true;
            this.disamountLabel.Location = new System.Drawing.Point(214, 76);
            this.disamountLabel.Name = "disamountLabel";
            this.disamountLabel.Size = new System.Drawing.Size(54, 21);
            this.disamountLabel.TabIndex = 9;
            this.disamountLabel.Text = "0.00";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(135, 76);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(94, 21);
            this.label24.TabIndex = 8;
            this.label24.Text = "共优惠：";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(81, 77);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(21, 21);
            this.countLabel.TabIndex = 7;
            this.countLabel.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 76);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 21);
            this.label22.TabIndex = 6;
            this.label22.Text = "数量：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(346, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "————————————————";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.amountLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.amountLabel.Location = new System.Drawing.Point(150, 20);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(77, 29);
            this.amountLabel.TabIndex = 4;
            this.amountLabel.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(114, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 29);
            this.label7.TabIndex = 3;
            this.label7.Text = "￥";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(93, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 35);
            this.label6.TabIndex = 2;
            this.label6.Text = "|";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(4, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 35);
            this.label4.TabIndex = 0;
            this.label4.Text = "结算";
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(239)))));
            this.titlePanel.Controls.Add(this.panel9);
            this.titlePanel.Controls.Add(this.panel8);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(1000, 41);
            this.titlePanel.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.netStateImage);
            this.panel9.Controls.Add(this.ipAddressLabel);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel9.Location = new System.Drawing.Point(511, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(5);
            this.panel9.Size = new System.Drawing.Size(489, 41);
            this.panel9.TabIndex = 1;
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Location = new System.Drawing.Point(317, 14);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(160, 16);
            this.ipAddressLabel.TabIndex = 0;
            this.ipAddressLabel.Text = "IP：192.168.0.231";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.logo);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(485, 41);
            this.panel8.TabIndex = 0;
            // 
            // logo
            // 
            this.logo.AutoSize = true;
            this.logo.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.logo.Location = new System.Drawing.Point(3, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(157, 19);
            this.logo.TabIndex = 0;
            this.logo.Text = "美乐美ERP-MPOS";
            // 
            // netStateImage
            // 
            this.netStateImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.netStateImage.Image = global::MPOS.Properties.Resources.net;
            this.netStateImage.InitialImage = global::MPOS.Properties.Resources.net;
            this.netStateImage.Location = new System.Drawing.Point(279, 6);
            this.netStateImage.Name = "netStateImage";
            this.netStateImage.Size = new System.Drawing.Size(38, 31);
            this.netStateImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.netStateImage.TabIndex = 1;
            this.netStateImage.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "美乐美收银POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.centerPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.buttomPanel.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.titlePanel.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netStateImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel mainPanel;
        public System.Windows.Forms.Panel centerPanel;
        public System.Windows.Forms.Panel buttomPanel;
        public System.Windows.Forms.Panel titlePanel;
        public System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox barcodeInput;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel panel8;
        public System.Windows.Forms.Label logo;
        public System.Windows.Forms.Panel panel9;
        public System.Windows.Forms.Label ipAddressLabel;
        public System.Windows.Forms.Label currentProductUnit;
        public System.Windows.Forms.Label currentProductNameLabel;
        public System.Windows.Forms.Label currentProductPriceLabel;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label18;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lastDisAmountLabel;
        public System.Windows.Forms.Label lastCountLabel;
        public System.Windows.Forms.Label lastAmountLabel;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Label amountLabel;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label label24;
        public System.Windows.Forms.Label countLabel;
        public System.Windows.Forms.Label disamountLabel;
        public System.Windows.Forms.Panel panel11;
        public System.Windows.Forms.Label dateLabel;
        public System.Windows.Forms.Label orderCodeLabel;
        public System.Windows.Forms.Label label27;
        public System.Windows.Forms.Label label26;
        public System.Windows.Forms.Label label31;
        public System.Windows.Forms.Label label30;
        public System.Windows.Forms.Label cashierLabel;
        public System.Windows.Forms.Label shopCodeLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn disprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn disamount;
        public System.Windows.Forms.PictureBox netStateImage;
    }
}