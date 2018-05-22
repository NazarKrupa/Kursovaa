using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public int id;
    public Vector3 position;
    public Vector3 scale;
    public GameObject objectT;
    public bool lastPosition;
    public GameObject findHeibor;

    public List<GameObject> neibor = new List<GameObject>();
}
