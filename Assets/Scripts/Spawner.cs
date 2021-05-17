using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool instantiated = false;

    public int opening;

    private RoomsTemplates templates;

    private GameObject room;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Templates").GetComponent<RoomsTemplates>();

        Invoke("Spawn", 0.2f);
    }

    private void Spawn()
    {
        if(instantiated == true)
        {
            return;
        }

        instantiated = true;
        int rand = 0;


        // Has an up opening
        if(opening == 1)
        {
            rand = Random.Range(0, templates.roomsDown.Length);
            room = Instantiate(templates.roomsDown[rand], transform.position, Quaternion.identity);
        }
        // Has a right opening
        else if (opening == 2)
        {
            rand = Random.Range(0, templates.roomsLeft.Length);
            room = Instantiate(templates.roomsLeft[rand], transform.position, Quaternion.identity);
        }
        // Has a down opening
        else if (opening == 3)
        {
            rand = Random.Range(0, templates.roomsUp.Length);
            room = Instantiate(templates.roomsUp[rand], transform.position, Quaternion.identity);
        }
        // Has a left opening
        else if (opening == 4)
        {
            rand = Random.Range(0, templates.roomsRight.Length);
            room = Instantiate(templates.roomsRight[rand], transform.position, Quaternion.identity);
        }

        templates.AddRoom(room);
        Instantiate(templates.destroyer, transform.position, Quaternion.identity);

    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Colliding");

        if(other.gameObject.CompareTag("SpawnPoint"))
        {
            Spawner target = other.gameObject.GetComponent<Spawner>();

            if(target.instantiated == true)
            {
                Debug.Log("Allready instantiated");
                Destroy(gameObject);
            }
            else if (target.instantiated == false && instantiated == false)
            {
                Debug.Log("KILL TASK");
                Destroy(other.gameObject);

                Instantiate(templates.nowhereRoom, transform.position, Quaternion.identity);
            }
        }
    }
}
