using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    [SerializeField] public RoomType RoomType;
    [SerializeField] public Material[] RoomMaterial;
    [SerializeField] public Vector2Int RoomPos;
    [SerializeField] public GameObject[] DoorWall;
    [SerializeField] public GameObject[] NoDoorWall;
    [SerializeField] private Door[] _doors;

    public bool isClear;
    UnityAction<bool> IsClear;

    private void OnEnable()
    {
        IsClear += Clear;
    }

    private void OnDisable()
    {
        IsClear -= Clear;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isClear = !isClear;
            IsClear.Invoke(isClear);
        }
    }

    public Room(RoomType roomType, Vector2Int roomPos)
    {
        RoomType = roomType;
        RoomPos = roomPos;
    }

    public void SetDoor(Vector2Int roomPos)
    {
        foreach (Door door in _doors)
        {
            door.SetDoor(roomPos);
        }
    }

    public void LinkedRoom(Room[,] rooms)
    {
        if (RoomPos.y - 1 > 0)
            if (rooms[RoomPos.x, RoomPos.y - 1] == null)
            {
                NoDoorWall[0].SetActive(true);
                DoorWall[0].SetActive(false);
            }

        if (RoomPos.y + 1 < 20)
            if (rooms[RoomPos.x, RoomPos.y + 1] == null)
            {
                NoDoorWall[1].SetActive(true);
                DoorWall[1].SetActive(false);
            }

        if (RoomPos.x - 1 > 0)
            if (rooms[RoomPos.x - 1, RoomPos.y] == null)
            {
                NoDoorWall[2].SetActive(true);
                DoorWall[2].SetActive(false);
            }
        if (RoomPos.x + 1 < 20)
            if (rooms[RoomPos.x + 1, RoomPos.y] == null)
            {
                NoDoorWall[3].SetActive(true);
                DoorWall[3].SetActive(false);
            }
    }

    public void Clear(bool Clear)
    {
        if (Clear)
        {
            foreach (GameObject wall in DoorWall)
            {
                if (wall.activeSelf)
                    _doors[Array.IndexOf(DoorWall, wall)].SetTrigger(true, RoomMaterial[1]);
            }
        }
        else
        {
            foreach (GameObject wall in DoorWall)
            {
                if (wall.activeSelf)
                    _doors[Array.IndexOf(DoorWall, wall)].SetTrigger(false, RoomMaterial[0]);
            }
        }
    }

}

public enum RoomType
{
    Normal, // 기본 방
    Portal, // 포탈 방
    Boss,   // 보스 방
    Pitfall,// 함정 방
    Treasure// 보물 방
}