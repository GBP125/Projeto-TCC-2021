using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maquiavel : MonoBehaviour
{
    public bool MaquiavelMorto = false;
    PlayerMove playMaquiavel;
    void Start(){
        playMaquiavel = GetComponent<PlayerMove>();

    }

    // Update is called once per frame
    void Update()
    {
        if(playMaquiavel.HPMover <= 0){
            MaquiavelMorto = true;
        }
    }
}
