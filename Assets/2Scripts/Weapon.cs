using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool shot = false;
    public float shotTimeCounter;
    public float shotRemaining;
    public float shotDelayCounter;
    
    // Update is called once per frame
    void Update()
    {
        //Se houve a utilização de um tiro, o tempo de recarga começará
        if(shotRemaining < 5){
            shotTimeCounter += Time.deltaTime;
        }

        //Se houve a utilização de um tiro, o tempo de delay começará
        if(shotRemaining < 5){
            shotDelayCounter += Time.deltaTime;
        }
        
        //Após 3 segundos depois da utilização de um tiro, há o acréscimo de 1 ao número de tiros disponíveis (e zera o tempo de contagem)
        if (shotTimeCounter >= 1.5 && shotRemaining < 5)
        {
            //Incrementando um ao tiro
            incrementShot();
            //Resetando a contagem para a recarga do tiro
            shotTimeCounter = 0;
            //Resetando a contagem de delay para o tiro
            //shotDelayCounter = 0.8f;
        }
        
        //Realização do tiro com base na mudança de variável realizada em 'ShootMagic', apenas será realizado após a execução do comando, se houver tiros disponíveis e se já houve a passagem do delay do tiro.
        if(shot && shotRemaining > 0 && shotDelayCounter >= 0.8)
        {
            Shoot();
            //Diminuição do total de tiros
            if(shotRemaining > 0){
                shotRemaining -= 1;
            }
            //Reset do delay para os tiros
            shotDelayCounter = 0;
        }
    }

    //Criação do prefab 'bullet' no local de tiro, realizado após todas as checagens de variáveis e comando
    void Shoot()
    {
        //"Spawn" criar um objeto na tela - O que spawnar, onde spawnar e a rotação que queremos
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    //Incremento de um tiro após a realização do mesmo ato
    void incrementShot()
    {
        shotRemaining += 1;
    }
}
