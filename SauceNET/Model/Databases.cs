using System.Collections.Generic;

namespace SauceNET.Model
{
    public static class Databases
    {
        public static Dictionary<int, string> DatabaseNames { get; }

        static Databases()
        {
            DatabaseNames = new Dictionary<int, string>
            {
                {0, "H-Magazines"},
                {2, "H-Game CG" },
                {3, "The Doujinshi & Manga Lexicon" },
                {4, "Pixiv" },
                {5, "Pixiv" },
                {51, "Pixiv" },
                {52, "Pixiv" },
                {6, "Pixiv" },
                {7, "???" },
                {8, "Nico Nico Seiga" },
                {9, "Danbooru" },
                {10, "drawr" },
                {11, "Nijite" },
                {12, "Yande.re" },
                {13, "Openings.moe" },
                {15, "Shuttershock" },
                {16, "FAKKU" },
                {18, "nHentai" },
                {19, "2D-Market" },
                {20, "MediBang" },
                {21, "AniDb" },
                {211, "AniDb" },
                {22, "H-Anime" },
                {23, "IMDb" },
                {24, "Shows" },
                {25, "Gelbooru" },
                {26, "Konachan" },
                {27, "Sankaku Channel" },
                {28, "Anime-Pictures" },
                {29, "e621" },
                {30, "Sankaku Channel" },
                {31, "bcy.net" },
                {32, "bcy.net" },
                {33, "PortalGraphics" },
                {34, "deviantArt" },
                {35, "Pawoo" },
                {36, "Madokami" },
                {37, "MangaDex" },
                {38, "E-hentai" }
            };
        }
    }
}
