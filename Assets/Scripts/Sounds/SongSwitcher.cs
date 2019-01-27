using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WBase.Unity.Extensions;

public class SongSwitcher : MonoBehaviour
{
    public GameManager GameManager;

    public AudioSource happySongPlayer;
    public AudioSource demonSongPlayer;

    public AudioClip Demon;
    public AudioClip Happy;

    [Range(0, 1)]
    public float DemonVolume = 0.5f;
    [Range(0, 1)]
    public float HappyVolume = 0.5f;

    public GameObject ClosestStruc;
    public float max_distance = 5000f;
    public float distance = 0;
    public bool DemonMusic = false;
	// Use this for initialization
	void Start ()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        demonSongPlayer = gameObject.AddComponent<AudioSource>();
        happySongPlayer = gameObject.AddComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        List<GameObject> gameObjects = new List<GameObject>();
        gameObjects.AddRange(GameManager.Houses);
        gameObjects.AddRange(GameManager.Portals);
        ClosestStruc = gameObjects.GetClosestTo(transform.position);

        if (ClosestStruc.GetComponent<House>() != null)
        {
            if (Vector3.Distance(gameObject.transform.position, ClosestStruc.transform.position) < max_distance)
            {
                distance = Vector3.Distance(gameObject.transform.position, ClosestStruc.gameObject.transform.position);
                DemonMusic = false;

            }
        }

        if (ClosestStruc.GetComponent<Altar>() != null)
        {
            if (Vector3.Distance(gameObject.transform.position, ClosestStruc.transform.position) < max_distance)
            {
                distance = Vector3.Distance(gameObject.transform.position, ClosestStruc.gameObject.transform.position);
                DemonMusic = true;

            }
        }

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

    void OnTriggerStay(Collider collision)
    {

    }
}
