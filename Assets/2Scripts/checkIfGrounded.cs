using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfGrounded : MonoBehaviour
{
    public PlayerMove moverGround;
    
    //Colidiu com as plataformas com a tag 'ground'
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ground")
        {
            moverGround.grounded = true;
            moverGround.isJumping = false;
            moverGround.speed = 5f;
            moverGround.animator.SetBool("isFalling", false);
        }
    }

    //Parou de colidir com as plataformas com a tag 'ground'
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "ground")
        {
            moverGround.grounded = false;
            moverGround.isJumping = true;
            moverGround.speed = 2f;
            moverGround.animator.SetBool("isFalling", true);
        }
    }
}