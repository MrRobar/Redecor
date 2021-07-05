using System.Collections;
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

        private void OnEnable()
        {
            for (int i = 0; i < _infoToLoad.Count; i++)
            {
                var material = Instantiate(_materialPrefab, _parent);
            }
        }
    }
}