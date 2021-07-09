using UnityEngine;

namespace Game.UI
{

    public class ChoseThroughObject : MonoBehaviour
    {

        [SerializeField]
        private ChoseButton _toActivate;

        public void UpdateUI()
        {
            _toActivate.UpdateButtonSprite();
        }
    }
}