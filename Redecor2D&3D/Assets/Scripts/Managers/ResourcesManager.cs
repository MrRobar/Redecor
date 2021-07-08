using UnityEngine;
using System.Collections;
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
        private EventListener _subCategoriesSpawned;

        [SerializeField]
        private EventListener _spawnCategoriesEventListener;

        [SerializeField]
        private ScriptableIntValue _selectedID;

        [SerializeField]
        private ScriptableBool _isScrolling;

        [SerializeField]
        private DataKeeper _dataKeeper;

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
        private Vector2[] _materialsPositions;

        private Vector2 _namesContentVector;
        private Vector2 _materialsContentVector;
        
        [SerializeField]
        private int _snapSpeed;

        [SerializeField]
        private bool _isScrollingViaNames = true;

        private void OnEnable()
        {
            _spawnCategoriesEventListener.OnEventHappened += LoadCategories;
            _subCategoriesSpawned.OnEventHappened += ResetMaterialsContentPos;
            LateUpdateSubscribeToEvents();
        }

        private void OnDisable()
        {
            _spawnCategoriesEventListener.OnEventHappened -= LoadCategories;
            _subCategoriesSpawned.OnEventHappened -= ResetMaterialsContentPos;
            LateUpdateUnSubscribeToEvent();
        }

        private void LateUpdateSubscribeToEvents()
        {
            _lateUpdateEventListener.OnEventHappened += SetNearestID;
            _lateUpdateEventListener.OnEventHappened += CheckForEqualIndex;
            _lateUpdateEventListener.OnEventHappened += EditNameState;
            _lateUpdateEventListener.OnEventHappened += ResetScroll;
        }

        private void LateUpdateUnSubscribeToEvent()
        {
            _lateUpdateEventListener.OnEventHappened -= SetNearestID;
            _lateUpdateEventListener.OnEventHappened -= CheckForEqualIndex;
            _lateUpdateEventListener.OnEventHappened -= EditNameState;
            _lateUpdateEventListener.OnEventHappened -= ResetScroll;
        }

        private void LoadCategories()
        {
            if(_namesParent.childCount != 0 || _materialsParent.childCount != 0)
            {
                foreach(Transform go in _namesParent)
                {
                    Destroy(go.gameObject);
                }

                foreach (Transform go in _materialsParent)
                {
                    Destroy(go.gameObject);
                }
                _namesList.Clear();
                _keepersList.Clear();
            }

            _namesPositions = new Vector2[_dataKeeper.categories.Count];
            _materialsPositions = new Vector2[_dataKeeper.categories.Count];

            for (int i = 0; i < _dataKeeper.categories.Count; i++)
            {
                var keeper = Instantiate(_materialsKeeperPrefab, _materialsParent);
                var name = Instantiate(_namePrefab, _namesParent);
                name.localPosition = new Vector3(0f, 0f, 0f);
                _keepersList.Add(keeper);
                _namesList.Add(name);

                if (i == 0)
                {
                    continue;
                }

                keeper.localPosition = new Vector2(_keepersList[i - 1].localPosition.x + _materialsKeeperPrefab.GetComponent<RectTransform>().sizeDelta.x, _keepersList[i].localPosition.y);
                name.localPosition = new Vector2(_namesList[i - 1].localPosition.x + _namePrefab.GetComponent<RectTransform>().sizeDelta.x, _namesList[i].localPosition.y);
                name.GetComponent<ButtonName>().ID = i;
                _namesPositions[i] = -_namesList[i].transform.localPosition;
                _materialsPositions[i] = -_keepersList[i].transform.localPosition;
            }
            for (int i = 0; i < _dataKeeper.categories.Count; i++)
            {
                _keepersList[i].GetComponent<SubCategorySpawner>().CategoryData = _dataKeeper.categories[i];
                _keepersList[i].GetComponent<SubCategorySpawner>().SpawnCategories();
                _namesList[i].GetComponent<ButtonName>().SetData(_dataKeeper.categoriesNames[i]);
            }
            Instantiate(_empty, _namesParent);
            Instantiate(_empty, _materialsParent);
        }

        private void ResetMaterialsContentPos()
        {
            StartCoroutine(ResetContentPos());
        }

        private void SetNearestID() 
        {
            if(_dataKeeper.categories.Count == 0 || _dataKeeper.categoriesNames.Count == 0)
            {
                return;
            }

            float nearestPos = float.MaxValue;
            for (int i = 0; i < _dataKeeper.categories.Count; i++)
            {
                float namesDistance = Mathf.Abs(_namesContent.anchoredPosition.x - _namesPositions[i].x);
                float materialsDistance = Mathf.Abs(_materialsContent.anchoredPosition.x - _materialsPositions[i].x);
                if (namesDistance < nearestPos && _isScrollingViaNames == true)
                {
                    nearestPos = namesDistance;
                    _selectedID.data = i;
                }
                if(materialsDistance < nearestPos && _isScrollingViaNames == false)
                {
                    nearestPos = materialsDistance;
                    _selectedID.data = i;
                }
            }
        }

        private void CheckForEqualIndex()
        {
            //if (_dataKeeper.categories.Count == 0 || _dataKeeper.categoriesNames.Count == 0)
            //{
            //    return;
            //}

            for (int i = 0; i < _dataKeeper.categories.Count; i++)
            {
                if(i == _selectedID.data)
                {
                    if(_isScrolling.data == true)
                    {
                        return;
                    }
                    SetProperPack(i);
                    SetProperName(i);
                }
            }
        }

        private void SetProperName(int index)
        {
            _namesContentVector.x = Mathf.SmoothStep(_namesContent.anchoredPosition.x, -(index * 200), _snapSpeed * 2 * Time.deltaTime);
            _namesContent.anchoredPosition = _namesContentVector;
        }

        private void SetProperPack(int index)
        {
            _materialsContentVector.x = Mathf.SmoothStep(_materialsContent.anchoredPosition.x, -(index * 540), _snapSpeed * Time.deltaTime);
            _materialsContent.anchoredPosition = _materialsContentVector;
        }

        private void EditNameState()
        {
            if (_dataKeeper.categories.Count == 0 || _dataKeeper.categoriesNames.Count == 0 || _namesList.Count == 0)
            {
                return;
            }

            for (int i = 0; i < _dataKeeper.categories.Count; i++)
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

        private void ResetScroll()
        {
            if (Input.GetMouseButtonUp(0))
            {
                _isScrollingViaNames = true;
            }
        }
        
        public void SetScrollBool(bool scrolling)
        {
            _isScrollingViaNames = scrolling;
        }

        private IEnumerator ResetContentPos()
        {
            yield return new WaitForSeconds(0.001f);
            for (int i = 0; i < _dataKeeper.categories.Count; i++)
            {
                _keepersList[i].GetChild(0).GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(300f, -368.5f);
            }
        }
    }
}