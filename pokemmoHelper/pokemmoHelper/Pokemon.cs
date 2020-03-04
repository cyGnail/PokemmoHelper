using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemmoHelper
{
    class Pokemon
    {
        public string Name { get; set; }
        public string Index { get; set; }
        public string Picture { get; set; }
        public Type Type1 { get; set; }
        public Type Type2 { get; set; }
        public EthnicValue MyEthnicValue { get; set; }
        public List<string> AllMoves { get; set; }
        public List<Ability> AllAbilities { get; set; }

        public Pokemon()
        {
            this.Name = "自定义宝可梦";
            this.Index = "000";
            this.Picture = "";
        }
    }
}
