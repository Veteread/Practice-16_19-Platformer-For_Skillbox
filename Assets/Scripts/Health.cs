using UnityEngine;

public class Health : MonoBehaviour
{   
	public float MaxHealth;
	private float currentHealth;
	private bool isAlive;

    void Aweke()
    {
        currentHealth = MaxHealth;
        isAlive = true;
    }    

   public void TakeDamage (float Damage)
    {
    	currentHealth -= Damage;
    	CheckisAlive();
    }

    void CheckisAlive()
    {
    	if (currentHealth > 0)
    		isAlive = true;
    	else
    		Destroy(gameObject);
    }
}
