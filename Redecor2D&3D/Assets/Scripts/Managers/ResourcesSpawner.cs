using UnityEngine;
using System.Collections.Generic;

namespace Game.Managers
{
    public class ResourcesSpawner : MonoBehaviour
    {

        [SerializeField]
        private Transform _materialsKeeperPrefab;

        [SerializeField]
        private Transform _namePrefab;

        [SerializeField]
        private Transform _materialsParent;

        [SerializeField]
        private Transform _namesParent;

        [SerializeField]
        private List<Transform> _keepersList = new List<Transform>();

        [SerializeField]
        private List<Transform> _namesList = new List<Transform>();

        [SerializeField]
        private int _columns;

        private void Awake()
        {
            for (int i = 0; i < _columns; i++)
            {
                var keeper = Instantiate(_materialsKeeperPrefab, _materialsParent);
                var name = Instantiate(_namePrefab, _namesParent);
                _keepersList.Add(keeper);
                _namesList.Add(name);

                if(i == 0)
                {
                    continue;
                }

                keeper.localPosition = new Vector2(_keepersList[i - 1].localPosition.x + _materialsKeeperPrefab.GetComponent<RectTransform>().sizeDelta.x, _keepersList[i].localPosition.y);
                name.localPosition = new Vector2(_namesList[i - 1].localPosition.x + _namePrefab.GetComponent<RectTransform>().sizeDelta.x, _namesList[i].localPosition.y);
            }    
        }
    }
}