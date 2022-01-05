using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marai : MonoBehaviour
{
    public bool MaraiMorto = false;
    PlayerMove playMarai;
    void Start(){
        playMarai = GetComponent<PlayerMove>();

    }

    // Update is called once per frame
    void Update()
    {
        if(playMarai.HPMover <= 0){
            MaraiMorto = true;
        }
    }
}
