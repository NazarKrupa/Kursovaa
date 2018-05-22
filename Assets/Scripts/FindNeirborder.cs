using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNeirborder : MonoBehaviour {

    public List<GameObject> nei = new List<GameObject>();
    public List<GameObject> connectNei = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "room")
        {
            //Debug.Log("Обьект слишком близко");
            //if (find)
                //find = false;

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

        }
    }


}
