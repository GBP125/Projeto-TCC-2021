using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 1;
	public Rigidbody2D rb;
	public GameObject impactEffect;
    public PlayerMove mover;


	// Use this for initialization
	void Start () {
		//Acréscimo de velocidade ao objeto gerado ao ser realizado o tiro
		rb.velocity = transform.right * speed;
	}

	//Colisão com algum objeto
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		HealthPlayer Hplayer = hitInfo.GetComponent<HealthPlayer>();
		//Colisão com o inimigo | Criação do efeito de impacto e 'calling' do método para decréscimo de vida do inimigo
		if (hitInfo.tag == "player"/*Hplayer != null*/)
		{
			Debug.Log("Acertou");
			Hplayer.TakeDamage(damage);
			Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		//Colisão com o chão | Criação do efeito de impacto
		}else if (hitInfo.tag == "ground")
		{
			Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		//Colisão com outras plataformas | Criação do efeito de impacto
		}else if (hitInfo.tag == "otherPlat")
		{
			Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
