using ScriptableValues;
using UnityEngine;
using Events;

namespace Game.Managers
{

    public class MaterialSettings : MonoBehaviour
    {

        [SerializeField]
        private ScriptableSpriteRenderer _rendererToChange;

        [SerializeField]
        private EventListener _updateEventListener;

        [SerializeField]
        private SpriteRenderer _thisRenderer;

        [SerializeField]
        private Material _defaultMaterial;

        [SerializeField]
        private Material _shaderMaterial;

        private void OnEnable()
        {
            _thisRenderer = GetComponent<SpriteRenderer>();
            _updateEventListener.OnEventHappened += CheckMaterial;
        }

        private void OnDisable()
        {
            _updateEventListener.OnEventHappened -= CheckMaterial;
        }

        private void CheckMaterial()
        {
            if(_rendererToChange.data == null)
            {
                return;
            }

            if(gameObject.name != _rendererToChange.data.gameObject.name)
            {
                _thisRenderer.material = _defaultMaterial;
            }
            else
            {
                _thisRenderer.material = _shaderMaterial;
            }
        }
    }
}