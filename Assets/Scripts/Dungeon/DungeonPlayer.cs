using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DungeonPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private PlayerToDungeon _playerToDungeon;
    [SerializeField] private CinemachineVirtualCamera _camera;
    private Room[,] _roomArray = new Room[20, 20];
    void Awake()
    {
        _player.gameObject.transform.position = new Vector3(0, 0, 0);
        _playerToDungeon = _player.AddComponent<PlayerToDungeon>();
        _playerToDungeon.DungeonPos = new Vector2Int(10, 10);
        _playerToDungeon.DungeonPlayer = this;
    }

    public void SetRoomArray(Room[,] roomArray)
    {
        _roomArray = roomArray;
    }

    public void ChangeRoom(Vector2Int pos)
    {
        _camera.Follow = _roomArray[pos.x, pos.y].gameObject.transform;
    }

}
