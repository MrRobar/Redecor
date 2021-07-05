using UnityEngine;
using Events;
using ScriptableValues;

namespace Game.Managers
{

    public class ScrollSetter : MonoBehaviour
    {

        [SerializeField]
        private EventListener _updateEventListener;

        [SerializeField]
        private ScriptableBool _isScrolling;


        private void OnEnable()
        {
            _updateEventListener.OnEventHappened += SetScroll;
        }

        private void OnDisable()
        {
            _updateEventListener.OnEventHappened -= SetScroll;
        }

        private void SetScroll()
        {
            _isScrolling.data = Input.GetMouseButton(0);
        }
    }
}