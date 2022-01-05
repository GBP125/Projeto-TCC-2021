using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonAmour : MonoBehaviour
{
    public bool MonAmourMorto = false;
    PlayerMove playMonAmour;
    void Start(){
        playMonAmour = GetComponent<PlayerMove>();

    }

    // Update is called once per frame
    void Update()
    {
        if(playMonAmour.HPMover <= 0){
            MonAmourMorto = true;
        }
    }
}
