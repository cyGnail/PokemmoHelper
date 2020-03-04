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

            //初始化按钮
            labels = new Label[6] { label1, label2, label3, label4, label5, label6 };
            CreateButtons(OUButtons,"OU");
            CreateButtons(UUButtons,"UU");
            for (int i = 0; i < UUButtons.Length; i++)
                UUButtons[i].Btn.Visible = false;
            CreateButtons(NUButtons,"NU");
            for (int i = 0; i < NUButtons.Length; i++)
                NUButtons[i].Btn.Visible = false;
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            button_generate.BackColor = Color.Red;
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
        /// 核心按钮按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (radioButton1.Checked)
                ChoosePokemon(OUButtons);
            else if (radioButton2.Checked)
                ChoosePokemon(UUButtons);
            else if (radioButton3.Checked)
                ChoosePokemon(NUButtons);

            //选择宝可梦
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
                        {
                            if (pokemonNum < 6)
                            {
                                buttons[i].Btn.BackColor = Color.Blue;
                                buttons[i].Btn.ForeColor = Color.White;
                                pokemonNum++;
                                labels[pokemonNum - 1].Text = buttons[i].Pm.Name;
                            }
                        }
                    }
                }
            }         
        }      
    }
}
