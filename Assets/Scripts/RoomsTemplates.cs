using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsTemplates : MonoBehaviour
{
    public GameObject[] roomsUp;
    public GameObject[] roomsDown;
    public GameObject[] roomsLeft;
    public GameObject[] roomsRight;

    public GameObject nowhereRoom;
    public GameObject destroyer;

    private List<GameObject> instantiatedRooms;


    private void Start()
    {
        instantiatedRooms = new List<GameObject>();
        Invoke("CreationFinished", 6f);
    }

    public void AddRoom(GameObject room)
    {
        instantiatedRooms.Add(room);
    }

    public GameObject LastRoom()
    {
        return instantiatedRooms[instantiatedRooms.Count-1]; 
    }

    public void CreationFinished()
    {
        Debug.Log(instantiatedRooms.Count);

        instantiatedRooms[instantiatedRooms.Count-1].GetComponent<RoomController>().LastRoom();
    }
}
