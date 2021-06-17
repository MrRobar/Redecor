using System.Collections.Generic;
using UnityEngine;
using Game.UI;
using Events;

namespace Game.Managers
{

    public class ButtonsSpritesRerseter : MonoBehaviour
    {

        [SerializeField]
        private EventListener _updateButtonsEventListener;

        [SerializeField]
        private List<ChoseButton> _buttonsImages;

        private void OnEnable()
        {
            _updateButtonsEventListener.OnEventHappened += ResetImages;
        }

        private void OnDisable()
        {
            _updateButtonsEventListener.OnEventHappened -= ResetImages;
        }

        private void ResetImages()
        {
            for (int i = 0; i < _buttonsImages.Count; i++)
            {
                _buttonsImages[i].ResetButtonSprite();
            }
        }
    }
}