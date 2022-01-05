using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOptions : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject Canvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {   
                Debug.Log("despauso");
                Resume();
                
            } else
            {
                Debug.Log("pauso");
                Pause();
            }
        }
    }

    public void Resume ()
    {
        Canvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause ()
    {
        Canvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void TelaMenu(){
        
        Canvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }


}
