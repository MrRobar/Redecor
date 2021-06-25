using UnityEngine;

namespace ScriptableValues
{

    [CreateAssetMenu(fileName = "New Int", menuName = "Values/Int")]
    public class ScriptableIntValue : ScriptableObject
    {

        public int data;
    }
}