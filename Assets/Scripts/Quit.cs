using System.Diagnostics;
using UnityEngine;
class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        Process.GetCurrentProcess().Kill();
    }
}