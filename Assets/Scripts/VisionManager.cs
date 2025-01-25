using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionManager : MonoBehaviour
{
	[SerializeField] private BubbleManager bubbleManager;
	[SerializeField] private PlayerMove player;
	[SerializeField] private Sprite Hblack;
	[SerializeField] private Sprite Hwhite;
	public Color black;
	public Color white;
	public float speed = 0.1f;

	private float t;
	private GameObject bubble;

	private void Start()
	{
	}
	private IEnumerator ShowThings(Color currentColor, Color targetColor)
	{
		while (t < speed)
		{
			t += Time.deltaTime;
			player.GetComponent<SpriteRenderer>().color = black;
			//bubbleManager.bubbles[0].GetComponent<SpriteRenderer>().color = Color.Lerp(targetColor, currentColor, t / speed);
			Camera.main.backgroundColor = Color.Lerp(currentColor, targetColor, t / speed);
			yield return null;
		}
	}

	public void SetActivated()
	{
		if (Camera.main.backgroundColor == black)
		{
			player.GetComponent<SpriteRenderer>().sprite = Hwhite;
			t = 0;
			StartCoroutine(ShowThings(black, white));
		}
		else
		{
			player.GetComponent<SpriteRenderer>().sprite = Hblack;
			t = 0;
			StartCoroutine(ShowThings(white, black));
		}
	}


}
