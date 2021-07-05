using UnityEngine;

namespace Game.UI
{

    public class SubCategorySpawner : MonoBehaviour
    {

        [SerializeField]
        private int _subCategoriesAmount;

        [SerializeField]
        private Transform _subCategory;

        [SerializeField]
        private Transform _parent;

        private void OnEnable()
        {
            for (int i = 0; i < _subCategoriesAmount; i++)
            {
                Instantiate(_subCategory, _parent);
            }
        }
    }
}