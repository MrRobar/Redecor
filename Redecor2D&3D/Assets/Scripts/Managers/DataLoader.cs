using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableValues;

namespace Game.Managers
{

    public class DataLoader : MonoBehaviour
    {

        public List<string> categoriesNames = new List<string>();

        public List<ScriptableCategory> categories = new List<ScriptableCategory>();
    }
}