using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LoopedRigidbody : MonoBehaviour
{
    //Coordenada do X no lado esquerdo da tela onde deve-se transportar o jogador para o lado direito
    [SerializeField]
    private float leftWrapAroundBound;

    //O mesmo que o da esquerda - Coordenada do X no lado direito da tela onde deve-se transportar o jogador para o lado esquerdo
    [SerializeField]
    private float rightWrapAroundBound;

    private void FixedUpdate()
    {
        //Determinação da área de loop
        float loopedAreaWidth = rightWrapAroundBound - leftWrapAroundBound;
        //Atribuição do componente
        Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();
        //Pegar posição atual do RigidBody
        Vector2 currentPosition = rigidBody2D.position;
        // Mover o rigidbody para a tela do lado esquerdo, se estiver no lado esquerdo
        while (currentPosition.x < leftWrapAroundBound)
        {
            //Adicionar toda a área de loop para que ele reapareça no lado direito
            currentPosition.x += loopedAreaWidth;
        }
 
        //O mesmo que o da esquerda - Mover o rigidbody para a tela do lado direito, se estiver no lado direito
        while (currentPosition.x > rightWrapAroundBound)
        {
            //Retirar toda a área de loop para que ele reapareça no lado esquerdo
            currentPosition.x -= loopedAreaWidth;
        }
 
        //Atualização de posição
        rigidBody2D.position = currentPosition;
    }
}