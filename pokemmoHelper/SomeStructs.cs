using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemmoHelper
{
    public struct ButtonWithPokemon
    {
        public Button Btn;
        public Pokemon Pm;
        public ButtonWithPokemon(Button b, Pokemon p)
        {
            this.Btn = b;
            this.Pm = p;
        }
    }

    public struct Type
    {
        public string Name;
        public string Picture;
        public List<float> Resist;

        public Type(string n, string p, List<float> r)
        {
            this.Name = n;
            this.Picture = p;
            this.Resist = r;
        }
    }

    public struct EthnicValue
    {
        public int HP { get; set; }
        public int AT { get; set; }
        public int DF { get; set; }
        public int SA { get; set; }
        public int SD { get; set; }
        public int SP { get; set; }

        public int total { get; set; }
        public EthnicValue(int hp, int at, int df, int sa, int sd, int sp)
        {
            this.HP = hp;
            this.AT = at;
            this.DF = df;
            this.SA = sa;
            this.SD = sd;
            this.SP = sp;
            this.total = hp + at + df + sa + sd + sp;
        }
    }

    public struct Ability
    {
        public string Name;
        public string Description;
        public Ability(string n, string d)
        {
            this.Name = n;
            this.Description = d;
        }
    }
}
