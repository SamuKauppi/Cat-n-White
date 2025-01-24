using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void explote()
    {
        Destroy(this);
    }

	private void OnDestroy()
	{
		//Do effect of plopping
	}
}
