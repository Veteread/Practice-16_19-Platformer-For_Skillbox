using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMovePlatform : MonoBehaviour
{
	public Transform PlayerTransform;
	private SliderJoint2D sj;
	void Start()
    {
        sj = GetComponent<SliderJoint2D>();
        PlayerTransform = GetComponent<Transform>();       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
    	if (other.GetComponent<Collider2D>().tag == "Player")
    	{
            sj.enabled = true;
        }
    	if (other.GetComponent<Collider2D>().tag == "Check")
    	{
    		if (sj.angle < 45) 
    		{   		
    			sj.angle = 90;
    		}	
    		else 
    		{   		
    			sj.angle = -90;
    		}
    	}
    }
}
