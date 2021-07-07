using UnityEngine;
using Game.Managers;
using Events;

namespace Game.UI
{

    public class ChoseThroughObject : MonoBehaviour
    {

        [SerializeField]
        private ChoseButton _toActivate;

        [SerializeField]
        private SpritesSender _spriteSender;

        public void UpdateUI()
        {
            _toActivate.UpdateButtonSprite();
            _spriteSender.SendSprites();
        }
    }
}