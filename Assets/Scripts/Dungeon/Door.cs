using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private MeshRenderer _renderer;
    public Vector2Int RoomPos = new();

    public void SetDoor(Vector2Int roomPos)
    {
        RoomPos = roomPos;
    }

    public void SetTrigger(bool trigger, Material material)
    {
        _collider.isTrigger = trigger;
        _renderer.material = material;
    }
}
