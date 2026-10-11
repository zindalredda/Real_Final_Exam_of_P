using System;
using UnityEngine;

namespace Day
{
    public static class CardDataReturner
    {
        public static CardData ReturnCardData(this CardMainTypeEnum mainType, string subType)
        {
            var cardData = new CardData();

            var (time, stress) = mainType switch
            {
                CardMainTypeEnum.Major => (4, 3),
                CardMainTypeEnum.Liberal => (2, 3),
                CardMainTypeEnum.Play => (
                    subType switch
                    {
                        "cat1" or "cat2" => 1,
                        "apple1" or "apple2" => 2,
                        "origami1" or "origami2" => 3,
                        "cafe1" or "cafe2" => 3,
                        "karaoke1" or "karaoke2" => 4,
                        "game1" or "game2" => 5,
                        _ => throw new ArgumentOutOfRangeException(nameof(subType), subType, "Unknown play subtype.")
                    },
                    -4),
                CardMainTypeEnum.Work => (6, 6),
                _ => throw new ArgumentOutOfRangeException(nameof(mainType), mainType, null)
            };

            cardData.time = time;
            cardData.stress = stress;
            return cardData;
        }
    }
}
