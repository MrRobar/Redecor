using UnityEngine;
using Events;

namespace Game.Managers
{

    public class CameraConstantWidth : MonoBehaviour
    {

        [SerializeField]
        private EventListener _updateEventListener;

        [SerializeField]
        private Vector2 DefaultResolution = new Vector2(720, 1280);
        
        [SerializeField]
        [Range(0f, 1f)] 
        private float WidthOrHeight = 0;

        private Camera componentCamera;

        private float initialSize;
        private float targetAspect;

        private float initialFov;
        private float horizontalFov = 120f;

        private void OnEnable()
        {
            _updateEventListener.OnEventHappened += CameraChoser;
        }

        private void OnDisable()
        {
            _updateEventListener.OnEventHappened -= CameraChoser;
        }

        private void Start()
        {
            componentCamera = GetComponent<Camera>();
            initialSize = componentCamera.orthographicSize;

            targetAspect = DefaultResolution.x / DefaultResolution.y;

            initialFov = componentCamera.fieldOfView;
            horizontalFov = CalcVerticalFov(initialFov, 1 / targetAspect);
        }

        private void CameraChoser()
        {
            if (componentCamera.orthographic)
            {
                float constantWidthSize = initialSize * (targetAspect / componentCamera.aspect);
                componentCamera.orthographicSize = Mathf.Lerp(constantWidthSize, initialSize, WidthOrHeight);
            }
            else
            {
                float constantWidthFov = CalcVerticalFov(horizontalFov, componentCamera.aspect);
                componentCamera.fieldOfView = Mathf.Lerp(constantWidthFov, initialFov, WidthOrHeight);
            }
        }

        private float CalcVerticalFov(float hFovInDeg, float aspectRatio)
        {
            float hFovInRads = hFovInDeg * Mathf.Deg2Rad;

            float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);

            return vFovInRads * Mathf.Rad2Deg;
        }
    }
}