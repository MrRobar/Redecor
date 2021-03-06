using UnityEngine;

namespace ScriptableValues
{

    [CreateAssetMenu(fileName = ("New Cell Info"), menuName = ("Values/Cell Info"))]
    public class ScriptableCellInfo : ScriptableObject
    {

        public Sprite spriteToShow;

        public Sprite spriteToSet;

        public Sprite spriteBlocked;

        public int cost;

        public int amount;

        public string matName;

        public string categoryName;
    }
}

