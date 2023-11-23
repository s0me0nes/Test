using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UniRx;
using Zenject;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private int _coins = 0;

    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private InputAction _moveAction;

    [Inject]
    private ReactiveProperty<int> _coinCount;

    [Inject]
    private TextMeshProUGUI _coinText;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _moveAction = new InputAction("move", binding: "<Gamepad>/leftStick");
        _moveAction.performed += OnMovePerformed;
        _moveAction.canceled += OnMoveCanceled;
        _moveAction.Enable();
    }

    private void OnDestroy()
    {
        _moveAction.Disable();
        _moveAction.performed -= OnMovePerformed;
        _moveAction.canceled -= OnMoveCanceled;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _moveInput = Vector2.zero;
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveInput * _moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _coins += coin._value;
            coin.PlayCollectSound();
            Destroy(coin.gameObject);

            _coinCount.Value = _coins;
        }
    }
}