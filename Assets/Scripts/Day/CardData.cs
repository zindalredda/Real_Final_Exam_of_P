using Common;
using UnityEngine;

namespace Day
{
    [System.Serializable]
    public class CardData
    {
        public CardMainTypeEnum mainType = CardMainTypeEnum.Major;
        public string subType = string.Empty;
        public int stress = 0;
        public int time = 0;
        public Prs prs = new();
        public Sprite sprite = null;
    }
}