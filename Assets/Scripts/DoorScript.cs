using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

	public int doorID;
	public string doorName;
	public bool isUnlocked = false;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			//check the players inventory for the key that matches the doorID
			var playerInv = other.GetComponent<Inventory>();
			foreach (KeyPickup key in playerInv.keyChain)
			{
				if (key.keyID == doorID)
				{
					UnlockThisDoor();
					
					playerInv.RemoveKey(key);
					return;
				}
			}
		}
	}

	private void UnlockThisDoor()
	{
		Collider2D[] cols = GetComponents<Collider2D>();
		foreach (Collider2D c in cols)
		{
			c.enabled = false;
		}

		isUnlocked = true;
	}
}
