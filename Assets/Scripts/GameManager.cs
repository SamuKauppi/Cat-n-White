using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	[SerializeField] private BubbleManager bubbleManager;
	[SerializeField] private VisionManager visionManager;
	[SerializeField] private GravityPoint gravityPoint;
	[SerializeField] private PlayerMove player;

	private void Awake()
	{
		Instance = this;
	}

	public void TriggerEvent(Type trigger)
	{
		switch (trigger)
		{
			case Type.Gravity:
				gravityPoint.SwapGravity();
				break;

			case Type.Kill:
				player.KillPlayer();
				break;

			case Type.BubblePop:
				bubbleManager.PopBubble();
				player.SetRespawn();
				break;

			case Type.Vision:
				visionManager.SetActivated();
				break;
		}
	}
}
