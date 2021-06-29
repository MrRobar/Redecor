using UnityEngine;
using Events;

namespace Game.Managers
{

    public class UpdateManager : MonoBehaviour
    {

        [SerializeField]
        private EventDispatcher _updateEventDispatcher;

        [SerializeField]
        private EventDispatcher _lateUpdateDispatcher;

        private void Update()
        {
            _updateEventDispatcher.Dispatch();
        }

        private void LateUpdate()
        {
            _lateUpdateDispatcher.Dispatch();
        }
    }
}

