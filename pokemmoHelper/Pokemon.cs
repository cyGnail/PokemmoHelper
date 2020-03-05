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
        public string Picture { get; set; }
        public Type Type1 { get; set; }
        public Type Type2 { get; set; }

        public EthnicValue MyEthnicValue;
        public List<string> AllMoves { get; set; }
        public List<Ability> AllAbilities { get; set; }

        public static List<Pokemon> OUPokemons = new List<Pokemon>();
        public static List<Pokemon> UUPokemons = new List<Pokemon>();
        public static List<Pokemon> NUPokemons = new List<Pokemon>();

        public Pokemon()
        {
            this.Name = "自定义宝可梦";
            this.Index = "000";
            this.Picture = "";
            this.MyEthnicValue = new EthnicValue(100, 100, 100, 100, 100, 100);
        }
    }

    class MyPokemon : Pokemon
    {
        public string item { get; set; }
        public Ability MyAbility { get; set; }
    }
}
