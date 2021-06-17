using UnityEngine;

namespace ScriptableValues
{

    [CreateAssetMenu(fileName = ("New Cell Info"), menuName = ("Values/Cell Info"))]
    public class ScriptableCellInfo : ScriptableObject
    {

        public Sprite spriteToShow;

        public Sprite spriteToSet;

        public int cost;
    }
}

