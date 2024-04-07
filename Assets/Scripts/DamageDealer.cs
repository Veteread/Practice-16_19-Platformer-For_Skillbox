using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float Damage;
    public GameObject BoomPrefab;
    public Animator anim;

    private int enemy = 1;
    private GameObject varE;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
            Animator anim = collision.gameObject.GetComponentInChildren<Animator>();
            if (collision.gameObject.GetComponent<Health>().isAlive == false)
            {
                anim.SetTrigger("dead");              
                varE = GameObject.Find("HeroKnight");
                varE.gameObject.GetComponent<Vars>().SumEnemy(enemy);
                collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                Destroy(collision.gameObject, 1f);
            }
            else
            {
            anim.SetTrigger("hurt");
        	}            
            Destroy(gameObject);
        }
        if (collision.CompareTag("damageble"))
        {
            GameObject boom = Instantiate(BoomPrefab, transform.position, Quaternion.identity);
            Destroy(boom, 0.2f);
        }
    }
}
