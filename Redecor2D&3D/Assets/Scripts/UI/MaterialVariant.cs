using System.Collections;
using UnityEngine;
using ScriptableValues;
using TMPro;
using UnityEngine.UI;
using Events;

namespace Game.UI
{

    public class MaterialVariant : MonoBehaviour
    {

        [SerializeField]
        private EventDispatcher _processDataDispatcher;

        [SerializeField]
        private ScriptableSpriteRenderer _objectToChange;

        [SerializeField]
        private ScriptableSpriteValue _spriteToSet;

        [SerializeField]
        private ScriptableSpriteValue _defaultSprite;

        [SerializeField]
        private ScriptableCellInfo _thisInfo;

        [SerializeField]
        private Image _spriteToShow;

        [SerializeField]
        private TextMeshProUGUI _costText;

        [SerializeField]
        private TextMeshProUGUI _materialName;

        [SerializeField]
        private TextMeshProUGUI _amountText;

        public ScriptableCellInfo ThisInfo
        {
            get { return _thisInfo; }
            set { _thisInfo = value; }
        }

        private void OnEnable()
        {
            StartCoroutine(LoadData());
        }

        public void SetSpriteToObject()
        {
            _spriteToSet.data = _thisInfo.spriteToSet;
            _processDataDispatcher.Dispatch();
            _defaultSprite.data = _thisInfo.spriteToSet;
        }

        IEnumerator LoadData()
        {
            yield return new WaitForSeconds(0.001f);
            _materialName.text = _thisInfo.matName;
            _costText.text = _thisInfo.cost.ToString();
            _amountText.text = _thisInfo.amount.ToString();
            _spriteToShow.sprite = _thisInfo.spriteToShow;
        }
    }
}