using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    public Crow crow;
    public Vars vars;
    public GameObject CloseWayToBoss;
    public GameObject Lift;

    void OnTriggerEnter2D(Collider2D collision)
    {
        crow.GetComponent<Crow>().enabled = true;
        vars.SaveScoreFormlastLvl();
        vars._SumScore -= vars._SumScore; //Чтоб небыло двойного начисления очков, которое идет с vars.SaveScoreFormlastLvl()
        BossStatic.StartBossOn = true;
        CloseWayToBoss.SetActive(true);
        Lift.SetActive(false);
        Destroy(gameObject);
    }
}
