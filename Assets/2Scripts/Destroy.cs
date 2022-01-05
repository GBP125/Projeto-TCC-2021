using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Update()
    {
        //Linkar aos sprites que devem ser detruídos após um determinado tempo. CHECAR TODOS OS PREFABS E SPRITES ANTES DE ALTERAR O VALOR!
        Destroy(gameObject,0.5f);
    }
}