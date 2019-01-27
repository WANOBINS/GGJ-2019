using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSwitcher : MonoBehaviour
{
    public AudioSource songPlayer;

    public AudioClip Demon;
    public AudioClip Happy;

    [Range(0, 1)]
    public float DemonVolume = 0.5;
    [Range(0, 1)]
    public float HappyVolume = 0.5;

    public GameObject ClosestStruc;
    public float distance;
    public bool DemonMusic = false;
	// Use this for initialization
	void Start ()
    {
        songPlayer = gameObject.AddComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(DemonMusic)
        {

            songPlayer.clip = Demon;
            songPlayer.volume = DemonVolume;
            if(songPlayer.isPlaying)
            {
                songPlayer.Play();
            }
            
        }
	}

    void OnTriggerEnter(collider collision)
    {
        if(collision.gameObject.tag == "Altar")
        {
            if(Vector3.Distance(gameObject.transform, collision.gameObject.transform) < distance)
            {
                distance = Vector3.Distance(gameObject.transform, collision.gameObject.transform);
                ClosestStruc = collision.gameObject;
                DemonMusic = true;

            }
        }

        if (collision.gameObject.tag == "House")
        {
            if (Vector3.Distance(gameObject.transform, collision.gameObject.transform) < distance)
            {
                distance = Vector3.Distance(gameObject.transform, collision.gameObject.transform);
                ClosestStruc = collision.gameObject;
                DemonMusic = false;

            }
        }
    }
}
