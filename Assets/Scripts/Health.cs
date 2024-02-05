using UnityEngine;

public class Health : MonoBehaviour
{   
	public float MaxHealth;
	public float currentHealth;
	public bool isAlive;

    void Awake()
    {
        currentHealth = MaxHealth;
        isAlive = true;
    }    

   public void TakeDamage (float Damage)
    {
    	currentHealth -= Damage;
    	CheckisAlive();
    }

    private void CheckisAlive()
    {
    	if (currentHealth > 0)
    		isAlive = true;
    	else
    	{
    		isAlive = false;
    	}
    }
}
