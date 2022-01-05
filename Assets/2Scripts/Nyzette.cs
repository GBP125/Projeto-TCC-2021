using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nyzette : MonoBehaviour
{
    public bool NyzetteMorto = false;
    PlayerMove playNyzette;
    void Start(){
        playNyzette = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playNyzette.HPMover <= 0){
            NyzetteMorto = true;
        }
    }
}
