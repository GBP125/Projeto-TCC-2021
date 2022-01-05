using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TelaFinal : MonoBehaviour
{    
    public Maquiavel maq;
    public Nyzette nyz;
    public MonAmour mon;
    public Marai mar;


    public GameObject menuFinal;

    public bool MaquiavelVencedor = false;
    public bool NyzetteVencedor = false;
    public bool MonAmourVencedor = false;
    public bool MaraiVencedor = false;
    
    void Start(){
        maq = GetComponent<Maquiavel>();
        nyz = GetComponent<Nyzette>();
        mon = GetComponent<MonAmour>();
        mar = GetComponent<Marai>();
    }
    
    void Update(){
        if(maq.MaquiavelMorto == true && nyz.NyzetteMorto == true && mar.MaraiMorto == true && mon.MonAmourMorto == false){
            MonAmourVencedor = true;
            menuFinal.SetActive(true);
            //set active (idle)
            Debug.Log("MonAmourVencedor");
        }
        else if(maq.MaquiavelMorto == true && nyz.NyzetteMorto == true && mar.MaraiMorto == false && mon.MonAmourMorto == true){
            MaraiVencedor = true;
            menuFinal.SetActive(true);
            Debug.Log(MaraiVencedor);
        }
        else if(maq.MaquiavelMorto == true && nyz.NyzetteMorto == false && mar.MaraiMorto == true && mon.MonAmourMorto == true){
            NyzetteVencedor = true;
            menuFinal.SetActive(true);
            Debug.Log("NyzetteVencedor");
        }
        else if(maq.MaquiavelMorto == false && nyz.NyzetteMorto == true && mar.MaraiMorto == true && mon.MonAmourMorto == true){
            MaquiavelVencedor = true;
            menuFinal.SetActive(true);
            Debug.Log(MaquiavelVencedor);
        }
    }
}