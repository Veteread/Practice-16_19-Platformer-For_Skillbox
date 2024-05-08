using UnityEngine.UI;
using UnityEngine;

public class Record : MonoBehaviour
{
	public Text NewRecord;
	public Text NameRecordText;
	public Text NewScore;
	public Text NameScoreText;
	public InputField NameRecord;
    public Vars vars;
    public int _Record;
    public string Name = "Proger";

    void Awake()
    {
    	NewRecord.text = PlayerPrefs.GetInt("Record")+"";
    	NameRecordText.text = PlayerPrefs.GetString("_NameRecord")+"";
    }

    public void WriteRecord()
    {
    	NewScore.text = vars._SumScore.ToString();
    	NameScoreText.text = NameRecord.text.ToString();
    	if (vars._SumScore > PlayerPrefs.GetInt("Record"))
    	{
    		_Record = vars._SumScore;
    		Name = NameRecord.text.ToString();
    		PlayerPrefs.SetInt("Record", _Record);
    		PlayerPrefs.SetString("_NameRecord", Name);
    		NewRecord.text = PlayerPrefs.GetInt("Record")+"";
    		NameRecordText.text = PlayerPrefs.GetString("_NameRecord")+"";
    	}    	
    }
    public void Reset()
    {
    	PlayerPrefs.SetInt("Record", 0);
    }
}
