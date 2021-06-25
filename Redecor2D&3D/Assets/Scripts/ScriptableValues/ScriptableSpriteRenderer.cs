using UnityEngine;

namespace ScriptableValues
{
    [CreateAssetMenu(fileName = "New Renderer", menuName = "Values/New Scriptable Renderer")]
    public class ScriptableSpriteRenderer : ScriptableObject
    {

        public SpriteRenderer data;
    }
}