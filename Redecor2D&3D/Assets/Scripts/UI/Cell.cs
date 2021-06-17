using UnityEngine.UI;
using UnityEngine;
using ScriptableValues;
using TMPro;
using Events;
using System.Collections;

namespace Game.UI
{

    public class Cell : MonoBehaviour
    {

        [SerializeField]
        private EventListener _setDataToCellEventListener;

        [SerializeField]
        private ScriptableCellInfo _thisCellInfo;

        [SerializeField]
        private ScriptableSpriteRenderer _spriteToChange;

        [SerializeField]
        private Image _cellImage;

        [SerializeField]
        private TextMeshProUGUI _moneyText;

        [SerializeField]
        private Button _cellButton;

        public ScriptableCellInfo ThisCellInfo 
        {
            get { return _thisCellInfo; }
            set { _thisCellInfo = value; }
        }

        private void OnEnable()
        {
            _setDataToCellEventListener.OnEventHappened += SetData;
            _cellButton.onClick.AddListener(SetTextureToObject);
        }

        private void OnDisable()
        {
            _setDataToCellEventListener.OnEventHappened -= SetData;
        }

        private void SetData()
        {
            StartCoroutine(SetDataCoroutine());
        }

        private void SetTextureToObject()
        {
            _spriteToChange.data.sprite = _thisCellInfo.spriteToSet;
        }

        private IEnumerator SetDataCoroutine()
        {
            yield return new WaitForSeconds(0.0001f);
            _cellImage.sprite = _thisCellInfo.spriteToShow;
            _moneyText.text = _thisCellInfo.cost.ToString();
        }
    }
}