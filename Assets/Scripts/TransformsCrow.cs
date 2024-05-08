using UnityEngine;
using System.Collections.Generic;

public class TransformsCrow : MonoBehaviour
{
    public Transform[] transforms;
    private List<int> usedIndices = new List<int>();
    
    public bool dead = false;
    private int sumPorts;

    public Transform TCrow()
    {
        if (transforms != null)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, transforms.Length);
            }
            while (usedIndices.Contains(randomIndex) && usedIndices.Count < transforms.Length); 
            sumPorts++;
            if (sumPorts == 5)
            {
                dead = true; 
            }            
            usedIndices.Add(randomIndex);
            return transforms[randomIndex];
        }
        return null; 
    }
}
