using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UniRx;
using Zenject;
using TMPro;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void LateUpdate()
    {
        if (_target != null)
        {
            virtualCamera.Follow = _target;
        }
    }
}
