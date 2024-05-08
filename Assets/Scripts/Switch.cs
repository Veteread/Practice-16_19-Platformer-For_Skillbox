using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject Plat; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RemoveAttack"))
        {
            GetComponentInChildren<Animator>().enabled = true;
            Plat.SetActive(true);
        }
    }
}
