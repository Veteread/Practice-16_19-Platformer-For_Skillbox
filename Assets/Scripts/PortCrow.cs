using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortCrow : MonoBehaviour
{
    public GameObject Crow;
    public TransformsCrow transformCrow;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RemoveAttack"))
        {
            if (transformCrow == null)
            {
                Debug.Log("cannot instantiate Crow.");
            }
            else
            {
                GameObject currentCrow = Instantiate(Crow, transformCrow.TCrow().position, Quaternion.identity);
                currentCrow.GetComponent<CapsuleCollider2D>().enabled = true;
            }            
        }
    }
}
