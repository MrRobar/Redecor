using System.Collections;
using UnityEngine;
using ScriptableValues;
using TMPro;
using UnityEngine.UI;

namespace Game.UI
{
    public class MaterialVariant : MonoBehaviour
    {

        [SerializeField]
        private ScriptableSpriteRenderer _objectToChange;

        [SerializeField]
        private ScriptableCellInfo _thisInfo;

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
            _objectToChange.data.sprite = _thisInfo.spriteToSet;
        }

        IEnumerator LoadData()
        {
            yield return new WaitForSeconds(0.001f);
            transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = _thisInfo.matName;
            transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = _thisInfo.cost.ToString();
            transform.GetChild(0).GetComponent<Image>().sprite = _thisInfo.spriteToShow;
        }
    }
}