using UnityEngine;
using TMPro;
using System.Collections;

public class CutSceneText : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // ������ �� TextMeshProUGUI ��� ����������� ������
    public string textToDisplay; // ������ ������, ������� ����� ����������
    public float delayBetweenCharacters = 0.1f; // �������� ����� ���������� ��������

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
