using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologo : MonoBehaviour
{
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNextScene", time);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) ||  Input.GetKeyDown(KeyCode.Escape))
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("Bioma01");
    }
}
