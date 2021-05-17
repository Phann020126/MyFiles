using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject target;
    public GameObject firePlace;

    public void LastRoom()
    {
        if(target == null)
        {
            Debug.Log("no se encntro en la habitacion " + gameObject.name);
            return;
        }

        Debug.Log("Succesfully");
        Instantiate(firePlace, target.transform.position, Quaternion.identity);
    }
}
