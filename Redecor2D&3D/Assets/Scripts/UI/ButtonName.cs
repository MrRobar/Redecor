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

        public void SetID()
        {
            _selectedID.data = _id;
        }

        public void SetData(string buttonName)
        {
            _nameText.text = buttonName;
        }
    }
}