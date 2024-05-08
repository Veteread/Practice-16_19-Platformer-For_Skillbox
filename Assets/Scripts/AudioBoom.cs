using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBoom : MonoBehaviour
{

    public GameObject BoomPrefab;
    private AudioSource audioBoom;

	private void Start()
    {
        audioBoom = GetComponent<AudioSource>();
    }
    public void SoundBoom()
    {
    	audioBoom.Play();
    	Invoke("Boom", 2f);
    }

    private void Boom()
    {
    	Destroy(gameObject);
        GameObject boom = Instantiate(BoomPrefab, transform.position, Quaternion.identity);
        Destroy(boom, 1f);
    }
}
