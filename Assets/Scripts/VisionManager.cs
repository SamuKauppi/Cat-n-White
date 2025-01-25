using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionManager : MonoBehaviour
{
	[SerializeField] private BubbleManager bubbleManager;
	public Color black;
	public Color white;
	public float speed = 0.1f;

	private float t;
	private GameObject bubble;
	

	private IEnumerator ShowThings(Color currentColor, Color targetColor)
	{
		while (t < speed)
		{
			t += Time.deltaTime;
			bubbleManager.bubbles[0].GetComponent<SpriteRenderer>().color = Color.Lerp(targetColor, currentColor, t / speed);
			Camera.main.backgroundColor = Color.Lerp(currentColor, targetColor, t / speed);
			yield return null;
		}
	}

	public void SetActivated()
	{
		if(Camera.main.backgroundColor != black)
		{
			StartCoroutine(ShowThings(black, white));
		}
		else
		{
			StartCoroutine(ShowThings(white, black));
		}
	}

}
