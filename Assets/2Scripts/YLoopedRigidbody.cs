using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class YLoopedRigidbody : MonoBehaviour
{
    //Coordenada do Y no lado de baixo da tela onde deve-se transportar o jogador para o lado de cima
    [SerializeField]
    private float downWrapAroundBound;

    //O mesmo que o do lado de baixo - Coordenada do Y no lado de cima da tela onde deve-se transportar o jogador para o lado de baixo
    [SerializeField]
    private float upWrapAroundBound;

    private void FixedUpdate()
    {
        //Determinação da área de loop
        float loopedAreaWidth = upWrapAroundBound - downWrapAroundBound;
        //Atribuição do componente
        Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();
        //Pegar posição atual do RigidBody
        Vector2 currentPosition = rigidBody2D.position;
        // Mover o rigidbody para a tela do lado de baixo, se estiver no lado de baixo
        while (currentPosition.y < downWrapAroundBound)
        {
            //Adicionar toda a área de loop para que ele reapareça no lado de cima
            currentPosition.y += loopedAreaWidth;
        }
 
        //O mesmo que o do lado de baixo - Mover o rigidbody para a tela do lado de cima, se estiver no lado de cima
        while (currentPosition.y > upWrapAroundBound)
        {
            //Retirar toda a área de loop para que ele reapareça no lado de baixo
            currentPosition.y -= loopedAreaWidth;
        }
 
        //Atualização de posição
        rigidBody2D.position = currentPosition;
    }
}