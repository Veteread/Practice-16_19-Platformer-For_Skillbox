using UnityEngine;
using System.Collections.Generic;

public class TransformsCrow : MonoBehaviour
{
    public Transform[] transforms;
    private List<int> usedIndices = new List<int>();

    public Transform TCrow()
    {
        if (transforms != null)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, transforms.Length);
            }
            while (usedIndices.Contains(randomIndex) && usedIndices.Count < transforms.Length); // ƒобавлена проверка на количество использованных transforms
            if (usedIndices.Count >= transforms.Length)
            {

                Debug.Log("No more transforms available, cannot instantiate Crow.");
                return null; // ¬озвращаем null, если все transforms использованы
            }
            usedIndices.Add(randomIndex);
            return transforms[randomIndex];
        }
        return null; // ¬озвращаем null, если `transforms` равен `null`
    }
}
