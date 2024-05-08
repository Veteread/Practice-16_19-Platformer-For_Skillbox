using UnityEngine.UI;
using UnityEngine;

public class RecordMain : MonoBehaviour
{
	public Text NewRecord;
	public Text NameRecordText;
	
    void Awake()
    {
    	NewRecord.text = PlayerPrefs.GetInt("Record")+"";
    	NameRecordText.text = PlayerPrefs.GetString("_NameRecord")+"";
    }
}
