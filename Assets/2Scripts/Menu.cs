using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject menu, ajustes, sobre, comoJogar;
    public GameObject ajustesFirstButton, sobreFirstButton, comoJogarFirstButton, ajustesClosedButton, sobreClosedButton, comoJogarClosedButton;




    public void OpenAjustes(){
    
        ajustes.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(ajustesFirstButton);
    }

    public void TelaJogo(){
        
        SceneManager.LoadScene("Gameplay");
        Time.timeScale = 1f;

    }
    

    public void CloseAjustes(){

        
        ajustes.SetActive(false);
        


        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(ajustesClosedButton);

    }

    public void OpenSobre(){
    
        

        sobre.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(sobreFirstButton);
    }

    public void CloseSobre(){

        sobre.SetActive(false);
        

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(sobreClosedButton);
    }

    public void OpenComoJogar(){
    
        comoJogar.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(comoJogarFirstButton);
    }

    public void CloseComoJogar(){

        comoJogar.SetActive(false);
        

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(comoJogarClosedButton);
    }    

    public void CloseMenu(){

        menu.SetActive(false);

    }

    public void OpenMenu(){

        menu.SetActive(true);

    }
}

