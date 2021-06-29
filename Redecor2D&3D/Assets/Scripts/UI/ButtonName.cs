using UnityEngine;
using ScriptableValues;
using UnityEngine.UI;

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

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public void SetID()
        {
            _selectedID.data = _id;
        }
    }
}