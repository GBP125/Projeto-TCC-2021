using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    public PlayerInput playerInput;
    private PlayerMove mover;
    private Weapon weap;

    private void Start()
    {
        weap = GetComponent<Weapon>();
        playerInput = GetComponent<PlayerInput>();
        var movers = FindObjectsOfType<PlayerMove>();
        var index = playerInput.playerIndex;
        mover = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);
        weap.firePoint = mover.GetComponent<Weapon>().firePoint;
    }
    
    //Checagem de Input de movimentação
    public void Move(InputAction.CallbackContext context)
    {
        if(mover != null && mover.isAlive){
            mover.moveInput = context.ReadValue<Vector2>().x;
        }
    }

    //Checagem de Input de pulo e realização do mesmo ato
    public void Jump(InputAction.CallbackContext context)
    {
        //Realização do pulo e criação de partículas
        if(mover != null && context.performed && mover.grounded == true && mover.isAlive)
        {            
            for(int i = 0;i <= 50;i++)
            {
                Instantiate(mover.walkParticle,new Vector2(mover.transform.position.x, mover.transform.position.y - 0.5f),Quaternion.identity);
            }

            mover.rgdbody.velocity = new Vector2(mover.rgdbody.velocity.x, mover.jumpSpeed);
            /*mover.jumpTimeCounter = mover.jumpTime;
            mover.grounded = false;
            mover.isJumping = true;*/
        }
    }

    //Checagem de Input de dash, quantidade de dash's restantes e se o delay já foi realizado. Mudança do valor da variável de checagem de dash e reset do delay
    public void Dash (InputAction.CallbackContext context)
    {
        if(mover != null && context.performed && mover.dashRemaining > 0 && mover.moveInput !=0 && mover.dashDelayCounter >= 0.5 && mover.isAlive)
        {
            mover.isDashing = true;
            mover.dashDelayCounter = 0;
        }
    }

    //Realização primária do tiro com base no comando realizado pelo jogador
    public void ShootMagic(InputAction.CallbackContext context)
    {        
        if(mover != null && context.performed)
        {
            weap.shot = true;
        }else if(mover != null)
        {
            weap.shot = false;
        }
    }
}
