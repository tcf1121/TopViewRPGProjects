using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerStatus _player;

    public Vector2 InputDirection { get; private set; }
    public Vector3 LookDirection { get; private set; }

    private void Awake() => Init();

    private void Init()
    {
        _player = GetComponent<PlayerStatus>();
    }
    private void Update()
    {
        SetMovement();
    }

    private void SetMovement()
    {
        SetMove();
        SetRotate();
    }

    private void SetMove()
    {
        //_player.Rigid.velocity = new Vector3(-InputDirection.y * _player.MoveSpeed, _player.Rigid.velocity.y, InputDirection.x * _player.MoveSpeed);
        Vector3 direction = new Vector3(-InputDirection.y, 0, InputDirection.x);
        transform.position += _player.MoveSpeed * Time.deltaTime * direction;
    }
    private void SetRotate()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointTolook = cameraRay.GetPoint(rayLength);
            LookDirection = new Vector3(pointTolook.x, transform.position.y, pointTolook.z);
            transform.LookAt(LookDirection);
        }
    }

    private void OnMove(InputValue value)
    {
        InputDirection = value.Get<Vector2>().normalized;
    }


    private void OnJump(InputValue value)
    {
        if (!_player.IsJump)
        {
            _player.IsJump = true;
            _player.Rigid.AddForce(Vector3.up * _player.JumpPower, ForceMode.Impulse);
        }
    }

    private void OnDash(InputValue value)
    {
        if (!_player.IsDoing[(int)doName.Dash])
        {
            _player.IsDoing[(int)doName.Dash] = true;
            _player.Rigid.AddForce(transform.forward * _player.DashPower, ForceMode.Impulse);
            StartCoroutine(CoolTime((int)doName.Dash, 3f));
        }
    }

    private void OnAttack(InputValue value)
    {
        Debug.Log("기본 공격 사용");
    }

    private void OnSkill1(InputValue value)
    {
        if (!_player.IsDoing[(int)doName.Skill1])
        {
            _player.IsDoing[(int)doName.Skill1] = true;
            Debug.Log("스킬 1 사용");
            StartCoroutine(CoolTime((int)doName.Skill1, 3f));
        }
    }

    private void OnSkill2(InputValue value)
    {
        if (!_player.IsDoing[(int)doName.Skill2])
        {
            _player.IsDoing[(int)doName.Skill2] = true;
            Debug.Log("스킬 2 사용");
            StartCoroutine(CoolTime((int)doName.Skill2, 3f));
        }
    }

    private void OnSkill3(InputValue value)
    {
        if (!_player.IsDoing[(int)doName.Skill3])
        {
            _player.IsDoing[(int)doName.Skill3] = true;
            Debug.Log("스킬 3 사용");
            StartCoroutine(CoolTime((int)doName.Skill3, 3f));
        }
    }

    private void OnNum1(InputValue value)
    {
        if (!_player.IsDoing[(int)doName.Num1])
        {
            _player.IsDoing[(int)doName.Num1] = true;
            Debug.Log("아이템 1 사용");
            StartCoroutine(CoolTime((int)doName.Num1, 3f));
        }
    }

    private void OnNum2(InputValue value)
    {
        if (!_player.IsDoing[(int)doName.Num2])
        {
            _player.IsDoing[(int)doName.Num2] = true;
            Debug.Log("아이템 2 사용");
            StartCoroutine(CoolTime((int)doName.Num2, 3f));
        }
    }

    private void OnNum3(InputValue value)
    {
        if (!_player.IsDoing[(int)doName.Num3])
        {
            _player.IsDoing[(int)doName.Num3] = true;
            Debug.Log("아이템 3 사용");
            StartCoroutine(CoolTime((int)doName.Num3, 3f));
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            _player.IsJump = false;
    }

    private IEnumerator CoolTime(int doNum, float time)
    {
        while (time > 0.0f)
        {
            time -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        _player.IsDoing[doNum] = false;
    }

}
