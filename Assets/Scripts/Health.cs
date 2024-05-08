using UnityEngine;
using UnityEngine.Timeline;

public class Health : MonoBehaviour
{   
	public float MaxHealth;
	public float currentHealth;
	public bool isAlive;

    private AudioSource audioKick;

    void Awake()
    {
        currentHealth = MaxHealth;
        isAlive = true;
        audioKick = GetComponent<AudioSource>();
    }    

   public void TakeDamage (float Damage)
    {
    	currentHealth -= Damage;
        audioKick.Play();
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
