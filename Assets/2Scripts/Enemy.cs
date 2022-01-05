using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 100;
	private GameObject deathEffect;
	private Animator animator;
	
	void Start()
	{
		//Atribuição de componentes
		animator = gameObject.GetComponent<Animator>();
	}

	//O inimigo recebe dano após o contato com a 'bullet' | Havendo o decréscimo dos pontos de vida e, se for o caso, a morte do inimigo e a destruição de seu sprite
	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	//Play da animação de morte do inimigo e destruição do sprite do mesmo objeto.
	void Die ()
	{
		animator.SetBool("isDead", true);
		Destroy(gameObject,0.5f);
	}

}
