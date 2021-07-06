using UnityEngine;
using ScriptableValues;
using System.Collections;
using Events;
using TMPro;

namespace Game.UI
{

    public class SubCategorySpawner : MonoBehaviour
    {

        [SerializeField]
        private EventDispatcher _spawnedCategoriesDispatcher;

        [SerializeField]
        private Transform _subCategory;

        [SerializeField]
        private Transform _parent;

        [SerializeField]
        private ScriptableCategory _categoryData;

        public ScriptableCategory CategoryData
        {
            get { return _categoryData; }
            set { _categoryData = value; }
        }

        private void OnEnable()
        {
            StartCoroutine(SpawnCategories());
        }

        private IEnumerator SpawnCategories()
        {
            yield return new WaitForSeconds(0.001f);
            for (int i = 0; i < _categoryData.subCategoriesAmount; i++)
            {
                var go = Instantiate(_subCategory, _parent);
                go.GetComponent<SubCategoryLoader>().InfoToLoad = _categoryData.subCategories[i].infoToLoad;
                go.GetChild(1).GetComponent<TextMeshProUGUI>().text = _categoryData.subCategories[i].subCategoryName;
            }
            _spawnedCategoriesDispatcher.Dispatch();
        }
    }
}