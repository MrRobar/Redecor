﻿using UnityEngine;
using System.Collections.Generic;
using Events;
using ScriptableValues;
using Game.UI;

namespace Game.Managers
{
    public class ResourcesManager : MonoBehaviour
    {

        [SerializeField]
        private EventListener _lateUpdateEventListener;

        [SerializeField]
        private ScriptableIntValue _selectedID;

        [SerializeField]
        private Transform _materialsKeeperPrefab;

        [SerializeField]
        private Transform _namePrefab;

        [SerializeField]
        private Transform _materialsParent;

        [SerializeField]
        private Transform _namesParent;

        [SerializeField]
        private List<Transform> _keepersList = new List<Transform>();

        [SerializeField]
        private List<Transform> _namesList = new List<Transform>();

        [SerializeField]
        private RectTransform _namesContent;

        [SerializeField]
        private RectTransform _materialsContent;

        private Vector2[] _namesPositions;
        private Vector2[] _keepersPositions;

        private Vector2 _namesContentVector;
        private Vector2 _materialsContentVector;

        [SerializeField]
        private int _columns;
        
        [SerializeField]
        private int _snapSpeed;

        private void Awake()
        {
            _namesPositions = new Vector2[_columns];
            _keepersPositions = new Vector2[_columns];

            for (int i = 0; i < _columns; i++)
            {
                var keeper = Instantiate(_materialsKeeperPrefab, _materialsParent);
                var name = Instantiate(_namePrefab, _namesParent);
                _keepersList.Add(keeper);
                _namesList.Add(name);

                if(i == 0)
                {
                    continue;
                }

                keeper.localPosition = new Vector2(_keepersList[i - 1].localPosition.x + _materialsKeeperPrefab.GetComponent<RectTransform>().sizeDelta.x, _keepersList[i].localPosition.y);
                name.localPosition = new Vector2(_namesList[i - 1].localPosition.x + _namePrefab.GetComponent<RectTransform>().sizeDelta.x, _namesList[i].localPosition.y);
                name.GetComponent<ButtonName>().ID = i;
                _namesPositions[i] = -_namesList[i].transform.localPosition;
                _keepersPositions[i] = -_keepersList[i].transform.localPosition;
            }

            SetDefaultCategory();
        }

        private void OnEnable()
        {
            _lateUpdateEventListener.OnEventHappened += SetNearestID;
            _lateUpdateEventListener.OnEventHappened += CheckForEqualIndex;
        }

        private void OnDisable()
        {
            _lateUpdateEventListener.OnEventHappened -= SetNearestID;
            _lateUpdateEventListener.OnEventHappened -= CheckForEqualIndex;
        }

        private void SetNearestID() // Попробовать сравнивать Х < 270(половина NamesScroll)
        {
            float nearestPos = float.MaxValue;
            for (int i = 0; i < _columns; i++)
            {
                float distance = Mathf.Abs(_namesContent.anchoredPosition.x - _namesPositions[i].x);
                if (distance < nearestPos)
                {
                    nearestPos = distance;
                    _selectedID.data = i;
                }
            }
        }

        private void CheckForEqualIndex()
        {
            for (int i = 0; i < _columns; i++)
            {
                if(i == _selectedID.data)
                {
                    SetProperPack(i - 1);
                }
            }
        }

        private void SetProperPack(int index)
        {
            _materialsContentVector.x = Mathf.SmoothStep(_materialsContent.anchoredPosition.x, -(index * 540), _snapSpeed * Time.deltaTime);
            _materialsContent.anchoredPosition = _materialsContentVector;
        }

        private void SetDefaultCategory()
        {
            _namesContent.anchoredPosition = Vector2.zero;
            _materialsContent.anchoredPosition = Vector2.zero;
        }
    }
}