using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float Damage;
    public GameObject BoomPfb;

    void OnTriggerEnter2D(Collider2D collision)
    {
    	if (collision.CompareTag("damageble"))
    	{
    		collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
    		
            if (collision.usedByEffector)
            {
                GameObject boom = Instantiate(BoomPfb, transform.position, Quaternion.identity);
                Destroy(boom, 0.2f);
            }
            Destroy(gameObject);
        }  
    }
}
