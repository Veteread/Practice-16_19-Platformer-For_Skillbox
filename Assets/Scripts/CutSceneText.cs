using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CutSceneText : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] textToDisplayList;
    public CutScene CutSceneTrigger;
    public GameObject Speaker1;
    public GameObject Speaker2;
    public string textToDisplay;
    public float delayBetweenCharacters = 0.1f;

    private int nextText = 0;
    private int sumCharacter = 0;
    private bool whoSpeak;

    void Start()
    {
        whoSpeak = true;        
        textToDisplay = textToDisplayList[nextText];
        sumCharacter = textToDisplay.Length;
        StartCoroutine(AppearText());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            textDisplay.text = textToDisplayList[nextText];
            Invoke("ChangeText", 1.5f);
        }
    }

    private IEnumerator AppearText()
    {
        foreach (char character in textToDisplay.ToCharArray())
        {
            textDisplay.text += character;
            sumCharacter --;
            if (sumCharacter == 0)
        {
            Invoke("ChangeText", 2f);
        }
            yield return new WaitForSeconds(delayBetweenCharacters);
        }

    }

    private void ChangeText()
    {
        if (whoSpeak == true)
        {
            Speaker1.SetActive(false);
            Speaker2.SetActive(true);
        }
        if (whoSpeak == false)
        {
            Speaker1.SetActive(true);
            Speaker2.SetActive(false);
        }
        whoSpeak = !whoSpeak;
        delayBetweenCharacters = 0.1f;
        nextText++;
        if (nextText < textToDisplayList.Length)
        {
            textDisplay.text = " ";
            textToDisplay = textToDisplayList[nextText];
            sumCharacter = textToDisplay.Length;
            StartCoroutine(AppearText());
        }
        else
        {
            if (CutSceneTrigger!= null)
            CutSceneTrigger.CanvasDisplayOn();
        }
    }
}
