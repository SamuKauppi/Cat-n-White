using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleManager : MonoBehaviour
{
	public List<BubblePopper> bubbles;

    private void Start()
    {
        for (int i = 0; i < bubbles.Count; i++)
        {
            bubbles[i].gameObject.SetActive(true);
        }
    }

    public void PopBubble()
    {
		if(bubbles.Count > 0) {

			bubbles[0].Pop();
			bubbles.RemoveAt(0);

            // Load win screen
            if(bubbles.Count <= 0)
            {
                SceneManager.LoadScene(2);
            }
		}
	}
}
