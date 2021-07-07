using UnityEngine;
using ScriptableValues;
using System.Collections.Generic;

namespace Game.Managers
{
    public class SpritesSender : MonoBehaviour
    {

        [SerializeField]
        private DataKeeper _dataKeeper;

        [SerializeField]
        private List<ScriptableCategory> _categories;

        public void SendSprites()
        {
            _dataKeeper.categories = _categories;
            _dataKeeper.categoriesNames.Clear();
            for (int i = 0; i < _categories.Count; i++)
            {
                _dataKeeper.categoriesNames.Add(_categories[i].categoryName);
            }
            _dataKeeper.DispatchEvent();
        }
    }
}