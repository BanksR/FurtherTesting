using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

	public int keyID;
	public string keyName;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.GetComponent<Inventory>().PickUpKey(this);
			this.gameObject.SetActive(false);
		}
	}
}
