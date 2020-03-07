namespace pokemmoHelper
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_generate = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_pm1 = new System.Windows.Forms.Button();
            this.button_pm6 = new System.Windows.Forms.Button();
            this.button_pm5 = new System.Windows.Forms.Button();
            this.button_pm4 = new System.Windows.Forms.Button();
            this.button_pm3 = new System.Windows.Forms.Button();
            this.button_pm2 = new System.Windows.Forms.Button();
            this.textBox0 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_ev = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_end = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox_type1 = new System.Windows.Forms.PictureBox();
            this.textBox_type = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox_type2 = new System.Windows.Forms.PictureBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.radioButton_ability1 = new System.Windows.Forms.RadioButton();
            this.radioButton_ability2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_type1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_type2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_generate
            // 
            this.button_generate.Font = new System.Drawing.Font("幼圆", 12F);
            this.button_generate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_generate.Location = new System.Drawing.Point(121, 919);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(150, 50);
            this.button_generate.TabIndex = 0;
            this.button_generate.Text = "生成队伍";
            this.button_generate.UseVisualStyleBackColor = true;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.radioButton1.Location = new System.Drawing.Point(51, 103);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 25);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "OU";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.radioButton2.Location = new System.Drawing.Point(178, 103);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(52, 25);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "UU";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.radioButton3.Location = new System.Drawing.Point(309, 103);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(53, 25);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "NU";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("幼圆", 12F);
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "请选择宝可梦";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("幼圆", 12F);
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "请选择宝可梦";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("幼圆", 12F);
            this.label3.Location = new System.Drawing.Point(147, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "请选择宝可梦";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("幼圆", 12F);
            this.label4.Location = new System.Drawing.Point(146, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "请选择宝可梦";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("幼圆", 12F);
            this.label5.Location = new System.Drawing.Point(280, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "请选择宝可梦";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("幼圆", 12F);
            this.label6.Location = new System.Drawing.Point(280, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "请选择宝可梦";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_pm1
            // 
            this.button_pm1.Font = new System.Drawing.Font("幼圆", 12F);
            this.button_pm1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_pm1.Location = new System.Drawing.Point(8, 15);
            this.button_pm1.Name = "button_pm1";
            this.button_pm1.Size = new System.Drawing.Size(115, 30);
            this.button_pm1.TabIndex = 10;
            this.button_pm1.Text = "button1";
            this.button_pm1.UseVisualStyleBackColor = true;
            this.button_pm1.Visible = false;
            this.button_pm1.Click += new System.EventHandler(this.button_pm1_Click);
            // 
            // button_pm6
            // 
            this.button_pm6.Font = new System.Drawing.Font("幼圆", 12F);
            this.button_pm6.Location = new System.Drawing.Point(272, 58);
            this.button_pm6.Name = "button_pm6";
            this.button_pm6.Size = new System.Drawing.Size(115, 30);
            this.button_pm6.TabIndex = 12;
            this.button_pm6.Text = "button3";
            this.button_pm6.UseVisualStyleBackColor = true;
            this.button_pm6.Visible = false;
            this.button_pm6.Click += new System.EventHandler(this.button_pm6_Click);
            // 
            // button_pm5
            // 
            this.button_pm5.Font = new System.Drawing.Font("幼圆", 12F);
            this.button_pm5.Location = new System.Drawing.Point(272, 15);
            this.button_pm5.Name = "button_pm5";
            this.button_pm5.Size = new System.Drawing.Size(115, 30);
            this.button_pm5.TabIndex = 13;
            this.button_pm5.Text = "button4";
            this.button_pm5.UseVisualStyleBackColor = true;
            this.button_pm5.Visible = false;
            this.button_pm5.Click += new System.EventHandler(this.button_pm5_Click);
            // 
            // button_pm4
            // 
            this.button_pm4.Font = new System.Drawing.Font("幼圆", 12F);
            this.button_pm4.Location = new System.Drawing.Point(141, 58);
            this.button_pm4.Name = "button_pm4";
            this.button_pm4.Size = new System.Drawing.Size(115, 30);
            this.button_pm4.TabIndex = 14;
            this.button_pm4.Text = "button5";
            this.button_pm4.UseVisualStyleBackColor = true;
            this.button_pm4.Visible = false;
            this.button_pm4.Click += new System.EventHandler(this.button_pm4_Click);
            // 
            // button_pm3
            // 
            this.button_pm3.Font = new System.Drawing.Font("幼圆", 12F);
            this.button_pm3.Location = new System.Drawing.Point(141, 15);
            this.button_pm3.Name = "button_pm3";
            this.button_pm3.Size = new System.Drawing.Size(115, 30);
            this.button_pm3.TabIndex = 15;
            this.button_pm3.Text = "button6";
            this.button_pm3.UseVisualStyleBackColor = true;
            this.button_pm3.Visible = false;
            this.button_pm3.Click += new System.EventHandler(this.button_pm3_Click);
            // 
            // button_pm2
            // 
            this.button_pm2.Font = new System.Drawing.Font("幼圆", 12F);
            this.button_pm2.Location = new System.Drawing.Point(8, 58);
            this.button_pm2.Name = "button_pm2";
            this.button_pm2.Size = new System.Drawing.Size(115, 30);
            this.button_pm2.TabIndex = 16;
            this.button_pm2.Text = "button7";
            this.button_pm2.UseVisualStyleBackColor = true;
            this.button_pm2.Visible = false;
            this.button_pm2.Click += new System.EventHandler(this.button_pm2_Click);
            // 
            // textBox0
            // 
            this.textBox0.Font = new System.Drawing.Font("幼圆", 10F);
            this.textBox0.Location = new System.Drawing.Point(8, 103);
            this.textBox0.Multiline = true;
            this.textBox0.Name = "textBox0";
            this.textBox0.ReadOnly = true;
            this.textBox0.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox0.Size = new System.Drawing.Size(191, 184);
            this.textBox0.TabIndex = 17;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("幼圆", 10F);
            this.textBox1.Location = new System.Drawing.Point(199, 103);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(188, 184);
            this.textBox1.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 293);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_ev
            // 
            this.textBox_ev.Font = new System.Drawing.Font("幼圆", 12F);
            this.textBox_ev.Location = new System.Drawing.Point(178, 293);
            this.textBox_ev.Multiline = true;
            this.textBox_ev.Name = "textBox_ev";
            this.textBox_ev.ReadOnly = true;
            this.textBox_ev.Size = new System.Drawing.Size(108, 160);
            this.textBox_ev.TabIndex = 20;
            this.textBox_ev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("幼圆", 12F);
            this.label7.Location = new System.Drawing.Point(318, 296);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "特 性";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("幼圆", 12F);
            this.label8.Location = new System.Drawing.Point(318, 409);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 24;
            this.label8.Text = "道 具";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("幼圆", 12F);
            this.label9.Location = new System.Drawing.Point(5, 548);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 16);
            this.label9.TabIndex = 26;
            this.label9.Text = "常 用 技 能";
            // 
            // button_end
            // 
            this.button_end.Font = new System.Drawing.Font("幼圆", 12F);
            this.button_end.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_end.Location = new System.Drawing.Point(121, 919);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(150, 50);
            this.button_end.TabIndex = 27;
            this.button_end.Text = "结束战斗";
            this.button_end.UseVisualStyleBackColor = true;
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("幼圆", 12F);
            this.label10.Location = new System.Drawing.Point(5, 457);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "属 性";
            // 
            // pictureBox_type1
            // 
            this.pictureBox_type1.Location = new System.Drawing.Point(8, 477);
            this.pictureBox_type1.Name = "pictureBox_type1";
            this.pictureBox_type1.Size = new System.Drawing.Size(106, 33);
            this.pictureBox_type1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_type1.TabIndex = 29;
            this.pictureBox_type1.TabStop = false;
            // 
            // textBox_type
            // 
            this.textBox_type.Font = new System.Drawing.Font("幼圆", 10F);
            this.textBox_type.Location = new System.Drawing.Point(178, 460);
            this.textBox_type.Multiline = true;
            this.textBox_type.Name = "textBox_type";
            this.textBox_type.ReadOnly = true;
            this.textBox_type.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_type.Size = new System.Drawing.Size(209, 84);
            this.textBox_type.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("幼圆", 12F);
            this.label11.Location = new System.Drawing.Point(122, 500);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 32;
            this.label11.Text = "抗 性";
            // 
            // pictureBox_type2
            // 
            this.pictureBox_type2.Location = new System.Drawing.Point(8, 511);
            this.pictureBox_type2.Name = "pictureBox_type2";
            this.pictureBox_type2.Size = new System.Drawing.Size(106, 33);
            this.pictureBox_type2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_type2.TabIndex = 33;
            this.pictureBox_type2.TabStop = false;
            // 
            // comboBox
            // 
            this.comboBox.AllowDrop = true;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.Font = new System.Drawing.Font("幼圆", 9F);
            this.comboBox.FormattingEnabled = true;
            this.comboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox.Items.AddRange(new object[] {
            "无影响(已消耗)",
            "生命宝珠",
            "属性宝石",
            "讲究眼镜/头带",
            "讲究围巾",
            "进化奇石",
            "剩饭",
            "黑色污泥",
            "树果",
            "丝绸围巾(等)",
            "后攻之尾",
            "气势披带",
            "贝壳之铃",
            "美丽空壳",
            "天气石",
            "光之黏土",
            "心灵香草",
            "火焰宝珠",
            "剧毒宝珠",
            "广角镜",
            "红牌"});
            this.comboBox.Location = new System.Drawing.Point(292, 433);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(95, 20);
            this.comboBox.TabIndex = 34;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // radioButton_ability1
            // 
            this.radioButton_ability1.AutoSize = true;
            this.radioButton_ability1.Checked = true;
            this.radioButton_ability1.Font = new System.Drawing.Font("幼圆", 12F);
            this.radioButton_ability1.Location = new System.Drawing.Point(304, 329);
            this.radioButton_ability1.Name = "radioButton_ability1";
            this.radioButton_ability1.Size = new System.Drawing.Size(122, 20);
            this.radioButton_ability1.TabIndex = 35;
            this.radioButton_ability1.TabStop = true;
            this.radioButton_ability1.Text = "radioButton4";
            this.radioButton_ability1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton_ability1.UseVisualStyleBackColor = true;
            this.radioButton_ability1.CheckedChanged += new System.EventHandler(this.radioButton_ability1_CheckedChanged);
            // 
            // radioButton_ability2
            // 
            this.radioButton_ability2.AutoSize = true;
            this.radioButton_ability2.Font = new System.Drawing.Font("幼圆", 12F);
            this.radioButton_ability2.Location = new System.Drawing.Point(304, 364);
            this.radioButton_ability2.Name = "radioButton_ability2";
            this.radioButton_ability2.Size = new System.Drawing.Size(122, 20);
            this.radioButton_ability2.TabIndex = 36;
            this.radioButton_ability2.Text = "radioButton5";
            this.radioButton_ability2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton_ability2.UseVisualStyleBackColor = true;
            this.radioButton_ability2.CheckedChanged += new System.EventHandler(this.radioButton_ability2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 976);
            this.Controls.Add(this.radioButton_ability2);
            this.Controls.Add(this.radioButton_ability1);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.pictureBox_type2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_type);
            this.Controls.Add(this.pictureBox_type1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_end);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_ev);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox0);
            this.Controls.Add(this.button_pm2);
            this.Controls.Add(this.button_pm3);
            this.Controls.Add(this.button_pm4);
            this.Controls.Add(this.button_pm5);
            this.Controls.Add(this.button_pm6);
            this.Controls.Add(this.button_pm1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button_generate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Pokemmo对战助手";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_type1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_type2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_pm1;
        private System.Windows.Forms.Button button_pm6;
        private System.Windows.Forms.Button button_pm5;
        private System.Windows.Forms.Button button_pm4;
        private System.Windows.Forms.Button button_pm3;
        private System.Windows.Forms.Button button_pm2;
        private System.Windows.Forms.TextBox textBox0;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_ev;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_end;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox_type1;
        private System.Windows.Forms.TextBox textBox_type;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox_type2;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.RadioButton radioButton_ability1;
        private System.Windows.Forms.RadioButton radioButton_ability2;
    }
}

