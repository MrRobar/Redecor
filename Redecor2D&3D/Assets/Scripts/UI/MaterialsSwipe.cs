using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class MaterialsSwipe : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField]
    private Vector2 _startPos = Vector2.zero;

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
                Debug.Log("Swipe left");
            }
            else if (Input.mousePosition.x <= _startPos.x - _addableSwipeDistance)
            {
                _isFingerDown = false;
                Debug.Log("Swipe right");
            }
        }
    }
}