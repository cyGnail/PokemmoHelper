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
        private static int[] fourMoves = new int[6] { 0, 0, 0, 0, 0, 0 };

        private const int OUNum = 41;
        private const int UUNum = 62;
        private const int NUNum = 47;
        private const int DNNum = 64;
        private static ButtonWithPokemon[] OUButtons = new ButtonWithPokemon[OUNum];
        private static ButtonWithPokemon[] UUButtons = new ButtonWithPokemon[UUNum];
        private static ButtonWithPokemon[] NUButtons = new ButtonWithPokemon[NUNum];
        private static ButtonWithPokemon[] DNButtons = new ButtonWithPokemon[DNNum];

        private static MyPokemon[] myPokemons = new MyPokemon[6];

        private static int lastClick = 1;     //队伍界面最后一次点击按钮编号

        private static bool ifFirst = true;   //是否在第一界面

        private const int moveNum = 60;

        private static Button[][] moveButtons = new Button[6][] { new Button[moveNum], new Button[moveNum], new Button[moveNum], new Button[moveNum], new Button[moveNum], new Button[moveNum] };

        public Form1()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(0, 0);

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
            ImportJson(Pokemon.DNPokemons, "DN");


            //道具列表
            comboBox.SelectedIndex = 0;

            //初始化按钮
            CreateButtons(OUButtons, Pokemon.OUPokemons, "OU");
            CreateButtons(UUButtons, Pokemon.UUPokemons, "UU");
            CreateButtons(NUButtons, Pokemon.NUPokemons, "NU");
            CreateButtons(DNButtons, Pokemon.DNPokemons, "DN");

            //初始化技能按钮
            CreateButtonsAgain(moveButtons[0], "p1");
            CreateButtonsAgain(moveButtons[1], "p2");
            CreateButtonsAgain(moveButtons[2], "p3");
            CreateButtonsAgain(moveButtons[3], "p4");
            CreateButtonsAgain(moveButtons[4], "p5");
            CreateButtonsAgain(moveButtons[5], "p6");

            UpdateInitialForm();

        }



        /// <summary>
        /// 进入队伍界面初始化
        /// </summary>
        private void button_generate_Click(object sender, EventArgs e)
        {
            if (pokemonNum == 6)
            {
                //显示及隐藏控件
                button_generate.Visible = false;
                button_end.Visible = true;
                for (int i = 0; i < 6; i++)
                    labels[i].Visible = false;

                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton5.Visible = false;

                if (radioButton1.Checked)
                    for (int i = 0; i < OUNum; i++)
                        OUButtons[i].Btn.Visible = false;
                else if (radioButton2.Checked)
                    for (int i = 0; i < UUNum; i++)
                        UUButtons[i].Btn.Visible = false;
                else if (radioButton3.Checked)
                    for (int i = 0; i < NUNum; i++)
                        NUButtons[i].Btn.Visible = false;
                else if (radioButton5.Checked)
                    for (int i = 0; i < DNNum; i++)
                        DNButtons[i].Btn.Visible = false;

                for (int i = 0; i < 6; i++)
                    pokemonButtons[i].Btn.Visible = true;
                textBox0.Visible = true;
                textBox1.Visible = true;

                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;

                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;

                //初始化对方宝可梦
                for (int i = 0; i < 6; i++)
                {
                    myPokemons[i] = new MyPokemon(pokemonButtons[i].Pm);
                    myPokemons[i].MyAbility = pokemonButtons[i].Pm.AllAbilities[0].Name;
                    for (int j = 0; j < moveButtons[i].Length; j++)
                        if (j < myPokemons[i].AllMoves.Count)
                            moveButtons[i][j].Text = myPokemons[i].AllMoves[j].Name;
                }

                //分析队伍
                AnalyzeTeam();

                ifFirst = false;
            }
            else
                MessageBox.Show("未选满6只宝可梦！");
        }


        /// <summary>
        /// 分析队伍
        /// </summary>
        private void AnalyzeTeam()
        {
            string display_1="属性分析(不计神奇守护)：\r\n";
            display_1 += Analyze.SubAnalyze(myPokemons, "地面", "飞行", "0", "0", "飘浮", "0", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "电", "地面", "0", "0", "蓄电", "电气引擎", "避雷针", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "普通、格斗", "0", "0", "幽灵", "0", "0", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "幽灵", "普通", "0", "0", "0", "0", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "超能", "恶", "0", "0", "0", "0", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "毒", "钢", "0", "0", "0", "0", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "火(潜在)", "0", "0", "0", "引火", "0", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "水(潜在)", "0", "0", "0", "引水", "储水", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "草(潜在)", "0", "0", "0", "食草", "0", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "中毒", "钢", "毒", "0", "免疫", "魔法防守", "毒疗", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "灼伤", "火", "0", "0", "0", "魔法防守", "水幕", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "麻痹", "电", "0", "0", "柔软", "0", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "睡觉", "0", "0", "0", "0", "不眠", "干劲", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "寄生种子", "草", "0", "0", "食草", "0", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "隐形岩", "0", "0", "0", "0", "魔法防守", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "菱钉", "飞行", "0", "0", "飘浮", "魔法防守", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "毒菱", "飞行", "毒", "钢", "飘浮", "魔法防守", "免疫", "毒疗");
            display_1 += Analyze.SubAnalyze(myPokemons, "沙暴", "岩石", "钢", "地面", "防尘", "魔法防守", "无关天气", "气闸");
            display_1 += Analyze.SubAnalyze(myPokemons, "挑衅", "0", "0", "0", "迟钝", "魔法镜", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "粉尘类技能", "0", "0", "0", "防尘", "0", "0", "0");
            display_1 += Analyze.SubAnalyze(myPokemons, "畏缩", "0", "0", "0", "精神力", "0", "0", "0");

            textBox0.Text = display_1;

            string display_2 = "角色分析（潜在）：\r\n";
            display_2 += Analyze.RoleAnalyze(myPokemons, "出钉", "0", "0", "0", "0", "隐形岩", "撒菱", "毒菱", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "清钉", "0", "0", "0", "0", "高速旋转", "清除浓雾", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "天气手", "降雨", "日照", "扬沙", "降雪", "0", "0", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "挑衅", "0", "0", "0", "0", "挑衅", "0", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "空间手", "0", "0", "0", "0", "戏法空间", "0", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "物理强化", "0", "0", "0", "0", "龙之舞", "剑舞", "健美", "磨爪", "腹鼓", "点穴");
            display_2 += Analyze.RoleAnalyze(myPokemons, "破壳强化", "0", "0", "0", "0", "0", "0", "0", "0", "破壳", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "诅咒", "0", "0", "0", "0", "诅咒", "0", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "特殊强化", "0", "0", "0", "0", "蝶舞", "诡计", "冥想", "0", "0", "0");       
            display_2 += Analyze.RoleAnalyze(myPokemons, "生长", "0", "0", "0", "0", "生长", "0", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "聚气", "0", "0", "0", "0", "聚气", "0", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "反强化(消除)", "0", "0", "0", "0", "再来一次", "黑雾", "清除之烟", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "反强化(退场)", "0", "0", "0", "0", "龙尾", "0", "0", "巴投", "吼叫", "吹飞");
            display_2 += Analyze.RoleAnalyze(myPokemons, "物理先制", "0", "0", "0", "0", "子弹拳", "神速", "冰砾", "音速拳", "水流喷射", "影子偷袭");
            display_2 += Analyze.RoleAnalyze(myPokemons, "特殊先制", "0", "0", "0", "0", "真空波", "0", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "条件先制", "0", "0", "0", "0", "击掌奇袭", "突袭", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "游击手", "0", "0", "0", "0", "急速折返", "伏特替换", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "开墙手", "0", "0", "0", "0", "反射壁", "光墙", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "抓人(及追打)", "踩影", "沙穴", "磁力", "0", "追打", "0", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "静电", "静电", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "火焰之躯", "火焰之躯", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "木乃伊", "木乃伊", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            display_2 += Analyze.RoleAnalyze(myPokemons, "孢子", "孢子", "0", "0", "0", "0", "0", "0", "0", "0", "0");
            textBox1.Text = display_2;
        }

        


        /// <summary>
        /// 生成宝可梦选择按钮
        /// </summary>
        private void CreateButtons(ButtonWithPokemon[] buttons, List<Pokemon> pl, string str)  
        {
            const int buttonLength = 95;
            const int buttonWidth = 40;
            const int buttonInterval_x = 2;
            const int buttonInterval_y = 6;
            Point[] points = new Point[64];
            for (int i = 0; i < 64; i++)
                points[i] = new Point(buttonInterval_x + 4 + i % 4 * (buttonLength + buttonInterval_x), 130 + i / 4 * (buttonWidth + buttonInterval_y));
                      
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
                buttons[i].Btn.Font = new Font("幼圆", 11);
                buttons[i].Btn.Margin = new Padding(0);
                buttons[i].Btn.Parent = this;
                this.Controls.Add(buttons[i].Btn);
                buttons[i].Btn.Click += new EventHandler(Btn_Click);
            }
        }


        /// <summary>
        /// 生成技能按钮
        /// </summary>
        private void CreateButtonsAgain(Button[] buttons, string str)
        {
            const int buttonLength = 75;
            const int buttonWidth = 30;
            const int buttonInterval_x = 2;
            const int buttonInterval_y = 2;
            Point[] points = new Point[moveNum];
            for (int i = 0; i < moveNum; i++)
                points[i] = new Point(buttonInterval_x + 6 + i % 5 * (buttonLength + buttonInterval_x), 567 + i / 5 * (buttonWidth + buttonInterval_y));

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Button();
                buttons[i].Location = points[i];
                buttons[i].Size = new Size(buttonLength, buttonWidth);
                buttons[i].Name = string.Format("{0}button_{1}", str, i);
                buttons[i].BackColor = Color.Empty;                
                buttons[i].Font = new Font("幼圆", 9);
                buttons[i].Parent = this;
                this.Controls.Add(buttons[i]);
                buttons[i].Click += new EventHandler(MoveButton_Click);
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
                for (int i = 0; i < DNNum; i++)
                    DNButtons[i].Btn.Visible = false;
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
                for (int i = 0; i < DNNum; i++)
                    DNButtons[i].Btn.Visible = false;
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
                for (int i = 0; i < DNNum; i++)
                    DNButtons[i].Btn.Visible = false;
            }
        }


        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                for (int i = 0; i < OUNum; i++)
                    OUButtons[i].Btn.Visible = false;
                for (int i = 0; i < UUNum; i++)
                    UUButtons[i].Btn.Visible = false;
                for (int i = 0; i < NUNum; i++)
                    NUButtons[i].Btn.Visible = false;
                for (int i = 0; i < DNNum; i++)
                    DNButtons[i].Btn.Visible = true;
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
            else if (radioButton5.Checked)
                ChoosePokemon(DNButtons);

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
                        else if (pokemonNum < 6)
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
        /// 技能按钮点击事件
        /// </summary>
        private static void MoveButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (lastClick)
            {
                case 1:
                    ChooseMoves(moveButtons[0]);
                    break;
                case 2:
                    ChooseMoves(moveButtons[1]);
                    break;
                case 3:
                    ChooseMoves(moveButtons[2]);
                    break;
                case 4:
                    ChooseMoves(moveButtons[3]);
                    break;
                case 5:
                    ChooseMoves(moveButtons[4]);
                    break;
                case 6:
                    ChooseMoves(moveButtons[5]);
                    break;
            }

            void ChooseMoves(Button[] buttons)
            {
                for (int i = 0; i < buttons.Length; i++)
                    if (btn.Name == buttons[i].Name)
                    {
                        if (buttons[i].BackColor == Color.Blue)
                        {
                            buttons[i].BackColor = Color.Empty;
                            buttons[i].ForeColor = Color.Black;
                            fourMoves[lastClick - 1]--;
                        }
                        else if (fourMoves[lastClick - 1] < 4) 
                        {
                            buttons[i].BackColor = Color.Blue;
                            buttons[i].ForeColor = Color.White;
                            fourMoves[lastClick - 1]++;
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

            //显示种族值
            textBox_ev.Text =
                string.Format("种族值\r\n\r\nHP：{0}\r\n攻击：{1}\r\n防御：{2}\r\n特攻：{3}\r\n特防：{4}\r\n速度：{5}\r\n总和：{6}",
                bwp.Pm.MyEthnicValue.HP, bwp.Pm.MyEthnicValue.AT, bwp.Pm.MyEthnicValue.DF, bwp.Pm.MyEthnicValue.SA,
                bwp.Pm.MyEthnicValue.SD, bwp.Pm.MyEthnicValue.SP, bwp.Pm.MyEthnicValue.total);

            //显示图片
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("p" + bwp.Pm.Index);
            pictureBox_type1.Image = (Image)Properties.Resources.ResourceManager.GetObject(bwp.Pm.Type1.Picture);
            pictureBox_type2.Image = (Image)Properties.Resources.ResourceManager.GetObject(bwp.Pm.Type2.Picture);

            //显示抗性
            DisplayResist(myPokemons[lastClick - 1]);

            //显示特性
            radioButton_ability1.Text = bwp.Pm.AllAbilities[0].Name;
            if (bwp.Pm.AllAbilities[1].Name == "")
                radioButton_ability2.Visible = false;
            else
            {
                radioButton_ability2.Visible = true;
                radioButton_ability2.Text = bwp.Pm.AllAbilities[1].Name;
            }
        }


        private void DisplayResist(MyPokemon mp)
        {
            string resist_0 = "无效：";
            string resist_0_25 = "4倍抵抗：";
            string resist_0_5 = "2倍抵抗：";
            string resist_2 = "2倍克制：";
            string resist_4 = "4倍克制：";
            float resistIndex = 1;
            for (int i = 1; i < Types.AllTypes.Count; i++)
            {
                if (Types.AllTypes[i].Name == "地面" && mp.MyAbility == "飘浮")
                    resistIndex = 0;
                else if (Types.AllTypes[i].Name == "电" && (mp.MyAbility == "蓄电" || mp.MyAbility == "避雷针" || mp.MyAbility == "电气引擎"))
                    resistIndex = 0;
                else if (Types.AllTypes[i].Name == "水" && (mp.MyAbility == "引水" || mp.MyAbility == "储水"))
                    resistIndex = 0;
                else if (Types.AllTypes[i].Name == "火" && mp.MyAbility == "引火")
                    resistIndex = 0;
                else if (Types.AllTypes[i].Name == "草" && mp.MyAbility == "食草")
                    resistIndex = 0;
                else if ((Types.AllTypes[i].Name == "草" || Types.AllTypes[i].Name == "地面" || Types.AllTypes[i].Name == "虫"
                    || Types.AllTypes[i].Name == "电" || Types.AllTypes[i].Name == "水" || Types.AllTypes[i].Name == "超能"
                    || Types.AllTypes[i].Name == "龙" || Types.AllTypes[i].Name == "钢" || Types.AllTypes[i].Name == "毒"
                    || Types.AllTypes[i].Name == "冰") && mp.MyAbility == "神奇守护") 
                    resistIndex = 0;
                else
                    resistIndex = mp.Type1.Resist[i] * mp.Type2.Resist[i];

                if (Types.AllTypes[i].Name == "火" && (mp.MyAbility == "耐热" || mp.MyAbility == "厚脂肪")) 
                    resistIndex *= 0.5f;
                if (Types.AllTypes[i].Name == "冰" && mp.MyAbility == "厚脂肪")
                    resistIndex *= 0.5f;

                if (resistIndex < 0.1)
                    resist_0 += (Types.AllTypes[i].Name + " ");
                if (resistIndex < 0.3 && resistIndex > 0.2)
                    resist_0_25 += (Types.AllTypes[i].Name + " ");
                if (resistIndex < 0.6 && resistIndex > 0.4)
                    resist_0_5 += (Types.AllTypes[i].Name + " ");
                if (resistIndex < 2.1 && resistIndex > 1.9)
                    resist_2 += (Types.AllTypes[i].Name + " ");
                if (resistIndex > 3.9)
                    resist_4 += (Types.AllTypes[i].Name + " ");
            }
            textBox_type.Text = resist_0 + "\r\n" + resist_0_25 + "\r\n" + resist_0_5 + "\r\n" + resist_2 + "\r\n" + resist_4;
        }


        /// <summary>
        /// 队伍界面按钮事件
        /// </summary>
        private void button_pm1_Click(object sender, EventArgs e)
        {
            Button_6pm_Click(1);
        }

        private void button_pm2_Click(object sender, EventArgs e)
        {
            Button_6pm_Click(2);
        }

        private void button_pm3_Click(object sender, EventArgs e)
        {
            Button_6pm_Click(3);
        }

        private void button_pm4_Click(object sender, EventArgs e)
        {
            Button_6pm_Click(4);
        }

        private void button_pm5_Click(object sender, EventArgs e)
        {
            Button_6pm_Click(5);
        }
    
        private void button_pm6_Click(object sender, EventArgs e)
        {
            Button_6pm_Click(6);
        }


        private void Button_6pm_Click(int i)
        {
            lastClick = i;

            UpdateFormToPokemon(pokemonButtons[i - 1]);

            if (radioButton_ability1.Text == myPokemons[i - 1].MyAbility) 
                radioButton_ability1.Checked = true;
            else
                radioButton_ability1.Checked = false;
            if (radioButton_ability2.Text == myPokemons[i - 1].MyAbility) 
                radioButton_ability2.Checked = true;
            else
                radioButton_ability2.Checked = false;

            comboBox.SelectedIndex = comboBox.FindStringExact(myPokemons[i - 1].item);

            for (int j = 0; j < moveButtons[i - 1].Length; j++)
            {
                if (j < myPokemons[i - 1].AllMoves.Count)
                    moveButtons[i - 1][j].Visible = true;
                else
                    moveButtons[i-1][j].Visible = false; ;
            }

            for (int k = 0; k < 6; k++)
                if (k != (i - 1))
                    for (int j = 0; j < moveButtons[k].Length; j++)
                        moveButtons[k][j].Visible = false;
        }


        /// <summary>
        /// 特性选择
        /// </summary>
        private void radioButton_ability1_CheckedChanged(object sender, EventArgs e)
        {
            if (!ifFirst)
                if (radioButton_ability1.Checked)
                {
                    for (int i = 1; i < 7; i++)
                        if (lastClick == i)
                            myPokemons[i - 1].MyAbility = radioButton_ability1.Text;
                    DisplayResist(myPokemons[lastClick - 1]);
                }
        }

        private void radioButton_ability2_CheckedChanged(object sender, EventArgs e)
        {
            if (!ifFirst)
                if (radioButton_ability2.Checked)
                {
                    for (int i = 1; i < 7; i++)
                        if (lastClick == i)
                            myPokemons[i - 1].MyAbility = radioButton_ability2.Text;
                    DisplayResist(myPokemons[lastClick - 1]);
                }
        }

        /// <summary>
        /// 道具选择
        /// </summary>
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ifFirst)
                for (int i = 1; i < 7; i++)
                    if (lastClick == i)
                        myPokemons[i - 1].item = comboBox.SelectedItem.ToString();
        }


        /// <summary>
        /// 结束战斗按钮
        /// </summary>
        private void button_end_Click(object sender, EventArgs e)
        {
            System.GC.Collect();
            UpdateInitialForm();
            button_generate.Visible = true;
            ifFirst = true;
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
            textBox0.Visible = false;
            textBox1.Visible = false;
            textBox_ev.Visible = false;
            textBox_type.Visible = false;
            button_end.Visible = false;
            comboBox.Visible = false;
            radioButton_ability1.Visible = false;
            radioButton_ability2.Visible = false;

            for (int i = 0; i < moveButtons.Length; i++)
                for (int j = 0; j < moveButtons[i].Length; j++)
                    moveButtons[i][j].Visible = false;
           

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
            radioButton5.Visible = true;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton5.Checked = false;

            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
            numericUpDown3.Visible = false;
            numericUpDown4.Visible = false;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;

            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;

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
            if (Directory.Exists(dir1))
            {
                FileInfo[] fileInfo = dir.GetFiles();

                for (int i = 0; i < fileInfo.Length; i++)
                    list.Add(fileInfo[i].FullName);
            }

            return list;
        }

        public static void ImportJson(List<Pokemon> pl, string str)
        {
            List<string> jsonList = GetAllDir(Application.StartupPath + string.Format(@"\src\{0}\", str));
            for (int i = 0; i < jsonList.Count; i++) 
            {
                string jsonText = new StreamReader(jsonList[i]).ReadToEnd();
                pl.Add(new Pokemon());
                Newtonsoft.Json.Linq.JObject jobject = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonText);
                if (jobject == null)
                    return;
                pl[i].Name = jobject["官方译名"].ToString();
                pl[i].Index = jobject["编号"].ToString();
                pl[i].MyEthnicValue.HP = Convert.ToInt16(jobject["种族值"]["HP"]);
                pl[i].MyEthnicValue.AT = Convert.ToInt16(jobject["种族值"]["攻击"]);
                pl[i].MyEthnicValue.DF = Convert.ToInt16(jobject["种族值"]["防御"]);
                pl[i].MyEthnicValue.SA = Convert.ToInt16(jobject["种族值"]["特攻"]);
                pl[i].MyEthnicValue.SD = Convert.ToInt16(jobject["种族值"]["特防"]);
                pl[i].MyEthnicValue.SP = Convert.ToInt16(jobject["种族值"]["速度"]);
                pl[i].MyEthnicValue.total = Convert.ToInt16(jobject["种族值"]["总和"]);
                for (int j = 0; j < Types.AllTypes.Count; j++)
                {
                    if (Types.AllTypes[j].Name == jobject["属性"].ToArray()[0].ToString())
                        pl[i].Type1 = Types.AllTypes[j];
                    else if (jobject["属性"].ToArray()[0].ToString() == "超能力")
                        pl[i].Type1 = Types.psychc;
                    if (Types.AllTypes[j].Name == jobject["属性"].ToArray()[1].ToString())
                        pl[i].Type2 = Types.AllTypes[j];
                    else if (jobject["属性"].ToArray()[1].ToString() == "超能力")
                        pl[i].Type2 = Types.psychc;
                }

                pl[i].AllAbilities.Add(new Ability(jobject["特性"]["特性1"].ToString(), ""));
                pl[i].AllAbilities.Add(new Ability(jobject["特性"]["特性2"].ToString(), ""));

                string jsonText_1 = new StreamReader(Application.StartupPath + @"\src\" + jobject["技能池"].ToString().Replace("/", @"\")).ReadToEnd();
                Newtonsoft.Json.Linq.JObject subjobject = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonText_1);
                if (subjobject == null)
                    return;

                for (int j = 0; ; j++) 
                {
                    if (subjobject.ContainsKey(string.Format("技能{0}", j + 1)))
                    {
                       if (Moves.AllUsualMovesName.Contains(subjobject[string.Format("技能{0}", j + 1)]["名称"].ToString()))
                            pl[i].AllMoves.Add(new Move(subjobject[string.Format("技能{0}", j + 1)]["名称"].ToString(), subjobject[string.Format("技能{0}", j + 1)]["类型"].ToString()));
                    }
                    else
                        break;
                }

                //技能过滤
                pl[i].AllMoves = pl[i].AllMoves.GroupBy(p => p.Name).Select(q => q.First()).ToList();
                if ((pl[i].MyEthnicValue.AT - pl[i].MyEthnicValue.SA) > 30 && pl[i].MyEthnicValue.SA < 85)
                    for (int j = pl[i].AllMoves.Count - 1; j >= 0; j--)
                        if (pl[i].AllMoves[j].MoveType == "特殊")
                            pl[i].AllMoves.Remove(pl[i].AllMoves[j]);
                if ((pl[i].MyEthnicValue.SA - pl[i].MyEthnicValue.AT) > 30 && pl[i].MyEthnicValue.AT < 85)
                    for (int j = pl[i].AllMoves.Count - 1; j >= 0; j--)
                        if (pl[i].AllMoves[j].MoveType == "物理")
                            pl[i].AllMoves.Remove(pl[i].AllMoves[j]);

                Analyze.RemoveMove(pl[i], "暴鲤龙", "强力鞭打", "0", "0");
                Analyze.RemoveMove(pl[i], "三首恶龙", "流星群", "0", "0");
                Analyze.RemoveMove(pl[i], "水箭龟", "恶之波动", "龙之波动", "波导弹");
                Analyze.RemoveMove(pl[i], "班基拉斯", "大晴天", "求雨", "潮旋");
                Analyze.RemoveMove(pl[i], "班基拉斯", "火焰牙", "雷电牙", "冰冻牙");
                Analyze.RemoveMove(pl[i], "快龙", "觉醒力量", "硬撑", "0");
                Analyze.RemoveMove(pl[i], "达摩狒狒", "再来一次", "健美", "梦话");
                Analyze.RemoveMove(pl[i], "耿鬼", "黑雾", "再来一次", "清除之烟");
                Analyze.RemoveMove(pl[i], "死神棺", "诡计", "0", "0");
                Analyze.RemoveMove(pl[i], "梦妖魔", "诡计", "0", "0");
                Analyze.RemoveMove(pl[i], "清洗洛托姆", "过热", "飞叶风暴", "暴风雪");
                Analyze.RemoveMove(pl[i], "清洗洛托姆", "空气斩", "0", "0");
                Analyze.RemoveMove(pl[i], "过热洛托姆", "水炮", "飞叶风暴", "暴风雪");
                Analyze.RemoveMove(pl[i], "过热洛托姆", "空气斩", "0", "0");
                Analyze.RemoveMove(pl[i], "冻结洛托姆", "过热", "飞叶风暴", "水炮");
                Analyze.RemoveMove(pl[i], "冻结洛托姆", "空气斩", "0", "0");
                Analyze.RemoveMove(pl[i], "旋转洛托姆", "过热", "飞叶风暴", "暴风雪");
                Analyze.RemoveMove(pl[i], "旋转洛托姆", "水炮", "0", "0");
                Analyze.RemoveMove(pl[i], "切割洛托姆", "过热", "水炮", "暴风雪");
                Analyze.RemoveMove(pl[i], "切割洛托姆", "空气斩", "0", "0");

                Analyze.AddMove(pl[i], "班基拉斯", "追打", "物理");
                Analyze.AddMove(pl[i], "玛狃拉", "追打", "物理");
            }
        }
    }
}
