using ScriptableValues;
using UnityEngine;

namespace Game.Managers
{

    public class ClearSO : MonoBehaviour
    {

        [SerializeField]
        private ScriptableSpriteRenderer _renderer;

        private void Awake()
        {
            _renderer.data = null;
        }
    }
}

