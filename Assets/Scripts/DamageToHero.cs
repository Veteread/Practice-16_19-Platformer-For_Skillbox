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
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(ToDamage(collision));
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            StopAllCoroutines();
    }

    private IEnumerator ToDamage(Collision2D collision)
    {
        while (true)
        {
            collision.gameObject.GetComponent<HeroKnight>().HandleHurt();
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
            HPhero.text = collision.gameObject.GetComponent<Health>().currentHealth + "";
            img.fillAmount = collision.gameObject.GetComponent<Health>().currentHealth / 100;
            if (collision.gameObject.GetComponent<Health>().isAlive == false)
            {
                collision.gameObject.GetComponent<HeroKnight>().DeathHero();
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}







