using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public void TriggerEvent(Type trigger)
	{
		switch (trigger)
		{
			case Type.Move:
				Debug.Log("Move the trap");
				break;

			case Type.Gravity:
				Debug.Log("Gravity changed");
				break;

			case Type.Kill:
				Debug.Log("Dead kitty");
				break;
			case Type.BubblePop:
				//Bubble.explote();
				Debug.Log("Plop!");
				break;
			case Type.Vision:
				//Bubble.explote();
				Debug.Log("Switch black to white");
				break;
		}
	}
}
