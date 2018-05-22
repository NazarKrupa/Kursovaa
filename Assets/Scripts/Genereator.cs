using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                int scalex = Random.Range(2, 5);
                int scalez = Random.Range(2, 5);
                creator.Create(index, new Vector2(i, j), scalex,scalez);

                Debug.Log(index + new Vector2(i, j).ToString());
            }
        }
    }

    public void GenerateRandomPosition()
    {
        creator.DeleteRoom();

        for (int i = 0; i < countRoom; i++)
        {
            Room room = creator.Create(1, new Vector2(Random.Range(30, 60), Random.Range(30, 60)), Random.Range(15, 25),  Random.Range(15,25));
            rooms.Add(room);
        }

        controller.SetRoom(rooms);
    }


    public void DrawCorridor()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            int neiCount = rooms[i].objectT.transform.GetChild(0).gameObject.GetComponent<FindNeirborder>().nei.Count;
            Debug.Log("Draw corridor index: " + i + "Count nei" + neiCount);

            if (neiCount > 0)
            {
                for (int j = 0; j < neiCount; j++)
                {

                    creator.CreateCorridor(rooms[i].objectT.transform, rooms[i].objectT.transform.GetChild(0).gameObject.GetComponent<FindNeirborder>().nei[j].transform);
                    int id_connect2 = rooms[i].objectT.transform.GetChild(0).gameObject.GetComponent<FindNeirborder>().nei[j].GetComponent<Streache>().id;
                    int id_connect1 = rooms[i].id;
                    Debug.Log(id_connect1 + " " + id_connect2);
                    //rooms[i].neibor.Add(needConnect);
                }
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("TestAlgoritm", LoadSceneMode.Single);
    }
}
