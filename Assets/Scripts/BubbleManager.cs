using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
	public List<BubblePopper> bubbles;

    public void PopBubble()
    {
		if(bubbles.Count > 0) {

			bubbles[0].Pop();
			bubbles.RemoveAt(0);
		}
	}
}
