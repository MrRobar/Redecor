using Events;
using UnityEngine;
using ScriptableValues;
using Game.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Game.Managers
{

    public class Raycaster : MonoBehaviour
    {

        [SerializeField]
        private EventListener _updateEventListener;

        [SerializeField]
        private ScriptableSpriteRenderer _spriteToChange;

        [SerializeField]
        private Camera thisCamera;


        private void OnEnable()
        {
            _updateEventListener.OnEventHappened += ChooseRenderer;
        }

        private void OnDisable()
        {
            _updateEventListener.OnEventHappened -= ChooseRenderer;
        }

        private void ChooseRenderer()
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (IsPointerOverUIObject())
                {
                    return;
                }

                Vector3 worldPoint = thisCamera.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                if (hit.collider != null)
                {
                    _spriteToChange.data = hit.collider.GetComponent<SpriteRenderer>();
                    hit.collider.GetComponent<ChoseThroughObject>().UpdateUI();
                }
            }
        }

        private bool IsPointerOverUIObject()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
#if !ANDROID
            eventDataCurrentPosition.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
#else
        eventDataCurrentPosition.position = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
#endif
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }
    }
}