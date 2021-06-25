using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.UI
{

    public class SnapScrolling : MonoBehaviour
    {

        [SerializeField]
        private GameObject _categoryZonePrefab;

        [SerializeField]
        private ScrollRect _scrollView;

        [SerializeField]
        private int _categoryZonesCount;

        [SerializeField]
        private int _categoryZoneOffset;

        [SerializeField]
        private int _snapSpeed;

        private int _selectedZoneID = 0;

        private GameObject[] _instantiatedZones;

        private Vector2[] _zonesPositions;

        private Vector2 _contentVector;

        private RectTransform _contentRect;

        private bool _isScrolling;

        private bool _initialized = false;

        private void Awake()
        {
            _instantiatedZones = new GameObject[_categoryZonesCount];
            _zonesPositions = new Vector2[_categoryZonesCount];
            _contentRect = GetComponent<RectTransform>();

            for (int i = 0; i < _categoryZonesCount; i++)
            {
                _instantiatedZones[i] = Instantiate(_categoryZonePrefab, transform, false);
                _instantiatedZones[i].name += i.ToString();
                if(i == 0)
                {
                    continue;
                }
                _instantiatedZones[i].transform.localPosition = new Vector2(_instantiatedZones[i - 1].transform.localPosition.x + _categoryZonePrefab.GetComponent<RectTransform>().sizeDelta.x + _categoryZoneOffset, _instantiatedZones[i].transform.localPosition.y);
                _zonesPositions[i] =  -_instantiatedZones[i].transform.localPosition;
            }

            SetDefaultCategory();
        }

        private void Update()
        {
            #region SetTextColor&Enable/DisableBlueLine
            if (_initialized == true)
            {
                
                for (int i = 0; i < _categoryZonesCount; i++)
                {
                    _instantiatedZones[i].transform.GetChild(1).gameObject.SetActive(false);
                    _instantiatedZones[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.4f, 0.4f, 0.4f);
                    if (i == _selectedZoneID)
                    {
                        _instantiatedZones[i].transform.GetChild(1).gameObject.SetActive(true);
                        _instantiatedZones[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0f, 0f, 0f);
                    }
                }
            }
            #endregion
        }

        private void LateUpdate()
        {
            #region ResetInertia
            if ((_contentRect.anchoredPosition.x >= _zonesPositions[0].x || _contentRect.anchoredPosition.x <= _zonesPositions[_zonesPositions.Length - 1].x) && !_isScrolling)
            {
                _scrollView.inertia = false;
            }
            #endregion

            #region SetSelectedID
            float nearestPos = float.MaxValue;
            for (int i = 0; i < _categoryZonesCount; i++)
            {
                float distance = Mathf.Abs(_contentRect.anchoredPosition.x - _zonesPositions[i].x);
                if(distance < nearestPos)
                {
                    nearestPos = distance;
                    _selectedZoneID = i;
                }
            }
            #endregion

            #region AvoidingJittering
            float scrollVelocity = Mathf.Abs(_scrollView.velocity.x);
            if(scrollVelocity < 300 && !_isScrolling)
            {
                _scrollView.inertia = false;
            }
            #endregion

            //Чтобы контент не привязывался к ближжайшей панели пока мы скролим
            if (_isScrolling == true)
            {
                return;
            }

            #region SetContentPosition
            _contentVector.x = Mathf.SmoothStep(_contentRect.anchoredPosition.x, _zonesPositions[_selectedZoneID].x, _snapSpeed * Time.deltaTime);
            _contentRect.anchoredPosition = _contentVector;
            #endregion
        }

        public void Scrolling(bool isScroll)
        {
            _isScrolling = isScroll;
            if (isScroll)
            {
                _scrollView.inertia = true;
            }
        }

        private void SetDefaultCategory()
        {
            _contentRect.anchoredPosition = Vector2.zero;
            _initialized = true;
        }
    }
}