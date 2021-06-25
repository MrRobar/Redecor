using UnityEngine.EventSystems;
using UnityEngine;
using Events;
using ScriptableValues;

namespace Game.UI
{

    public class MaterialsSwipe : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {

        [SerializeField]
        private EventDispatcher _swipeDispatcher;

        [SerializeField]
        private Vector2 _startPos = Vector2.zero;

        [SerializeField]
        private ScriptableIntValue _swipeData;

        [SerializeField]
        private int _addableSwipeDistance = 20;

        [SerializeField]
        private bool _isFingerDown = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            _startPos = Input.mousePosition;
            _isFingerDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_isFingerDown == true)
            {
                if (Input.mousePosition.x >= _startPos.x + _addableSwipeDistance)
                {
                    _isFingerDown = false;
                    _swipeData.data = -1;
                    _swipeDispatcher.Dispatch();
                }
                else if (Input.mousePosition.x <= _startPos.x - _addableSwipeDistance)
                {
                    _isFingerDown = false;
                    _swipeData.data = 1;
                    _swipeDispatcher.Dispatch();
                }
            }
        }
    }
}