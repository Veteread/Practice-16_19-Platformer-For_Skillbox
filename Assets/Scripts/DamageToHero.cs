using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageToHero : MonoBehaviour
{
    public float Damage;
    private Collision2D hero;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.gameObject.GetComponent<HeroKnight>().Block)
        {
            StartCoroutine(ToDamage(collision));
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator ToDamage(Collision2D collision)
    {
        while (true)
        {
            if (collision.gameObject.GetComponent<Health>() != null && collision.gameObject.GetComponent<Health>().isAlive == false)
            {
                collision.gameObject.GetComponent<HeroKnight>().DeathHero();
            }
            else
            {
                if (collision.gameObject.GetComponent<HeroKnight>() != null)
                {
                collision.gameObject.GetComponent<HeroKnight>().DamageToHeroTreatment(Damage);                
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}







