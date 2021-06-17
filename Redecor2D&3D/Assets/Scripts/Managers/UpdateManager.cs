using UnityEngine;
using Events;

namespace Game.Managers
{

    public class UpdateManager : MonoBehaviour
    {

        [SerializeField]
        private EventDispatcher _updateEventDispatcher;

        private void Update()
        {
            _updateEventDispatcher.Dispatch();
        }
    }
}

