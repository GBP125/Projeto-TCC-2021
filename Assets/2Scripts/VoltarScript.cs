using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class VoltarScript : MonoBehaviour
{
    public GameObject menu, ajustes, sobre, comoJogar;
    public GameObject jogarButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        teste();    
    }

    public void teste(){

           
        if (Input.GetButtonDown("Fire3")){

            ajustesClose();
            sobreClose();
            comoJogarClose();
            OpenMenu();
              
        }
 
    }

    

    public void ajustesClose(){
    
        ajustes.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(jogarButton);
    }

    public void sobreClose(){
    
        sobre.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(jogarButton);
    }  

    public void comoJogarClose(){
    
        comoJogar.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(jogarButton);
    }         

    public void OpenMenu(){

        menu.SetActive(true);

    }
}
