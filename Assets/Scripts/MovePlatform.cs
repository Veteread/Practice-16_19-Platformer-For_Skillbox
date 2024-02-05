using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
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
    		Debug.Log("move on the platform");
    		other.transform.parent = transform;
            PlayerTransform.position = this.transform.position;
        }
    	if (other.GetComponent<Collider2D>().tag == "Check")
    	{
    		if (sj.angle < 90) 
    		{   		
    			sj.angle = 180;
    		}	
    		else 
    		{   		
    			sj.angle = 0;
    		}
    	}

    	
    }
    void OnTriggerExit2D(Collider2D other)
    {
    	//other.transform.parent = null;
    }
}
