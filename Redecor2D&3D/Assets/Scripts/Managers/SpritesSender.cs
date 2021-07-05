using Events;
using Game.UI;
using UnityEngine;
using ScriptableValues;
using System.Collections.Generic;

namespace Game.Managers
{
    public class SpritesSender : MonoBehaviour
    {

        [SerializeField]
        private Transform _texturesPanel;

        [SerializeField]
        private EventDispatcher _updateTexturePanelDispatcher;

        [SerializeField]
        private EventDispatcher _setDataToCellDispatcher;


        [SerializeField]
        private List<ScriptableCellInfo> _cellsInfo;

        public void SendSprites()
        {
            _texturesPanel.GetComponent<TexturePanel>().CellsInfo = _cellsInfo;
            _updateTexturePanelDispatcher.Dispatch();
            _setDataToCellDispatcher.Dispatch();
        }
    }
}