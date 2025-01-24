using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
	public enum PowerUpType {Gravity, Move, Kill, Explote}

	[Header("Power Up Settings")]
	public PowerUpType trapType;
	
	// Start is called before the first frame update
	void Start()
    {
		PowerUpEventController.OnPowerUpriggered += getPowerUp;
	}

	private void getPowerUp(PowerUps trap)
	{
		if (trap == this) 
		{
			setPowerUp(); 
		}
	}
	private void setPowerUp()
	{
		switch (trapType)
		{
			case PowerUpType.Move:
				Debug.Log("Move the trap");
				break;

			case PowerUpType.Gravity:
				Debug.Log("Gravity changed");
				break;

			case PowerUpType.Kill:
				Debug.Log("Dead kitty");
				break;
			case PowerUpType.Explote:
				Debug.Log("Plop!");
				break;
		}
	}

}
