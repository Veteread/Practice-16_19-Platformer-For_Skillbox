using UnityEngine;

public static class BossStatic
{
    private static bool startBossOn = false;
    public static bool StartBossOn
    {
    	get
    	{
    		return startBossOn;
    	}
    	set
    	{
    		startBossOn = value;
    	}
    }
}
