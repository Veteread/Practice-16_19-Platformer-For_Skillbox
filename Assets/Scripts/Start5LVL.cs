using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start5LVL : MonoBehaviour
{
	public Transform CheckPoint;
	public Crow crow;
	public GameObject Boss;
	public GameObject CloseWayToBoss;

    void Awake()
    {
        if (BossStatic.StartBossOn == true)
        {
        	transform.position = CheckPoint.position;
        	CloseWayToBoss.SetActive(true);
        	crow.GetComponent<Crow>().enabled = true;
        	Destroy(Boss);
        }
    }
}
