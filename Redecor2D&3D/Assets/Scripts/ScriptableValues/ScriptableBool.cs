using UnityEngine;

namespace ScriptableValues
{

    [CreateAssetMenu(fileName = "New Bool", menuName = "Values/Bool")]
    public class ScriptableBool : ScriptableObject
    {

        public bool data;
    }
}