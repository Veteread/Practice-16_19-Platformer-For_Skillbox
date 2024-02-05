using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float Damage;
    public GameObject BoomPrefab;

    private Animator anim;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("damageble"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
            if (collision.gameObject.GetComponent<Health>().isAlive == false)
            {
                Animator anim = collision.gameObject.GetComponent<Animator>();
                anim.SetTrigger("dead");
                Destroy(collision.gameObject, 1f);
            }

            if (collision.usedByEffector)
            {
                GameObject boom = Instantiate(BoomPrefab, transform.position, Quaternion.identity);
                Destroy(boom, 0.2f);
            }
            Destroy(gameObject);
        }
    }
}
