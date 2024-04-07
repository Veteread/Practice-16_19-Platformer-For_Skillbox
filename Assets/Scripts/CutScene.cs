using UnityEngine;
using UnityEngine.Playables;

public class CutScene : MonoBehaviour
{
    public PlayableDirector cutsceneDirector;
    public Canvas CanvasDisplay;
    private Collider2D playerCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollider = other;
            other.gameObject.GetComponent<HeroKnight>().rb.velocity = Vector2.zero;
            other.gameObject.GetComponent<HeroKnight>().animator.SetInteger("AnimState", 0);
            other.gameObject.GetComponent<HeroKnight>().playerControl = false;
            CanvasDisplayOff();
            cutsceneDirector.Play();
            Invoke("CanvasDisplayOn", 10f);
        }
    }

    private void CanvasDisplayOff()
    {
        CanvasDisplay.enabled = false;
    }
    private void CanvasDisplayOn()
    {
        Debug.Log("ON");
        CanvasDisplay.enabled = true;
        playerCollider.gameObject.GetComponent<HeroKnight>().playerControl = true;
        Destroy(this.gameObject);
    }
}
