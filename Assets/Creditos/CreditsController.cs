using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey || Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(0);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(0);
    }
}
