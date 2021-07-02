using UnityEngine;
using System.Collections.Generic;
using Events;
using ScriptableValues;
using Game.UI;
using TMPro;

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

        [SerializeField]
        private RectTransform _empty;

        private Vector2[] _namesPositions;
        private Vector2[] _keepersPositions;

        private Vector2 _namesContentVector;
        private Vector2 _materialsContentVector;

        [SerializeField]
        private int _columns;
        
        [SerializeField]
        private int _snapSpeed;

        [SerializeField]
        private int _namesOffset = 80;

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
                name.localPosition = new Vector2(_namesList[i - 1].localPosition.x + _namePrefab.GetComponent<RectTransform>().sizeDelta.x + _namesOffset, _namesList[i].localPosition.y);
                name.GetComponent<ButtonName>().ID = i;
                _namesPositions[i] = -_namesList[i].transform.localPosition;
                _keepersPositions[i] = -_keepersList[i].transform.localPosition;
            }
            Instantiate(_empty, _namesParent);
        }

        private void OnEnable()
        {
            _lateUpdateEventListener.OnEventHappened += SetNearestID;
            _lateUpdateEventListener.OnEventHappened += CheckForEqualIndex;
            _lateUpdateEventListener.OnEventHappened += EditNameState;
        }

        private void OnDisable()
        {
            _lateUpdateEventListener.OnEventHappened -= SetNearestID;
            _lateUpdateEventListener.OnEventHappened -= CheckForEqualIndex;
            _lateUpdateEventListener.OnEventHappened -= EditNameState;
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
                    SetProperName(i);
                    SetProperPack(i);
                }
            }
        }

        private void SetProperName(int index)
        {
            _namesContentVector.x = Mathf.SmoothStep(_namesContent.anchoredPosition.x, -(index * 200), _snapSpeed * Time.deltaTime);
            _namesContent.anchoredPosition = _namesContentVector;
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

        private void EditNameState()
        {
            for (int i = 0; i < _columns; i++)
            {
                _namesList[i].transform.GetChild(0).gameObject.SetActive(false);
                _namesList[i].transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.4f, 0.4f, 0.4f);
                if (i == _selectedID.data)
                {
                    _namesList[i].transform.GetChild(0).gameObject.SetActive(true);
                    _namesList[i].transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0f, 0f, 0f);
                }
            }
        }
    }
}