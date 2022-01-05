using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneLoad : MonoBehaviour
{
    void OnEnable(){

        SceneManager.LoadScene("Cutscenes", LoadSceneMode.Single);

    }
}
