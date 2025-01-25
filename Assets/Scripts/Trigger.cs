using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
	[SerializeField] private Type trigger;
	[SerializeField] private bool destroy;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			GameManager.Instance.TriggerEvent(trigger);
			if (destroy)
			{
				gameObject.GetComponent<BoxCollider2D>().enabled = false;
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
			}
		}
		
	}
}