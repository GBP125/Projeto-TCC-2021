using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseTest : MonoBehaviour
{

    public GameObject pauseMenu, optionsMenu;
    public GameObject pauseFirstButton, optionsFirstButton, optionsClosedButton;
    public GameObject Gameplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetButtonDown("Cancel"))     
         {
            PauseUnpause();
         }

    }

    public void PauseUnpause(){

        if (!pauseMenu.activeInHierarchy)
        {

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(pauseFirstButton);

        }
        else{

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        optionsMenu.SetActive(false);

        }
    }


    public void OpenOptions(){
    
        optionsMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void CloseOptions(){

        optionsMenu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(optionsClosedButton);

    }
    public void MainMenu(){

        SceneManager.LoadScene("Menu");

    }

    public void UnloadGame(){

        SceneManager.UnloadSceneAsync ("Gameplay");
    }
}