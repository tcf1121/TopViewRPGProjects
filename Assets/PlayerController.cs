using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigibody;

    [Header("Mouse Config")]
    [SerializeField][Range(0, 5)] private float _mouseSensitivity = 1;

    public Vector2 InputDirection { get; private set; }
    public Vector2 MouseDirection { get; private set; }

    private void Awake() => Init();

    private void Init()
    {
        _rigibody = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        InputDirection = value.Get<Vector2>();
    }

    public void OnRotate(InputValue value)
    {
        Vector2 mouseDir = value.Get<Vector2>();
        mouseDir.y *= -1;
        MouseDirection = mouseDir * _mouseSensitivity;
    }
}
