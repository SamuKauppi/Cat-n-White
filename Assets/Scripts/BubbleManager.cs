using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    public void explote()
    {
        Destroy(this);
    }

	private void OnDestroy()
	{
		//Do effect of plopping
	}
}
