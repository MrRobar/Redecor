using UnityEngine;
using Events;

public class ClearPanels : MonoBehaviour
{


    [SerializeField]
    private EventListener _clearPanelsEventListener;

    [SerializeField]
    private EventDispatcher _spawnResourcesDispatcher;

    [SerializeField]
    private Transform _namesParent;

    [SerializeField]
    private Transform _materialsParent;

    private void OnEnable()
    {
        _clearPanelsEventListener.OnEventHappened += ClearPanelsMethod;
    }

    private void OnDisable()
    {
        _clearPanelsEventListener.OnEventHappened -= ClearPanelsMethod;
    }

    private void ClearPanelsMethod()
    {
        if (_namesParent.childCount != 0 && _materialsParent.childCount != 0)
        {
            for (int i = 0; i < _namesParent.childCount; i++)
            {
                Destroy(_namesParent.GetChild(i).gameObject);
            }
            for (int i = 0; i < _materialsParent.childCount; i++)
            {
                Destroy(_materialsParent.GetChild(i).gameObject);
            }
            Debug.Log("Deleted");
        }
        _spawnResourcesDispatcher.Dispatch();
    }
}
