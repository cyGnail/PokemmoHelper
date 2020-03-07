using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemmoHelper
{
    class Analyze
    {
        public static string SubAnalyze(MyPokemon[] myPokemons, string type, string ntype1, string ntype2, string ntype3, string ab1, string ab2, string ab3, string ab4)
        {
            string display = null;
            bool flag = false;
            for (int i = 0; i < 6; i++)
                if (myPokemons[i].Type1.Name == ntype1 || myPokemons[i].Type2.Name == ntype1 ||
                    myPokemons[i].Type1.Name == ntype2 || myPokemons[i].Type2.Name == ntype2 ||
                    myPokemons[i].Type1.Name == ntype3 || myPokemons[i].Type2.Name == ntype3 ||
                    myPokemons[i].AllAbilities[0].Name == ab1 || myPokemons[i].AllAbilities[1].Name == ab1 ||
                    myPokemons[i].AllAbilities[0].Name == ab2 || myPokemons[i].AllAbilities[1].Name == ab2 ||
                    myPokemons[i].AllAbilities[0].Name == ab3 || myPokemons[i].AllAbilities[1].Name == ab3 ||
                    myPokemons[i].AllAbilities[0].Name == ab4 || myPokemons[i].AllAbilities[1].Name == ab4)
                {
                    if (!flag)
                    {
                        display += string.Format("\r\n{0}免疫：", type);
                        flag = true;
                    }
                    display += (myPokemons[i].Name + " ");
                }
            return display;
        }

        public static void RemoveMove(Pokemon p, string n, string m1, string m2, string m3)
        {
            if (p.Name == n)
                for (int j = p.AllMoves.Count - 1; j >= 0; j--)
                    if (p.AllMoves[j].Name == m1 || p.AllMoves[j].Name == m2 || p.AllMoves[j].Name == m3) 
                        p.AllMoves.Remove(p.AllMoves[j]);
        }

        public static void AddMove(Pokemon p, string n, string m, string t)
        {
            if (p.Name == n)
                p.AllMoves.Add(new Move(m, t));
        }

        public static string RoleAnalyze(MyPokemon[] myPokemons, string role, string ab1, string ab2, string ab3, string ab4, string m1, string m2, string m3, string m4, string m5, string m6)
        {
            string display = null;
            bool flag = false;
            for (int i = 0; i < 6; i++)
                if (myPokemons[i].AllAbilities[0].Name == ab1 || myPokemons[i].AllAbilities[1].Name == ab1 ||
                    myPokemons[i].AllAbilities[0].Name == ab2 || myPokemons[i].AllAbilities[1].Name == ab2 ||
                    myPokemons[i].AllAbilities[0].Name == ab3 || myPokemons[i].AllAbilities[1].Name == ab3 ||
                    myPokemons[i].AllAbilities[0].Name == ab4 || myPokemons[i].AllAbilities[1].Name == ab4 ||
                    myPokemons[i].HaveMove(m1) || myPokemons[i].HaveMove(m2) || myPokemons[i].HaveMove(m3) ||
                    myPokemons[i].HaveMove(m4) || myPokemons[i].HaveMove(m5) || myPokemons[i].HaveMove(m6)) 
                {
                    if (role == "诅咒" && (myPokemons[i].Type1.Name == "幽灵" || myPokemons[i].Type2.Name == "幽灵"))
                        continue;
                    else
                    {
                        if (!flag)
                        {
                            display += string.Format("\r\n{0}：", role);
                            flag = true;
                        }
                        display += (myPokemons[i].Name + " ");
                    }
                }
            return display;
        }
    }
}
