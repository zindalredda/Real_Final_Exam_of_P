using System;
using UnityEngine;

namespace Day
{
    public static class CardSpriteReturner
    {
        public static Sprite ReturnCardSprite(this CardMainTypeEnum mainType, string subType)
        {
            var (src, index) = mainType switch
            {
                CardMainTypeEnum.Major => ("Cards/Major", GetMajorIndex(subType)),
                CardMainTypeEnum.Liberal => ("Cards/Liberal", GetLiberalIndex(subType)),
                CardMainTypeEnum.Play => ("Cards/Play", GetPlayIndex(subType)),
                CardMainTypeEnum.Work => ("Cards/Work", GetWorkIndex(subType)),
                _ => throw new ArgumentOutOfRangeException(nameof(mainType), mainType, null)
            };

            return Resources.LoadAll<Sprite>(src)[index];
        }

        private static int GetMajorIndex(string subType) => subType switch
        {
            "herb" => 0,
            "trans" => 1,
            "potion" => 2,
            "fly" => 3,
            "defense" => 4,
            "summon" => 5,
            "zoo" => 6,
            _ => throw new ArgumentOutOfRangeException(nameof(subType), subType, "Unknown major subtype.")
        };

        private static int GetLiberalIndex(string subType) => subType switch
        {
            "magic1" or "magic2" => 0,
            "rune1" or "rune2" => 1,
            "dot1" or "dot2" => 2,
            "history1" or "history2" => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(subType), subType, "Unknown liberal subtype.")
        };

        private static int GetPlayIndex(string subType) => subType switch
        {
            "cat1" or "cat2" => 0,
            "apple1" or "apple2" => 1,
            "origami1" or "origami2" => 2,
            "cafe1" or "cafe2" => 3,
            "karaoke1" or "karaoke2" => 4,
            "game1" or "game2" => 5,
            _ => throw new ArgumentOutOfRangeException(nameof(subType), subType, "Unknown play subtype.")
        };

        private static int GetWorkIndex(string subType) => subType switch
        {
            "water1" or "water2" => 0,
            "make1" or "make2" => 1,
            "collect" => 2,
            "doll" => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(subType), subType, "Unknown work subtype.")
        };
    }
}