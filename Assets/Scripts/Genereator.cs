using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genereator : MonoBehaviour {

    public Creator creator;
    public RoomController controller;

    public List<Room> rooms = new List<Room>();

    // for 2 generate metod
    public int countRoom;
    public Vector3 normalazePosition;

    bool[,] map = new bool[10,10];

    private void Start()
    {
        GenerateRandomPosition();
    }

    public void GenerateRandom()
    {
        creator.DeleteRoom();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                int index = Random.Range(0, 2);
                creator.Create(index, new Vector2(i, j), new Vector2(1,1));

                Debug.Log(index + new Vector2(i, j).ToString());
            }
        }
    }

    public void GenerateRandomPosition()
    {
        creator.DeleteRoom();

        for (int i = 0; i < countRoom; i++)
        {
            Room room = creator.Create(1, new Vector2(Random.Range(0, 30), Random.Range(0, 30)), new Vector2(Random.Range(5,15), Random.Range(5,15)));
            rooms.Add(room);
        }

        controller.SetRoom(rooms);
    }
}
