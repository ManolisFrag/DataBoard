using UnityEngine;
using System.Collections;

public class FirstEscape : MonoBehaviour
{

    public bool isPaused;
    public GameObject Canvas;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(transform.position);
        if (isPaused)
        {

            Canvas.SetActive(true);
            //Time.timeScale = 0f;
        }
        else
        {
            Canvas.SetActive(false);
            //Time.timeScale = 1f;
        }
    

//        if (transform.position == Vector3(3.0, 1.5, 2.0))
//        {
//            isPaused = !isPaused;
//        }
    }

    public void Resume()
    {
        isPaused = false;

    }
}
