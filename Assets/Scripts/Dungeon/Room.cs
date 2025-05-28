using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] public RoomType RoomType;
    [SerializeField] public Vector2Int RoomPos;
    [SerializeField] public GameObject[] DoorWall;
    [SerializeField] public GameObject[] NoDoorWall;


    public Room(RoomType roomType, Vector2Int roomPos)
    {
        RoomType = roomType;
        RoomPos = roomPos;
    }

    public void SetRoom(RoomType roomType, Vector2Int roomPos)
    {
        RoomType = roomType;
        RoomPos = roomPos;
    }

    public void LinkedRoom(Room[,] rooms)
    {
        if (RoomPos.y - 1 > 0)
            if (rooms[RoomPos.x, RoomPos.y - 1] != null)
            {
                NoDoorWall[0].SetActive(false);
                DoorWall[0].SetActive(true);
            }

        if (RoomPos.y + 1 < 20)
            if (rooms[RoomPos.x, RoomPos.y + 1] != null)
            {
                NoDoorWall[1].SetActive(false);
                DoorWall[1].SetActive(true);
            }

        if (RoomPos.x - 1 > 0)
            if (rooms[RoomPos.x - 1, RoomPos.y] != null)
            {
                NoDoorWall[2].SetActive(false);
                DoorWall[2].SetActive(true);
            }
        if (RoomPos.x + 1 < 20)
            if (rooms[RoomPos.x + 1, RoomPos.y] != null)
            {
                NoDoorWall[3].SetActive(false);
                DoorWall[3].SetActive(true);
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