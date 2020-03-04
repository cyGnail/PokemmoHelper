using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemmoHelper
{
    public partial class Form1 : Form
    {
        private static Label[] labels;
        private static Button[] bu_ttons;
        private static ButtonWithPokemon[] pokemonButtons = new ButtonWithPokemon[6];
        private static int pokemonNum = 0;

        private const int OUNum = 41;
        private const int UUNum = 59;
        private const int NUNum = 50;
        private static ButtonWithPokemon[] OUButtons = new ButtonWithPokemon[OUNum];
        private static ButtonWithPokemon[] UUButtons = new ButtonWithPokemon[UUNum];
        private static ButtonWithPokemon[] NUButtons = new ButtonWithPokemon[NUNum];

        public Form1()
        {
            InitializeComponent();

            //初始化数组
            labels = new Label[6] { label1, label2, label3, label4, label5, label6 };
            bu_ttons = new Button[6] { button_pm1, button_pm2, button_pm3, button_pm4, button_pm5, button_pm6 };
            for (int i = 0; i < 6; i++)
            {
                pokemonButtons[i].Btn = bu_ttons[i];
                pokemonButtons[i].Btn.BackColor = Color.Empty;
                pokemonButtons[i].Pm = new Pokemon();
            }  

            //初始化按钮
            CreateButtons(OUButtons,"OU");
            CreateButtons(UUButtons,"UU");
            CreateButtons(NUButtons,"NU");

            UpdateInitialForm();
        }


        /// <summary>
        /// 进入队伍界面初始化
        /// </summary>
        private void button_generate_Click(object sender, EventArgs e)
        {
            if (pokemonNum == 6)
            {
                button_generate.Visible = false;
                button_end.Visible = true;
                for (int i = 0; i < 6; i++)
                    labels[i].Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                if (radioButton1.Checked)
                    for (int i = 0; i < OUNum; i++)
                        OUButtons[i].Btn.Visible = false;
                else if (radioButton2.Checked)
                    for (int i = 0; i < UUNum; i++)
                        UUButtons[i].Btn.Visible = false;
                else if (radioButton3.Checked)
                    for (int i = 0; i < NUNum; i++)
                        NUButtons[i].Btn.Visible = false;
                for (int i = 0; i < 6; i++)
                    pokemonButtons[i].Btn.Visible = true;
                textBox.Visible = true;
                textBox1.Visible = true;
            }
            else
                MessageBox.Show("未选满6只宝可梦！");
        }


        /// <summary>
        /// 生成宝可梦选择按钮
        /// </summary>
        private void CreateButtons(ButtonWithPokemon[] buttons, string str)               
        {
            const int buttonLength = 90;
            const int buttonWidth = 40;
            const int buttonInterval = 8;
            Point[] points = new Point[60];
            for (int i = 0; i < 60; i++)
                points[i] = new Point(8 + i % 4 * (buttonLength + buttonInterval), 130 + i / 4 * (buttonWidth + buttonInterval));
                      
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Pm = new Pokemon();
                buttons[i].Btn = new Button();
                buttons[i].Btn.Location = points[i];
                buttons[i].Btn.Size = new Size(buttonLength, buttonWidth);
                buttons[i].Btn.Name = string.Format("{0}button_{1}",str,i);
                buttons[i].Btn.BackColor = Color.Empty;
                buttons[i].Btn.Text = buttons[i].Pm.Name;
                buttons[i].Btn.Parent = this;
                this.Controls.Add(buttons[i].Btn);
                buttons[i].Btn.Click += new EventHandler(Btn_Click);
            }
        }


        /// <summary>
        /// 分级复选框
        /// </summary>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                for (int i = 0; i < OUNum; i++)
                    OUButtons[i].Btn.Visible = true;
                for (int i = 0; i < UUNum; i++)
                    UUButtons[i].Btn.Visible = false;
                for (int i = 0; i < NUNum; i++)
                    NUButtons[i].Btn.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                for (int i = 0; i < OUNum; i++)
                    OUButtons[i].Btn.Visible = false;
                for (int i = 0; i < UUNum; i++)
                    UUButtons[i].Btn.Visible = true;
                for (int i = 0; i < NUNum; i++)
                    NUButtons[i].Btn.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                for (int i = 0; i < OUNum; i++)
                    OUButtons[i].Btn.Visible = false;
                for (int i = 0; i < UUNum; i++)
                    UUButtons[i].Btn.Visible = false;
                for (int i = 0; i < NUNum; i++)
                    NUButtons[i].Btn.Visible = true;
            }
        }
        

        /// <summary>
        /// 初始界面核心按钮按下事件
        /// </summary>
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (radioButton1.Checked)
                ChoosePokemon(OUButtons);
            else if (radioButton2.Checked)
                ChoosePokemon(UUButtons);
            else if (radioButton3.Checked)
                ChoosePokemon(NUButtons);

            //选择宝可梦放入队伍
            void ChoosePokemon(ButtonWithPokemon[] buttons)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (btn.Name == buttons[i].Btn.Name)
                    {
                        if (buttons[i].Btn.BackColor == Color.Blue)
                        {
                            buttons[i].Btn.BackColor = Color.Empty;
                            buttons[i].Btn.ForeColor = Color.Black;
                            pokemonNum--;
                            for (int j = 5; j >= 0; j--)
                                if (labels[j].Text == buttons[i].Pm.Name)
                                {
                                    labels[j].Text = "请选择宝可梦";
                                    break;
                                }
                        }
                        else
                            if (pokemonNum < 6)
                            {
                                buttons[i].Btn.BackColor = Color.Blue;
                                buttons[i].Btn.ForeColor = Color.White;
                                pokemonNum++;
                                labels[pokemonNum - 1].Text = buttons[i].Pm.Name;
                                pokemonButtons[pokemonNum - 1].Pm = buttons[i].Pm;
                                pokemonButtons[pokemonNum - 1].Btn.Text = pokemonButtons[pokemonNum - 1].Pm.Name;
                            }
                    }
                }
            }         
        }


        /// <summary>
        /// 选择宝可梦查看详情
        /// </summary>
        private void UpdateFormToPokemon()
        {
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            textBox_ev.Visible = true;
            textBox_type.Visible = true;
            pictureBox1.Visible = true;
            pictureBox_type1.Visible = true;
            pictureBox_type2.Visible = true;
            radioButton_ability1.Visible = true;
            radioButton_ability2.Visible = true;
            comboBox.Visible = true;
        }

        private void button_pm1_Click(object sender, EventArgs e)
        {
            UpdateFormToPokemon();
        }

        private void button_pm2_Click(object sender, EventArgs e)
        {
            UpdateFormToPokemon();
        }

        private void button_pm3_Click(object sender, EventArgs e)
        {
            UpdateFormToPokemon();
        }

        private void button_pm4_Click(object sender, EventArgs e)
        {
            UpdateFormToPokemon();
        }

        private void button_pm5_Click(object sender, EventArgs e)
        {
            UpdateFormToPokemon();
        }

        private void button_pm6_Click(object sender, EventArgs e)
        {
            UpdateFormToPokemon();
        }

        private void button_end_Click(object sender, EventArgs e)
        {
            UpdateInitialForm();
            button_generate.Visible = true;
        }

        private void UpdateInitialForm()
        {
            //隐藏控件
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            pictureBox1.Visible = false;
            pictureBox_type1.Visible = false;
            pictureBox_type2.Visible = false;
            textBox.Visible = false;
            textBox1.Visible = false;
            textBox_ev.Visible = false;
            textBox_type.Visible = false;
            button_end.Visible = false;
            comboBox.Visible = false;
            radioButton_ability1.Visible = false;
            radioButton_ability2.Visible = false;

            //选择项刷新
            for (int i = 0; i < OUButtons.Length; i++)
            {
                OUButtons[i].Btn.Visible = true;
                OUButtons[i].Btn.BackColor = Color.Empty;
                OUButtons[i].Btn.ForeColor = Color.Black;
            }
            for (int i = 0; i < UUButtons.Length; i++)
            {
                UUButtons[i].Btn.Visible = false;
                UUButtons[i].Btn.BackColor = Color.Empty;
                UUButtons[i].Btn.ForeColor = Color.Black;
            }
            for (int i = 0; i < NUButtons.Length; i++)
            {
                NUButtons[i].Btn.Visible = false;
                NUButtons[i].Btn.BackColor = Color.Empty;
                NUButtons[i].Btn.ForeColor = Color.Black;
            }

            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false; ;

            pokemonNum = 0;

            for (int i = 0; i < 6; i++)
            {
                labels[i].Text = "请选择宝可梦";
                labels[i].Visible = true;
                bu_ttons[i].Visible = false;
            }
        }
    }
}
