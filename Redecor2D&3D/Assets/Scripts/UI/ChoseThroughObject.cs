using UnityEngine;
using Game.Managers;

namespace Game.UI
{

    public class ChoseThroughObject : MonoBehaviour
    {

        [SerializeField]
        private ChoseButton _toActivate;

        [SerializeField]
        private SpritesSender _spritesSender;

        public void UpdateUI()
        {
            _toActivate.UpdateButtonSprite();
            _spritesSender.SendSprites();
        }
    }
}