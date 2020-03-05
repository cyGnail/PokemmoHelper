using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
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
        private const int UUNum = 64;
        private const int NUNum = 47;
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

            //导入json数据
            ImportJson(Pokemon.OUPokemons, "OU");
            ImportJson(Pokemon.UUPokemons, "UU");
            ImportJson(Pokemon.NUPokemons, "NU");

            //初始化按钮
            CreateButtons(OUButtons, Pokemon.OUPokemons, "OU");
            CreateButtons(UUButtons, Pokemon.UUPokemons, "UU");
            CreateButtons(NUButtons, Pokemon.NUPokemons, "NU");

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
        private void CreateButtons(ButtonWithPokemon[] buttons, List<Pokemon> pl, string str)  
        {
            const int buttonLength = 90;
            const int buttonWidth = 40;
            const int buttonInterval = 8;
            Point[] points = new Point[64];
            for (int i = 0; i < 64; i++)
                points[i] = new Point(buttonInterval + i % 4 * (buttonLength + buttonInterval), 130 + i / 4 * (buttonWidth + buttonInterval));
                      
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i < pl.Count)
                    buttons[i].Pm = pl[i];
                else
                    buttons[i].Pm = new Pokemon();

                buttons[i].Btn = new Button();
                buttons[i].Btn.Location = points[i];
                buttons[i].Btn.Size = new Size(buttonLength, buttonWidth);
                buttons[i].Btn.Name = string.Format("{0}button_{1}",str,i);
                buttons[i].Btn.BackColor = Color.Empty;
                buttons[i].Btn.Text = buttons[i].Pm.Name;
                buttons[i].Btn.Font = new Font("幼圆", 12);
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
                                for (int j = 0; j < 6; j++)
                                    if (labels[j].Text == "请选择宝可梦")
                                    {
                                        labels[j].Text = buttons[i].Pm.Name;
                                        break;
                                    }
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
        private void UpdateFormToPokemon(ButtonWithPokemon bwp)
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
            textBox_ev.Text =
                string.Format("种族值\r\n\r\nHP：{0}\r\n攻击：{1}\r\n防御：{2}\r\n特攻：{3}\r\n特防：{4}\r\n速度：{5}\r\n总和：{6}",
                bwp.Pm.MyEthnicValue.HP, bwp.Pm.MyEthnicValue.AT, bwp.Pm.MyEthnicValue.DF, bwp.Pm.MyEthnicValue.SA,
                bwp.Pm.MyEthnicValue.SD, bwp.Pm.MyEthnicValue.SP, bwp.Pm.MyEthnicValue.total);
        }

        private void button_pm1_Click(object sender, EventArgs e)
        {
            UpdateFormToPokemon(pokemonButtons[0]);
        }

        private void button_pm2_Click(object sender, EventArgs e)
        {
            UpdateFormToPokemon(pokemonButtons[1]);
        }

        private void button_pm3_Click(object sender, EventArgs e)
        {
            UpdateFormToPokemon(pokemonButtons[2]);
        }

        private void button_pm4_Click(object sender, EventArgs e)
        {
            UpdateFormToPokemon(pokemonButtons[3]);
        }

        private void button_pm5_Click(object sender, EventArgs e)
        {
            UpdateFormToPokemon(pokemonButtons[4]);
        }

        private void button_pm6_Click(object sender, EventArgs e)
        {
            UpdateFormToPokemon(pokemonButtons[5]);
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

        /// <summary>
        /// 遍历文件夹
        /// </summary>
        /// <param name="dir1"></param>
        public static List<string> GetAllDir(string dir1)
        {
            List<string> list = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(dir1);
            FileInfo[] fileInfo = dir.GetFiles();

            for (int i = 0; i < fileInfo.Length; i++)
                list.Add(fileInfo[i].FullName);

            return list;
        }

        public static void ImportJson(List<Pokemon> pl, string str)
        {
            List<string> jsonList = GetAllDir(System.Environment.CurrentDirectory + string.Format(@"\src\{0}\", str));
            for (int i = 0; i < jsonList.Count; i++) 
            {
                StreamReader sr = new StreamReader(jsonList[i]);
                string jsonText = sr.ReadToEnd();
                pl.Add(new Pokemon());
                Newtonsoft.Json.Linq.JObject jobject = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonText);
                pl[i].Name = jobject["官方译名"].ToString();
                pl[i].Index = jobject["编号"].ToString();
                pl[i].MyEthnicValue.HP = Convert.ToInt16(jobject["种族值"]["HP"]);
                pl[i].MyEthnicValue.AT = Convert.ToInt16(jobject["种族值"]["攻击"]);
                pl[i].MyEthnicValue.DF = Convert.ToInt16(jobject["种族值"]["防御"]);
                pl[i].MyEthnicValue.SA = Convert.ToInt16(jobject["种族值"]["特攻"]);
                pl[i].MyEthnicValue.SD = Convert.ToInt16(jobject["种族值"]["特防"]);
                pl[i].MyEthnicValue.SP = Convert.ToInt16(jobject["种族值"]["速度"]);
                pl[i].MyEthnicValue.total = Convert.ToInt16(jobject["种族值"]["总和"]);
            }
        }
    }
}
