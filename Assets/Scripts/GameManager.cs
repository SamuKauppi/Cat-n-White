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
	[SerializeField] private SoundManager soundManager;

	private void Awake()
	{
		Instance = this;
	}

	public void TriggerEvent(Type trigger)
	{
		switch (trigger)
		{
			case Type.Gravity:
				soundManager.PlaySound("Catfloat"); 
				gravityPoint.SwapGravity();
				break;

			case Type.Kill:
				soundManager.PlaySound("Death"); 
				player.KillPlayer();
				break;

			case Type.BubblePop:
				soundManager.PlaySound("Plop");
				bubbleManager.PopBubble();
				player.SetRespawn();
				break;

			case Type.Vision:
				soundManager.PlaySound("Vision");
				visionManager.SetActivated();
				break;
		}
	}
}
