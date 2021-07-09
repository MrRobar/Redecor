using UnityEngine;
using ScriptableValues;
using TMPro;

namespace Game.UI
{

    public class SubCategorySpawner : MonoBehaviour
    {

        [SerializeField]
        private Transform _subCategory;

        [SerializeField]
        private RectTransform _parent;

        [SerializeField]
        private ScriptableCategory _categoryData;

        public ScriptableCategory CategoryData
        {
            get { return _categoryData; }
            set { _categoryData = value; }
        }

        public void SpawnCategories()
        {
            for (int i = 0; i < _categoryData.subCategoriesAmount; i++)
            {
                var go = Instantiate(_subCategory, _parent);
                go.name = "SubCategory " + i.ToString();
                go.GetComponent<SubCategoryLoader>().InfoToLoad = _categoryData.subCategories[i].infoToLoad;
                go.GetChild(1).GetComponent<TextMeshProUGUI>().text = _categoryData.subCategories[i].subCategoryName;
                go.GetComponent<SubCategoryLoader>().InitializeData();
            }
            _parent.anchoredPosition = new Vector2(0f, 0f);
        }
    }
}