using UnityEngine;
using Events;

namespace Game.UI
{

    public class ScrollReader : MonoBehaviour
    {

        [SerializeField]
        private EventListener _updateEventListener;

        [SerializeField]
        private GameObject _categoryPrefab;

        [SerializeField]
        private Transform _categoryPanel;

        [SerializeField]
        private bool _isScrolling = false;

        [SerializeField]
        private int _categoriesAmont;

        [SerializeField]
        private int _sizeDeltaX = 160;

        private GameObject[] _categoriesInstances;


        private void Awake()
        {
            _categoriesInstances = new GameObject[_categoriesAmont];
            for (int i = 0; i < _categoriesAmont; i++)
            {
                _categoriesInstances[i] = Instantiate(_categoryPrefab, _categoryPanel, false);
                if(i == 0)
                {
                    continue;
                }
                _categoriesInstances[i].transform.localPosition = new Vector2(_categoriesInstances[i - 1].transform.localPosition.x + _sizeDeltaX, transform.localPosition.y);
            }
        }

        private void OnEnable()
        {
            _updateEventListener.OnEventHappened += CheckOutScrolling;
        }

        private void OnDisable()
        {
            _updateEventListener.OnEventHappened -= CheckOutScrolling;
        }

        private void CheckOutScrolling()
        {
            if (Input.GetMouseButton(0))
            {
                _isScrolling = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _isScrolling = false;
            }
        }
    }
}