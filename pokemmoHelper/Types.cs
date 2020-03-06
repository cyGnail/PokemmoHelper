using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemmoHelper
{
    public class Types
    {
        public static Type typenone = new Type("无", "typenone", 
            new List<float> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
        public static Type normal = new Type("一般", "normal",
            new List<float> { 0, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 1 });
        public static Type fire = new Type("火", "fire",
            new List<float> { 0, 1, 0.5f, 2, 0.5f, 1, 2, 1, 1, 2, 0.5f, 0.5f, 1, 0.5f, 1, 1, 1, 1 });
        public static Type water = new Type("水", "water",
            new List<float> { 0, 1, 0.5f, 0.5f, 2, 2, 1, 1, 1, 1, 0.5f, 0.5f, 1, 1, 1, 1, 1, 1 });
        public static Type grass = new Type("草", "grass",
            new List<float> { 0, 1, 2, 0.5f, 0.5f, 0.5f, 0.5f, 2, 1, 1, 2, 1, 2, 2, 1, 1, 1, 1 });
        public static Type electr = new Type("电", "electr",
            new List<float> { 0, 1, 1, 1, 1, 0.5f, 2, 0.5f, 1, 1, 1, 0.5f, 1, 1, 1, 1, 1, 1 });
        public static Type ground = new Type("地面", "ground",
            new List<float> { 0, 1, 1, 2, 2, 0, 1, 1, 1, 0.5f, 2, 1, 0.5f, 1, 1, 1, 1, 1 });
        public static Type flying = new Type("飞行", "flying",
            new List<float> { 0, 1, 1, 1, 0.5f, 2, 0, 1, 0.5f, 2, 2, 1, 1, 0.5f, 1, 1, 1, 1 });
        public static Type fight = new Type("格斗", "fight",
            new List<float> { 0, 1, 1, 1, 1, 1, 1, 2, 1, 0.5f, 1, 1, 1, 0.5f, 2, 0.5f, 1, 1 });
        public static Type rock = new Type("岩石", "rock",
            new List<float> { 0, 0.5f, 0.5f, 2, 2, 1, 2, 0.5f, 2, 1, 1, 2, 0.5f, 1, 1, 1, 1, 1 });
        public static Type ice = new Type("冰", "ice",
            new List<float> { 0, 1, 2, 1, 1, 1, 1, 1, 2, 2, 0.5f, 2, 1, 1, 1, 1, 1, 1 });
        public static Type steel = new Type("钢", "steel",
            new List<float> { 0, 0.5f, 2, 1, 0.5f, 1, 2, 0.5f, 2, 0.5f, 0.5f, 0.5f, 0, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f });
        public static Type poison = new Type("毒", "poison",
            new List<float> { 0, 1, 1, 1, 0.5f, 1, 2, 1, 0.5f, 1, 1, 1, 0.5f, 0.5f, 2, 1, 1, 1 });
        public static Type bug = new Type("虫", "bug",
            new List<float> { 0, 1, 2, 1, 0.5f, 1, 0.5f, 2, 0.5f, 2, 1, 1, 1, 1, 1, 1, 1, 1 });
        public static Type psychc = new Type("超能", "psychc",
            new List<float> { 0, 1, 1, 1, 1, 1, 1, 1, 0.5f, 1, 1, 1, 1, 2, 0.5f, 2, 2, 1 });
        public static Type dark = new Type("恶", "dark",
            new List<float> { 0, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 0, 0.5f, 0.5f, 1 });
        public static Type ghost = new Type("幽灵", "ghost",
            new List<float> { 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0.5f, 1, 2, 2, 1 });
        public static Type dragon = new Type("龙", "dragon",
            new List<float> { 0, 1, 0.5f, 0.5f, 0.5f, 0.5f, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2 });

        public static List<Type> AllTypes = 
            new List<Type>() { typenone, normal, fire, water, grass, electr, ground, flying, fight, rock, ice, steel, poison, bug, psychc, dark, ghost, dragon };
    }
}
