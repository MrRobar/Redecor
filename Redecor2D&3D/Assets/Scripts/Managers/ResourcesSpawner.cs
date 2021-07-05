using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Managers
{

    public class ResourcesSpawner : MonoBehaviour
    {

        [SerializeField]
        private int _categoriesAmount = 7;

        [SerializeField]
        private int _materialsAmount;

        [SerializeField]
        private Transform _namePrefab;

        [SerializeField]
        private Transform _materialsKeeper;

        [SerializeField]
        private Transform _materialPrefab;

        [SerializeField]
        private RectTransform _namesContent;

        [SerializeField]
        private RectTransform _materialsContent;

        [SerializeField]
        private RectTransform _empty;

        private void Awake()
        {
            SpawnCategories();
        }

        private void SpawnCategories()
        {
            for (int i = 0; i < _categoriesAmount; i++)
            {
                Instantiate(_namePrefab, _namesContent);
                Instantiate(_materialsKeeper, _materialsContent);
            }
            Instantiate(_empty, _namesContent);
            Instantiate(_empty, _materialsContent);
        }
    }
}