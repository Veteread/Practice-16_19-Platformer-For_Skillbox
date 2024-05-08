using UnityEngine;

public class ResetVarsMain : MonoBehaviour
{
    public void ResetVars()
    {
        PlayerPrefs.SetInt("scor", 0);
        PlayerPrefs.SetInt("LvlScore", 0);
        PlayerPrefs.SetInt("HighScor", 0);
        BossStatic.StartBossOn = false;
    }
   
}
