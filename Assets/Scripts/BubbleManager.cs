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

        ChangeBubbleAplhas();
    }

    private void ChangeBubbleAplhas()
    {
        float alpha = 1.0f;
        for (int i = 0; i < bubbles.Count; i++)
        {
            bubbles[i].SetAlpha(alpha);
            alpha *= 0.25f;
        }
    }

    public void PopBubble()
    {
        if (bubbles.Count > 0)
        {
            bubbles[0].Pop();
            bubbles.RemoveAt(0);
            ChangeBubbleAplhas();

            // Load win screen
            if (bubbles.Count <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

}
