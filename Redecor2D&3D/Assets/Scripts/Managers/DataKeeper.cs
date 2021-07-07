using System.Collections.Generic;
using UnityEngine;
using ScriptableValues;
using Events;

namespace Game.Managers
{

    public class DataKeeper : MonoBehaviour
    {

        public List<string> categoriesNames = new List<string>();

        public List<ScriptableCategory> categories = new List<ScriptableCategory>();

        [SerializeField]
        private EventDispatcher _spawnCategoriesDispatcher;

        public void DispatchEvent()
        {
            _spawnCategoriesDispatcher.Dispatch();
        }
    }
}