using UnityEngine;

namespace ScriptableValues
{
    [CreateAssetMenu(fileName = "New Renderer", menuName = "Data/New Scriptable Renderer")]
    public class ScriptableSpriteRenderer : ScriptableObject
    {

        public SpriteRenderer data;
    }
}

