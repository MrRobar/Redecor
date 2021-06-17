using UnityEngine.UI;
using UnityEngine;

namespace ScriptableValues
{

    [CreateAssetMenu(fileName = "New  Image", menuName = "Values/ScriptableImage")]
    public class ScriptableImage : ScriptableObject
    {

        public Image data;
    }
}

