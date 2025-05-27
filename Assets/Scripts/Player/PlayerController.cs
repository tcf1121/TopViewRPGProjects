using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerStatus _player;

    [Header("Mouse Config")]
    [SerializeField][Range(0, 5)] private float _mouseSensitivity = 1;

    public Vector2 InputDirection { get; private set; }
    public Vector2 MouseDirection { get; private set; }

    private void Awake() => Init();

    private void Init()
    {
        _player = GetComponent<PlayerStatus>();
    }
    private void Update()
    {
        setMove();
    }
    private void setMove()
    {
        _player.Rigid.velocity = new Vector3(-InputDirection.y * _player.MoveSpeed, _player.Rigid.velocity.y, InputDirection.x * _player.MoveSpeed);
    }

    public void OnMove(InputValue value)
    {
        InputDirection = value.Get<Vector2>().normalized;

    }

    public void OnRotate(InputValue value)
    {
        Vector2 mouseDir = value.Get<Vector2>();
        mouseDir.y *= -1;
        MouseDirection = mouseDir * _mouseSensitivity;
    }
}
