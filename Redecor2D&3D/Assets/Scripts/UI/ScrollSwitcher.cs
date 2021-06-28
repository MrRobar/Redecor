using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using ScriptableValues;

namespace Game.UI
{

    public class ScrollSwitcher : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {

        [SerializeField]
        private ScriptableVector2 _materialsContentVector;

        [SerializeField]
        private ScrollRect _materialsRect;

        [SerializeField]
        private RectTransform _contentTransform;

        [SerializeField]
        private SnapScrolling _snapScrollingScript;

        private Vector2 _startPos;


        public void OnEndDrag(PointerEventData eventData)
        {
            _materialsRect.horizontal = false;
            _materialsRect.vertical = false;
            _snapScrollingScript.isNativeScroll = true;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPos = Input.mousePosition;
            _snapScrollingScript.isNativeScroll = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(((Input.mousePosition.y > _startPos.y + 20f || Input.mousePosition.y < _startPos.y - 20f) && _materialsRect.horizontal == false)) 
            {
                _materialsRect.vertical = true;
                _materialsContentVector.data.y = _contentTransform.anchoredPosition.y;
                
            }
            else if ((Input.mousePosition.x > _startPos.x || Input.mousePosition.x < _startPos.x) && _materialsRect.vertical == false)
            {
                _materialsRect.horizontal = true;
                _materialsContentVector.data.x = Input.mousePosition.x;
            }
        }
    }
}