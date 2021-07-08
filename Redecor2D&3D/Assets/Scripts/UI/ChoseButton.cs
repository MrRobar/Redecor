using UnityEngine;
using UnityEngine.UI;
using Events;
using ScriptableValues;
using Game.Managers;

namespace Game.UI
{

    [RequireComponent(typeof(Button))]
    public class ChoseButton : MonoBehaviour
    {

        [SerializeField]
        private EventDispatcher _updateButtonsDispatcher;

        [SerializeField]
        private ScriptableSpriteRenderer _rendererToSet;

        [SerializeField]
        private SpritesSender _spritesSender;

        [SerializeField]
        private SpriteRenderer _correspondingRenderer;

        [SerializeField]
        private Button _thisButton;

        [SerializeField]
        private Image _buttonImage;

        [SerializeField]
        private Sprite _defaultButtonSprite;

        [SerializeField]
        private Sprite _activeButtonSprite;

        private void Awake()
        {
            _thisButton = GetComponent<Button>();
            _spritesSender = GetComponent<SpritesSender>();
            _thisButton.onClick.AddListener(UpdateButtonSprite);
            _thisButton.onClick.AddListener(SetDataToSO);
        }

        private void SetDataToSO()
        {
            _rendererToSet.data = _correspondingRenderer;
        }

        public void UpdateButtonSprite()
        {
            _updateButtonsDispatcher.Dispatch();
            _buttonImage.sprite = _activeButtonSprite;
            _spritesSender.SendSprites();
        }


        public void ResetButtonSprite()
        {
            _buttonImage.sprite = _defaultButtonSprite;
        }
    }
}