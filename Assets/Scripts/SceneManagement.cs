using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{   
    public void Scene(int Index)
    {
        SceneManager.LoadScene(Index);
    }   
}
