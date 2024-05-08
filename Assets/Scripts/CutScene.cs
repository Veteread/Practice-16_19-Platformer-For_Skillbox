using UnityEngine;
using Cinemachine;

public class CutScene : MonoBehaviour
{
    public GameObject CanvasDisplay;
    public GameObject Cut;
    public GameObject Crow;
    public CinemachineVirtualCamera Cam2;
    private Collider2D playerCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerCollider = other;
        other.gameObject.GetComponent<HeroKnight>().StopForCutScene();
        Invoke("CanvasDisplayOff", 2f);
        Cam2.Priority = 20;
    }

    private void CanvasDisplayOff()
    {
        Cut.SetActive(true);
        CanvasDisplay.SetActive(false);
    }

    public void CanvasDisplayOn()
    {
        Cut.SetActive(false);
        Cam2.Priority = 5;
        CanvasDisplay.SetActive(true);
        playerCollider.gameObject.GetComponent<HeroKnight>().playerControl = true;
        Crow.gameObject.GetComponentInChildren<Animator>().SetTrigger("dead");
        Destroy(Crow, 1f);
        Destroy(gameObject);
    }
}
