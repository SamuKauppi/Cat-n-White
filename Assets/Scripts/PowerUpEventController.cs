using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEventController : MonoBehaviour
{
	public static event Action<PowerUps> OnPowerUpriggered;
	public static void TriggerPowerUp(PowerUps powerUp)
	{
		if (OnPowerUpriggered != null)
		{
			OnPowerUpriggered?.Invoke(powerUp); // Envía la señal
		}
	}
}
