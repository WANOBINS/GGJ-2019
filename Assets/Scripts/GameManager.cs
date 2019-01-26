using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        DontDestroyOnLoad(transform);
        //Time.timeScale = 0;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}