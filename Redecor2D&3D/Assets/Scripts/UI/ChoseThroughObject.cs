using UnityEngine;
using Game.Managers;

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