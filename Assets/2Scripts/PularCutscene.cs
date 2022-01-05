using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PularCutscene : MonoBehaviour
{

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && Input.GetButtonDown("Fire3"))     
         {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
         }
    }
}
