using UnityEngine;
using ScriptableValues;
using Events;

namespace Game.UI
{

    public class ChangeCategory : MonoBehaviour
    {

        [SerializeField]
        private EventListener _swipeEventListener;

        [SerializeField]
        private ScriptableIntValue _swipeData;

        [SerializeField]
        private RectTransform _namePanel;

        [SerializeField]
        private RectTransform _materialsPanel;

        [SerializeField]
        private int _scrollSpeed = 10;

        private Vector2 _contentVector = Vector2.zero;

        private void OnEnable()
        {
            _swipeEventListener.OnEventHappened += MoveData;
        }

        private void OnDisable()
        {
            _swipeEventListener.OnEventHappened -= MoveData;
        }

        private void Update()
        {
            MoveData();
        }

        private void MoveData()
        {
            _contentVector.x = Mathf.SmoothStep(_namePanel.anchoredPosition.x, _namePanel.anchoredPosition.x - (500 * _swipeData.data), _scrollSpeed * Time.deltaTime);
            _contentVector.y = _namePanel.transform.localPosition.y;
            _namePanel.anchoredPosition = _contentVector;
            Debug.Log("Moving");
        }
    }
}