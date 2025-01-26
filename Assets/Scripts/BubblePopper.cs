using UnityEngine;

public class BubblePopper : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer rend;

    private SpriteRenderer[] children;

    private void Start()
    {
        anim.enabled = false;
        children = new SpriteRenderer[transform.childCount];
        for (int i = 0; i < children.Length; i++)
        {
            if (transform.GetChild(i).TryGetComponent<SpriteRenderer>(out var sr))
            {
                children[i] = sr;
            }
        }
    }

    public void Pop()
    {
        anim.enabled = true;
        anim.SetBool("Pop", true);
    }

    public void DestroyBubble()
    {
        Destroy(gameObject);
    }

    public void HideChildren()
    {
        for (int i = 0; i < transform.childCount; i++) 
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void SetAlpha(float alpha)
    {
        Color c = rend.color;
        c.a = alpha;
        rend.color = c;

        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] != null)
                children[i].color = c;
        }
    }
}
