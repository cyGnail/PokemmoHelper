using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemmoHelper
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Index { get; set; }
        public Type Type1 { get; set; }
        public Type Type2 { get; set; }

        public EthnicValue MyEthnicValue;

        public List<Move> AllMoves;

        public List<Ability> AllAbilities; 

        public static List<Pokemon> OUPokemons = new List<Pokemon>();
        public static List<Pokemon> UUPokemons = new List<Pokemon>();
        public static List<Pokemon> NUPokemons = new List<Pokemon>();

        public Pokemon()
        {
            this.Name = "自定义宝可梦";
            this.Index = "000";
            this.MyEthnicValue = new EthnicValue(100, 100, 100, 100, 100, 100);
            this.AllAbilities = new List<Ability>();
            this.AllMoves = new List<Move>();
        }
    }

    class MyPokemon : Pokemon
    {
        public string item { get; set; }
        public string MyAbility { get; set; }

        public MyPokemon(Pokemon p)
        {
            this.Name = p.Name;
            this.Index = p.Index;
            this.Type1 = p.Type1;
            this.Type2 = p.Type2;
            this.MyEthnicValue = p.MyEthnicValue;
            this.AllMoves = p.AllMoves;
            this.AllAbilities = p.AllAbilities;
            this.item = "无影响(已消耗)";
            this.MyAbility = "";
        }
    }
}
