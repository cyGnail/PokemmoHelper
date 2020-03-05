using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemmoHelper
{
    public class Types
    {
        public static Type typenone = new Type("无", "", 
            new List<float> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
        public static Type normal = new Type("一般", "",
            new List<float> { 0, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 1 });
        public static Type fire = new Type("火", "",
            new List<float> { 0, 0, 0.5f, 2, 0.5f, 1, 2, 1, 1, 2, 0.5f, 0.5f, 1, 0.5f, 1, 1, 1, 1 });
        public static Type water = new Type("水", "",
            new List<float> { 0, 1, 0.5f, 0.5f, 2, 2, 1, 1, 1, 1, 0.5f, 0.5f, 1, 1, 1, 1, 1 });
        public static Type grass = new Type("草", "",
            new List<float> { 0, 1, 2, 0.5f, 0.5f, 0.5f, 0.5f, 2, 1, 1, 2, 1, 2, 2, 1, 1, 1, 1 });
        public static Type electr = new Type("电", "",
            new List<float> { 0, 1, 1, 1, 1, 0.5f, 2, 0.5f, 1, 1, 1, 0.5f, 1, 1, 1, 1, 1, 1 });
        public static Type ground = new Type("地面", "",
            new List<float> { 0, 1, 1, 2, 2, 0, 1, 1, 1, 0.5f, 2, 1, 0.5f, 1, 1, 1, 1, 1 });
        public static Type flying = new Type("飞行", "",
            new List<float> { 0, 1, 1, 1, 0.5f, 2, 0, 1, 0.5f, 2, 2, 1, 1, 0.5f, 1, 1, 1, 1 });
        public static Type fight = new Type("格斗", "",
            new List<float> { 0, 1, 1, 1, 1, 1, 1, 2, 1, 0.5f, 1, 1, 1, 0.5f, 2, 0.5f, 1, 1 });
        public static Type rock = new Type("岩石", "",
            new List<float> { 0, 0.5f, 0.5f, 2, 2, 1, 2, 0.5f, 2, 1, 1, 2, 0.5f, 1, 1, 1, 1, 1 });
        public static Type ice = new Type("冰", "",
            new List<float> { 0, 1, 2, 1, 1, 1, 1, 1, 2, 2, 0.5f, 2, 1, 1, 1, 1, 1, 1 });
        public static Type steel = new Type("钢", "",
            new List<float> { 0, 0.5f, 2, 1, 0.5f, 1, 2, 0.5f, 2, 0.5f, 0.5f, 0.5f, 0, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f });
        public static Type poison = new Type("毒", "",
            new List<float> { 0, 1, 1, 1, 0.5f, 1, 2, 1, 0.5f, 1, 1, 0.5f, 0.5f, 2, 1, 1, 1 });
        public static Type bug = new Type("虫", "",
            new List<float> { 0, 1, 2, 1, 1, 0.5f, 1, 0.5f, 2, 0.5f, 2, 1, 1, 1, 1, 1, 1, 1, 1 });
        public static Type psychc = new Type("超能", "",
            new List<float> { 0, 1, 1, 1, 1, 1, 1, 1, 0.5f, 1, 1, 1, 1, 2, 0.5f, 2, 2, 1 });
        public static Type dark = new Type("恶", "",
            new List<float> { 0, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 0, 0.5f, 0.5f, 1 });
        public static Type ghost = new Type("幽灵", "",
            new List<float> { 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0.5f, 1, 2, 2, 1 });
        public static Type dragon = new Type("龙", "",
            new List<float> { 0, 1, 0.5f, 0.5f, 0.5f, 0.5f, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2 });

        public static List<Type> AllTypes = 
            new List<Type>() { typenone, normal, fire, water, grass, electr, ground, flying, fight, rock, rock, ice, steel, poison, bug, psychc, dark, ghost, dragon };
    }
}
