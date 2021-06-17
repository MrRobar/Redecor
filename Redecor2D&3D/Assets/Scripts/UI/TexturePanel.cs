using Events;
using System.Collections.Generic;
using UnityEngine;
using ScriptableValues;

namespace Game.UI
{

    public class TexturePanel : MonoBehaviour
    {

        [SerializeField]
        private EventListener _updateTexturePanel;

        [SerializeField]
        private List<ScriptableCellInfo> _cellsInfo;

        [SerializeField]
        private Cell _cellToSpawn;

        public List<ScriptableCellInfo> CellsInfo
        {
            get { return _cellsInfo; }
            set { _cellsInfo = value; }
        }

        private void OnEnable()
        {
            _updateTexturePanel.OnEventHappened += ShowSprites;
        }

        private void OnDisable()
        {
            _updateTexturePanel.OnEventHappened -= ShowSprites;
        }

        private void ShowSprites()
        {
            ClearPanel();
            for (int i = 0; i < _cellsInfo.Count; i++)
            {
                var go = Instantiate(_cellToSpawn, transform);
                go.GetComponent<Cell>().ThisCellInfo = _cellsInfo[i];
            }
        }

        private void ClearPanel()
        {
            if(_cellsInfo.Count == 0)
            {
                return;
            }

            if (transform.childCount == 0)
            {
                return;
            }

            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}