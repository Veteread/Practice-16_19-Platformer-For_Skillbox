using UnityEngine;
using TMPro;
using System.Collections;

public class CutSceneText : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // Ссылка на TextMeshProUGUI для отображения текста
    public string textToDisplay; // Строка текста, которую нужно отобразить
    public float delayBetweenCharacters = 0.1f; // Задержка между появлением символов

    void Start()
    {
        StartCoroutine(AppearText());
    }

    private IEnumerator AppearText()
    {
        foreach (char character in textToDisplay.ToCharArray())
        {
            textDisplay.text += character;
            yield return new WaitForSeconds(delayBetweenCharacters);
        }
    }
}
