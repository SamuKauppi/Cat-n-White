using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
	public List<GameObject> bubbles;

    public void PopBubble()
    {
		if(bubbles != null) {
			GameObject bubble = bubbles[0];
			Destroy(bubble);
			bubbles.RemoveAt(0);
		}
	}
}
