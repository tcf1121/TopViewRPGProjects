using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 10)]
    public float MoveSpeed { get; set; }

    [field: SerializeField]
    [field: Range(0, 10)]
    public float JumpPower { get; set; }

    [field: SerializeField]
    [field: Range(0, 10)]
    public float DashPower { get; set; }
    [field: SerializeField]
    [field: Range(0, 500)]
    public int MaxHP { get; set; }

    [field: SerializeField] public int Damage { get; set; }
    public Vector2 InputDirection;
    public Rigidbody Rigid;
    public Animator Animator;

    public bool IsJump;
    public bool[] IsDoing = new bool[7];
}

public enum doName
{
    Dash,
    Skill1,
    Skill2,
    Skill3,
    Num1,
    Num2,
    Num3
}
