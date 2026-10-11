using Common;
using UnityEngine;

namespace Day
{
    public class Card : MonoBehaviour
    {
        [Header("Card Data")]
        public CardData cardData;

        [Header("Visual")]
        [ReadOnly] [SerializeField] private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            if (spriteRenderer == null)
            {
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            }
        }

        public void Setup(CardMainTypeEnum mainType, string subType)
        {
            cardData = mainType.ReturnCardData(subType);
            ApplyVisual();
        }

        public void Setup(CardData data)
        {
            cardData = data;
            ApplyVisual();
        }

        public void ApplyVisual()
        {
            if (cardData == null) return;

            if (spriteRenderer == null)
            {
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            }

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = cardData.sprite;
            }

            if (cardData.prs != null)
            {
                transform.localPosition = cardData.prs.pos;
                transform.localRotation = cardData.prs.rot;
                if (cardData.prs.scale != Vector3.zero)
                {
                    transform.localScale = cardData.prs.scale;
                }
            }
        }
    }
}
