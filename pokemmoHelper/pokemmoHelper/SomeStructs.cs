using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemmoHelper
{
    struct ButtonWithPokemon
    {
        public Button Btn;
        public Pokemon Pm;
        public ButtonWithPokemon(Button b, Pokemon p)
        {
            this.Btn = b;
            this.Pm = p;
        }
    }

    struct Type
    {
        public string Name;
        public string Picture;
        public List<Type> NoEffectTypes;
        public List<Type> OverTypes;
        public List<Type> ResistTypes;
        public Type(string n, string p, List<Type> net, List<Type> ot, List<Type> rt)
        {
            this.Name = n;
            this.Picture = p;
            this.NoEffectTypes = net;
            this.OverTypes = ot;
            this.ResistTypes = rt;
        }
    }

    struct EthnicValue
    {
        public int HP;
        public int AT;
        public int DF;
        public int SA;
        public int SD;
        public int SP;
        public EthnicValue(int hp, int at, int df, int sa, int sd, int sp)
        {
            this.HP = hp;
            this.AT = at;
            this.DF = df;
            this.SA = sa;
            this.SD = sd;
            this.SP = sp;
        }
    }

    struct Ability
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
