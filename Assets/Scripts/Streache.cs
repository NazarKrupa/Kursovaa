using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streache : MonoBehaviour {


    public List<GameObject> nei = new List<GameObject>();
    public RoomController controller;
    public float strength = 0.1f;
    public Vector3 startPosition;

    public bool stop;
    public int id;

    private void Start()
    {
        startPosition = transform.position;
        stop = false;
        controller = GameObject.Find("Level").GetComponent<RoomController>();
    }

    private void Update()
    {
        if (stop)
        {
            //Debug.Log("Stoped");
            return;
        }


        if (nei.Count > 0)
        {
            for (int i = 0; i < nei.Count; i++)
            {
               // Debug.Log("Итерация идет");
                Vector3 direction = transform.position - nei[i].transform.position;
                direction.Normalize();

                transform.position = new Vector3(Mathf.Round(transform.position.x + (direction.x * strength)), transform.position.y, Mathf.Round(transform.position.z + (direction.z * strength)));
            }
        }
        else
        {
            //Debug.Log("Соседи не найдены");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "room")
        {
            //Debug.Log("Обьект слишком близко");
            if (stop)
                stop = false;

            nei.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "room")
        {
            //Debug.Log("Кто-то вышел из триггера");
            for (int i = 0; i < nei.Count; i++)
            {
                if (nei[i] == other.gameObject)
                    nei.Remove(nei[i]);
            }

            if (nei.Count == 0)
            {
                stop = true;
                controller.DoneMovePlatform(id);
                //Cheack the neibor
            }
        }
    }
}
