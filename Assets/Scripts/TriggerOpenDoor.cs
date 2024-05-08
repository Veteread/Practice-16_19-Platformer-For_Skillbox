using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpenDoor : MonoBehaviour
{
	public GameObject Door;
	public GameObject FinishOn;
	
    private void OnTriggerEnter2D(Collider2D other)
    {
        Door.SetActive(false);
        FinishOn.SetActive(true);
    }
}
