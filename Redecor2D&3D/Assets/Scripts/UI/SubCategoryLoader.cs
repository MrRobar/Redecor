using System.Collections.Generic;
using UnityEngine;
using ScriptableValues;

namespace Game.UI
{

    public class SubCategoryLoader : MonoBehaviour
    {

        [SerializeField]
        private List<ScriptableCellInfo> _infoToLoad = new List<ScriptableCellInfo>();

        [SerializeField]
        private Transform _materialPrefab;

        [SerializeField]
        private Transform _parent;

        private const float TEXT_HEIGHT = 40f;
        private const float SUBCATEGORY_HEIGHT_0FFSET = 150f;
        private const float SUBCATEGORY_WIDTH = 540f;
        private const float MATERIALS_IN_COLUMN = 4;

        public List<ScriptableCellInfo> InfoToLoad
        {
            get { return _infoToLoad; }
            set { _infoToLoad = value; }
        }

        public void InitializeData()
        {
            for (int i = 0; i < _infoToLoad.Count; i++)
            {
                var material = Instantiate(_materialPrefab, _parent);
                material.GetComponent<MaterialVariant>().ThisInfo = _infoToLoad[i];
            }
            SetSubCategoryHeight();
        }

        private void SetSubCategoryHeight()
        {
            var modifier = Mathf.Ceil(_parent.childCount / MATERIALS_IN_COLUMN);
            GetComponent<RectTransform>().sizeDelta = new Vector2(SUBCATEGORY_WIDTH, (modifier * SUBCATEGORY_HEIGHT_0FFSET) + TEXT_HEIGHT);
        }
    }
}