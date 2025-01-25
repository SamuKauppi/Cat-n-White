using UnityEngine;

public class BubblePopper : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void Pop()
    {
        anim.SetBool("Pop", true);
    }

    public void DestroyBubble()
    {
        Destroy(gameObject);
    }
}
