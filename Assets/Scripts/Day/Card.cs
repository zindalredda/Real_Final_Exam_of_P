using Common;
using UnityEngine;

namespace Day
{
    public class Card : MonoBehaviour
    {
        [Header("Card Data")]
        public CardMainTypeEnum mainType;
        public string subType;
        public int stress;
        public int time;
        public Prs prs;
        [ReadOnly][SerializeField] private Sprite sprite;
        
        
        
    }
}
