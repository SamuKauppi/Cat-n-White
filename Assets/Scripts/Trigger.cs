using UnityEngine;

public class Trigger : MonoBehaviour
{
	[SerializeField] private Type trigger;
	[SerializeField] private bool destroy;
	[SerializeField] private int layerID;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			GameManager.Instance.TriggerEvent(trigger);
			if (destroy)
			{
				SetCollision(false);
			}
		}
		
	}

	public void SetCollision(bool value)
	{
        gameObject.GetComponent<BoxCollider2D>().enabled = value;
        gameObject.GetComponent<SpriteRenderer>().enabled = value;
    }


}