using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VoltarMenuBtn : MonoBehaviour
{
    public GameObject Menu_BTNS, ComoJogar_BTNS;

    public GameObject comoFirstButton, ajustesFirstButton, sobreFirstButton, extrasFirstButton;

   public void TelaJogo()
   {
       SceneManager.LoadScene("Gameplay");
   }

    public void ComoJogar(){
        //EventSystems.current.SetSelectedGameObject(null);
        //EventSystems.current.SetSelectedGameObject(comoFirstButton);
        
    }
}
