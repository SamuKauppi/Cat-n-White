using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionManager : MonoBehaviour
{
	public Color black;
	public Color white;
	public float speed = 0.1f;

	private float t;
	private GameObject bubble;

	private void Start()
	{
		Camera.main.backgroundColor = Color.black;
	}
	private IEnumerator ShowThings(Color currentColor, Color targetColor)
	{
		while (t < speed)
		{
			t += Time.deltaTime;
			SpriteRenderer[] allSprites = Object.FindObjectsOfType<SpriteRenderer>();
			foreach (SpriteRenderer sprite in allSprites)
			{
				sprite.color = currentColor;
			}
			Camera.main.backgroundColor = Color.Lerp(currentColor, targetColor, t / speed);
			yield return null;
		}
	}

	public void SetActivated()
	{
		if (Camera.main.backgroundColor == black)
		{
			t = 0;
			StartCoroutine(ShowThings(black, white));
		}
		else
		{
			t = 0; 
			StartCoroutine(ShowThings(white, black));
		}
	}

}
