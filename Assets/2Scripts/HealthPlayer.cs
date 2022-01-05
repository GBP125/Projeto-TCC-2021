using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField]
    public int health = 3;
	public int numOfHearts;

	private GameObject deathEffect;
	private Animator animator;
	private PlayerMove playerM;
	
	public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

	void Start()
	{
		//Atribuição de componentes
		animator = gameObject.GetComponent<Animator>();
		playerM = gameObject.GetComponent<PlayerMove>();
	}

	 void Update()
    {
        if(health > numOfHearts){
          health = numOfHearts;
        }
        
        for (int i = 0; i< hearts.Length; i++)
        {
            if(i < health){
                hearts[i].sprite = fullHeart;
            } else{
                hearts[i].sprite = emptyHeart;
            }

            if(i<numOfHearts){
                hearts[i].enabled = true;
            } else{
                hearts[i].enabled = false;
            }
        }
    }

	//O Jogador recebe dano após o contato com a 'bullet' | Havendo o decréscimo dos pontos de vida e, se for o caso, a morte do inimigo e a destruição de seu sprite
	public void TakeDamage (int damage)
	{
		health -= damage;
        //animator.SetTrigger("damage");

		if (health <= 0)
		{
			Die();
		}
	}

	//Play da animação de morte do Jogador e destruição do sprite do mesmo objeto.
	void Die ()
	{
		playerM.isAlive = false;
		animator.SetBool("isDead", true);
		Destroy(gameObject,1.75f);
	}

}
