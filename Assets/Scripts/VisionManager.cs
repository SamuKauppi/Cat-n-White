using System.Collections;
using UnityEngine;

public class VisionManager : MonoBehaviour
{
    public Color black;
    public Color white;
    public float speed = 0.1f;

    private float t;

    private void Start()
    {
        Camera.main.backgroundColor = Color.black;
    }
    private IEnumerator ShowThings(Color currentColor, Color targetColor)
    {
        SpriteRenderer[] allSprites = Object.FindObjectsOfType<SpriteRenderer>();
        while (t < speed)
        {
            t += Time.deltaTime;

            foreach (SpriteRenderer sprite in allSprites)
            {
                Color c = sprite.color;
                c.r = Mathf.Lerp(targetColor.r, currentColor.r, t / speed);
                c.g = Mathf.Lerp(targetColor.g, currentColor.g, t / speed);
                c.b = Mathf.Lerp(targetColor.b, currentColor.b, t / speed);
                sprite.color = c;
            }
            Camera.main.backgroundColor = Color.Lerp(currentColor, targetColor, t / speed);

            yield return null;
        }
    }

    public void SetActivated()
    {
        t = 0;

        if (Camera.main.backgroundColor == black)
        {
            StartCoroutine(ShowThings(black, white));
        }
        else
        {
            StartCoroutine(ShowThings(white, black));
        }
    }

}
