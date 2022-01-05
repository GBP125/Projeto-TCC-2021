using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class NewPlayerCanvas : MonoBehaviour
{
    public int CounterPlayer = 0;
    public bool PlayersReady = false;
    public GameObject[] press = new GameObject[4];
    public GameObject[] confirm = new GameObject[4];
    public GameObject Canva;
    public GameObject Gameplay, animacao;

    void Update(){
        CheckPlayer();
        CheckReady();
    }

    public void CheckPlayer(){
        if(CounterPlayer == 1){
            press[0].SetActive(false);
            confirm[0].SetActive(true);
        }
        else if(CounterPlayer == 2){
            press[1].SetActive(false);
            confirm[1].SetActive(true);
        }
        else if(CounterPlayer == 3){
            press[2].SetActive(false);
            confirm[2].SetActive(true);
        }
        else if(CounterPlayer >= 4){
            press[3].SetActive(false);
            confirm[3].SetActive(true);
            PlayersReady = true;
        }
    }

    public void CountPlayer(){
        CounterPlayer = CounterPlayer + 1;
    }

    public void CheckReady(){
        if(PlayersReady){
            Canva.SetActive(false);
            animacao.SetActive(true);
          
        }
    }
}
