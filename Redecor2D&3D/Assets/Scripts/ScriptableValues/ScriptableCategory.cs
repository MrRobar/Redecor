using System.Collections.Generic;
using UnityEngine;

namespace ScriptableValues
{

    [CreateAssetMenu(fileName = "New Category", menuName = "Data/Category")]
    public class ScriptableCategory : ScriptableObject
    {

        public string categoryName;

        public int subCategoriesAmount;

        public List<SubCategory> subCategories;
    }

    [System.Serializable]
    public class SubCategory
    {
        public string subCategoryName;
        public List<ScriptableCellInfo> infoToLoad;
    }
}