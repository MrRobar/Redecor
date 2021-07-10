using UnityEngine;

namespace ScriptableValues
{

    [CreateAssetMenu(menuName = "Values/Sprite", fileName = "New Sprite")]
    public class ScriptableSpriteValue : ScriptableObject
    {

        public Sprite data;
    }
}