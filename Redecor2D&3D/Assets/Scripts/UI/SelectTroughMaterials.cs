using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTroughMaterials : MonoBehaviour
{

    [SerializeField]
    private int _categoryZonesCount;

    [SerializeField]
    private RectTransform _contentRect;

    [SerializeField]
    private Vector2[] _zonesPositions;

    private int _selectedZoneID;

    private void Awake()
    {
        _zonesPositions = new Vector2[_categoryZonesCount];
    }

    // Update is called once per frame
    void Update()
    {
        float nearestPos = float.MaxValue;
        for (int i = 0; i < _categoryZonesCount; i++)
        {
            float distance = Mathf.Abs(_contentRect.anchoredPosition.x - _zonesPositions[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                _selectedZoneID = i;
                Debug.Log("Current: " + i);
            }
        }
    }
}
