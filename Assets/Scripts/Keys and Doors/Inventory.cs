using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{

	public List<KeyPickup> keyChain = new List<KeyPickup>();

	public void PickUpKey(KeyPickup pickedUpKey)
	{
		Debug.Log("You picked up the "+ pickedUpKey.keyName+ " key.");
		keyChain.Add(pickedUpKey);
	}

	public void RemoveKey(KeyPickup keyToRemove)
	{
		Debug.Log("You use the "+ keyToRemove.keyName + " key.");
		keyChain.Remove(keyToRemove);
	}


}
