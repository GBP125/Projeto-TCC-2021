using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    //Variáveis
    public float speed;
    public float jumpSpeed;
    public float moveInput;
	public float jumpTime;
    public float jumpTimeCounter;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    public float dashReloadCounter;
    public float dashDelayCounter;
    public int dashRemaining;
    private int direction;
    public bool grounded;
    public bool isJumping;
    public bool isDashing;
    private bool facingRight = true;
    public bool isAlive = true;
	public Rigidbody2D rgdbody;
	private SpriteRenderer sprRend;
    public Animator animator;
    public GameObject walkParticle;
    public HealthPlayer healthMover;
    public int HPMover;

    [SerializeField]
    private int playerIndex = 0;

    void Awake()
    {
        //Reset e setagem de valora para as variaveis.
        this.speed = 5;
        this.jumpSpeed = 5;
        this.jumpTime = 0.15f;
        this.dashSpeed = 15;
        this.startDashTime = 0.1f;
        this.dashReloadCounter = 3;
        this.dashDelayCounter = 1.5f;
        this.dashRemaining = 3;   
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }
    
    void Start()
    {
        //Atribuição de componentes a variáveis
        rgdbody = gameObject.GetComponent<Rigidbody2D>();
        sprRend = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        #region MOVEMENT
        //Aplicar força de aceleração quando o jogadore estiver se movimentando
        rgdbody.velocity = new Vector2(moveInput * speed, rgdbody.velocity.y);

        //Inversão do sprite dependendo da direção que o personagem está indo
        if (moveInput > 0f && !facingRight)
        {
            Flip();
        }else if (moveInput < 0f && facingRight){
            Flip();
        }

        //Animação andando e criação de partículas
        if (moveInput != 0 && grounded == true)
        {
            animator.SetBool("walking", true);
            Instantiate(walkParticle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),Quaternion.identity);
        }else{
            animator.SetBool("walking", false);
        }

        #endregion
        
        #region JUMP
        
        //Verificando se o personagem não está no chão e se está pulando, depois verificando o tempo de pulo e dizendo que o jogador está no chão
        if(grounded == false && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rgdbody.velocity = new Vector2(rgdbody.velocity.x, jumpSpeed);
                jumpTimeCounter -= Time.deltaTime;
            }else{
                isJumping = false;
            }
        }

        #endregion

        #region DASH
   
        //Se houve a utilização de uma esquiva, o tempo de recarga começará
        if(dashRemaining < 3){
            dashReloadCounter += Time.deltaTime;
        }

        //Se houve a utilização de uma esquiva, o tempo de delay começará
        if(dashRemaining < 3){
            dashDelayCounter += Time.deltaTime;
        }
        
        //Após 3 segundos depois da utilização de uma esquiva, há o acréscimo de 1 ao número de esquivas disponível (e zera o tempo de contagem)
        if (dashReloadCounter >= 3 && dashRemaining < 3)
        {
            //Incrementando um dash
            incrementDash();
            //Resetando a contagem para a recarga do dash
            dashReloadCounter = 0;
            //Resetando a contagem de delay para o dash
            dashDelayCounter = 1;
        }

        //REALIZAÇÃO DO DASH
        //Verificando se o jogador não está andando
        if(direction == 0)
        {
            //Ativação do dash
            if(isDashing == true && dashRemaining > 0)
            {
                //Direita = 1; Esquerda = -1
                // Após a realização da esquiva, há a subtração da quantidade disponível
                if(moveInput < 0)
                {
                    animator.SetTrigger("dash");
                    //camAnim.SetTrigger("zoomin");*/
                    direction = 1;
                    dashRemaining -= 1;
                    isDashing = false;
                }else if (moveInput > 0) 
                {
                    animator.SetTrigger("dash");
                    //camAnim.SetTrigger("zoomin");*/
                    direction = 2;
                    dashRemaining -= 1;
                    isDashing = false;
                }
            }
        }else
        {
            //Ele não está dando o dash, portanto a direção, duração do dash e velocidade retornam aos seus valores originais
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rgdbody.velocity = Vector2.zero;
            }else //Ele está dando o dash
            {
                //O tempo do dash irá diminir a cada frame
                dashTime -= Time.deltaTime;

                //Se o dash foi realizado em direção a direita, é aplicado a força do dash para o movimento à direita, junto com o reset da checagem do dash
                if(direction == 1)
                {
                    rgdbody.velocity = Vector2.left * dashSpeed;
                    isDashing = false;
                //Se o dash foi realizado em direção a esquerda, é aplicado a força do dash para o movimento à esquerda, junto com o reset da checagem do dash
                }else if (direction == 2)
                {
                    rgdbody.velocity = Vector2.right * dashSpeed;
                    isDashing = false;
                }
            }
        }

        #endregion

        this.HPMover = healthMover.health;
    }

    //Inverter o sprite do jogador com base na posição que ele está olhando
    public void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
    
    //Incremento de 1 ao número de esquivas disponíveis
    public void incrementDash()
    {
        dashRemaining += 1;
    }
}
