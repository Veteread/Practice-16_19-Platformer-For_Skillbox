using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
	public GameObject Skeleton;
	public Transform Hero;
	public bool LookHero = false;

	private void Start()
    {
    	StartCoroutine(InstantiateSkeleton());
    } 

    private void Update()
    {
    	if ((transform.position.x  > Hero.position.x && !LookHero) || (transform.position.x  < Hero.position.x && LookHero))
        {
            transform.localScale *= new Vector2(-1, 1);
            LookHero = !LookHero;
        }
    }

    private IEnumerator InstantiateSkeleton()
    {
        while (true)
        {        	
            GameObject newSkeleton = Instantiate(Skeleton, transform.position  + new Vector3(1.5f,0f,0f), Quaternion.identity);
            GameObject newSkeleton2 = Instantiate(Skeleton, transform.position  + new Vector3(-1.5f,0f,0f), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}
