using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSwitcher : MonoBehaviour
{
    public AudioSource happySongPlayer;
    public AudioSource demonSongPlayer;

    public AudioClip Demon;
    public AudioClip Happy;

    [Range(0, 1)]
    public float DemonVolume = 0.5f;
    [Range(0, 1)]
    public float HappyVolume = 0.5f;

    public GameObject ClosestStruc;
    public float distance;
    public bool DemonMusic = false;
	// Use this for initialization
	void Start ()
    {
        demonSongPlayer = gameObject.AddComponent<AudioSource>();
        happySongPlayer = gameObject.AddComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(DemonMusic)
        {

            demonSongPlayer.clip = Demon;
            demonSongPlayer.volume = DemonVolume;
            demonSongPlayer.loop = true;
            if(!demonSongPlayer.isPlaying)
            {
                demonSongPlayer.Play();
                happySongPlayer.Pause();
            }

            
        }
        else
        {
            happySongPlayer.clip = Happy;
            happySongPlayer.volume = HappyVolume;
            happySongPlayer.loop = true;
            if (!happySongPlayer.isPlaying)
            {
                happySongPlayer.Play();
                demonSongPlayer.Pause();
            }
        }
    
	}

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponent<House>())
        {
            if(Vector3.Distance(gameObject.transform.position, collision.gameObject.transform.position) < distance)
            {
                distance = Vector3.Distance(gameObject.transform.position, collision.gameObject.transform.position);
                ClosestStruc = collision.gameObject;
                DemonMusic = true;

            }
        }

        if (collision.gameObject.GetComponent<Altar>())
        {
            if (Vector3.Distance(gameObject.transform.position, collision.gameObject.transform.position) < distance)
            {
                distance = Vector3.Distance(gameObject.transform.position, collision.gameObject.transform.position);
                ClosestStruc = collision.gameObject;
                DemonMusic = false;

            }
        }
    }
}
