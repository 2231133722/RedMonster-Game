using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Patrol : MonoBehaviour
{
	public Animator anim;
	public float speed;
	public bool MoveRight;

	// Use this for initialization
	void Update()
	{
		// Use this for initialization
		if (MoveRight)
		{
			transform.Translate(2 * Time.deltaTime * speed, 0, 0);
			transform.localScale = new Vector2(-1, 1);
		}
		else
		{
			transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
			transform.localScale = new Vector2(1, 1);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Turn"))
		{

			if (MoveRight)
			{
				MoveRight = false;
			}
			else
			{
				MoveRight = true;
			}
		}
	}
    private void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.CompareTag("Player"))
		{
			Vector2 direction = other.GetContact(0).normal;
			if (direction.y == -1)
			{
				anim.SetTrigger("Kill");
				Destroy(this.gameObject, 0.5f);
				
			}
			else {
				SceneManager.LoadScene(2);
			}
		}
	}
	public void killObject()
    {
		Destroy(this.gameObject);
	}
}