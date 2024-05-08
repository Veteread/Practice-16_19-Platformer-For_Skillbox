using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortCrow : MonoBehaviour
{
    public GameObject Crow;
    public GameObject Finish;
    public TransformsCrow transformCrow;
    public Crow crowLook;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RemoveAttack"))
        {
            if (transformCrow.dead == true)
            {
                Finish.SetActive(true);
            }
            else
            {
                Invoke("InstCrow", 0.8f);
            }            
        }
    }
    private void InstCrow()
    {
    GameObject currentCrow = Instantiate(Crow, transformCrow.TCrow().position, Quaternion.identity);
    currentCrow.GetComponent<CapsuleCollider2D>().enabled = true;
    if (crowLook.LookHero == true)
        {
            transform.localScale *= new Vector2(-1, 1);
        }
    }
}
