using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageToHero : MonoBehaviour
{
    public Text HPhero;
    public Image img;
    public float Damage;

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
            StopCoroutine(ToDamage(collision));
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
            if (collision.gameObject.GetComponent<HeroKnight>())
            {
                collision.gameObject.GetComponent<HeroKnight>().HandleHurt();
            }
            if (collision.gameObject.GetComponent<Health>())
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
                HPhero.text = collision.gameObject.GetComponent<Health>().currentHealth + "";
                img.fillAmount = collision.gameObject.GetComponent<Health>().currentHealth / 100;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}







