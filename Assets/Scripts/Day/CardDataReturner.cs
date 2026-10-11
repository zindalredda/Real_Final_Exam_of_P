using System.Collections.Generic;
using Common;
using UnityEngine;
using static Day.CardMainTypeEnum;

namespace Day
{
    public static class CardDataReturner
    {
        private static readonly Dictionary<CardMainTypeEnum, Sprite[]> SpriteCache = new();

        public static Card SpawnCard(this Card prefab, CardMainTypeEnum mainType, string subType, Transform parent = null)
        {
            var instance = Object.Instantiate(prefab, parent);
            instance.Setup(mainType, subType);
            return instance;
        }

        public static Card SpawnCard(this Card prefab, CardData data, Transform parent = null)
        {
            var instance = Object.Instantiate(prefab, parent);
            instance.Setup(data);
            return instance;
        }

        public static CardData ReturnCardData(this CardMainTypeEnum mainType, string subType)
        {
            var (time, stress) = (mainType, subType) switch
            {
                (Major, _) => (4, 3),
                (Liberal, _) => (2, 3),
                (Work, _) => (6, 6),
                (Play, "cat1" or "cat2") => (1, -4),
                (Play, "apple1" or "apple2") => (2, -4),
                (Play, "origami1" or "origami2" or "cafe1" or "cafe2") => (3, -4),
                (Play, "karaoke1" or "karaoke2") => (4, -4),
                (Play, "game1" or "game2") => (5, -4),
                _ => throw new OutOfRange(nameof(subType), subType, $"Unknown card type or subtype: {mainType}/{subType}")
            };

            return new CardData
            {
                mainType = mainType,
                subType = subType,
                time = time,
                stress = stress,
                sprite = mainType.ReturnCardSprite(subType)
            };
        }

        public static Sprite ReturnCardSprite(this CardMainTypeEnum mainType, string subType)
        {
            if (!SpriteCache.TryGetValue(mainType, out var sprites))
            {
                sprites = Resources.LoadAll<Sprite>($"Cards/{mainType}");
                SpriteCache[mainType] = sprites;
            }

            int index = GetSpriteIndex(mainType, subType);
            return sprites[index];
        }

        private static int GetSpriteIndex(CardMainTypeEnum mainType, string subType) => (mainType, subType) switch
        {
            (Major, "herb") => 0,
            (Major, "trans") => 1,
            (Major, "potion") => 2,
            (Major, "fly") => 3,
            (Major, "defense") => 4,
            (Major, "summon") => 5,
            (Major, "zoo") => 6,

            (Liberal, "magic1" or "magic2") => 0,
            (Liberal, "rune1" or "rune2") => 1,
            (Liberal, "dot1" or "dot2") => 2,
            (Liberal, "history1" or "history2") => 3,

            (Play, "cat1" or "cat2") => 0,
            (Play, "apple1" or "apple2") => 1,
            (Play, "origami1" or "origami2") => 2,
            (Play, "cafe1" or "cafe2") => 3,
            (Play, "karaoke1" or "karaoke2") => 4,
            (Play, "game1" or "game2") => 5,

            (Work, "water1" or "water2") => 0,
            (Work, "make1" or "make2") => 1,
            (Work, "collect") => 2,
            (Work, "doll") => 3,

            _ => throw new OutOfRange(nameof(subType), subType, $"Unknown subtype: {mainType}/{subType}")
        };
    }
}
