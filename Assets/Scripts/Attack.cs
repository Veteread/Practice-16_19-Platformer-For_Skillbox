using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject AttackPfb;
    public float FireSpeed;
    public Transform FirePointR;
    public Transform FirePointL;

    public void AttackHero(bool direction)
    {
        if (direction == true) 
        {
        	GameObject currentAttack = Instantiate(AttackPfb, FirePointR.position, Quaternion.identity);
        	Rigidbody2D currentAttackVelocity = currentAttack.GetComponent<Rigidbody2D>();
        	currentAttackVelocity.velocity = new Vector2 (FireSpeed * 1, currentAttackVelocity.velocity.y);
        }
        else
        {
        	GameObject currentAttack = Instantiate(AttackPfb, FirePointL.position, Quaternion.identity);
        	Rigidbody2D currentAttackVelocity = currentAttack.GetComponent<Rigidbody2D>();
        	currentAttackVelocity.velocity = new Vector2 (FireSpeed * -1, currentAttackVelocity.velocity.y);
        }        
    }
}
