using UnityEngine;

namespace ScriptableValues
{

    [CreateAssetMenu(fileName = "New Vector2", menuName = "Values/New Vector2")]
    public class ScriptableVector2 : ScriptableObject
    {

        public Vector2 data;
    }
}

