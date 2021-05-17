using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] toSpawn;


    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, toSpawn.Length);

        Instantiate(toSpawn[rand], transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
