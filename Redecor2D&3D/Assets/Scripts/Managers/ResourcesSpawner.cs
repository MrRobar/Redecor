using UnityEngine;

namespace Game.Managers
{
    public class ResourcesSpawner : MonoBehaviour
    {

        [SerializeField]
        private Transform _materialsKeeperPrefab;

        [SerializeField]
        private int _rows;

        [SerializeField]
        private int _columns;

        private void Awake()
        {
            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    
                }
            }    
        }
    }
}