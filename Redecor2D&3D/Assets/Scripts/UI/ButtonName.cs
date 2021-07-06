using System.Collections;
using UnityEngine;
using ScriptableValues;
using UnityEngine.UI;
using TMPro;

namespace Game.UI
{
    public class ButtonName : MonoBehaviour
    {

        [SerializeField]
        private ScriptableIntValue _selectedID;

        [SerializeField]
        private ScriptableCellInfo _cellInfo;

        [SerializeField]
        private int _id;

        [SerializeField]
        private Button _thisButton;

        [SerializeField]
        private TextMeshProUGUI _nameText;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public ScriptableCellInfo CellInfo
        {
            get { return _cellInfo; }
            set { _cellInfo = value; }
        }

        private void OnEnable()
        {
            //StartCoroutine(SetData());
        }

        public void SetID()
        {
            _selectedID.data = _id;
        }

        private IEnumerator SetData()
        {
            yield return new WaitForSeconds(0.001f);
            _nameText.text = _cellInfo.categoryName;
        }
    }
}