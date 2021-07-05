using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableValues;

namespace Game.Managers
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
            for (int i = 0; i < 8; i++)
            {
                Instantiate(_materialPrefab, _parent);
            }
        }
    }
}