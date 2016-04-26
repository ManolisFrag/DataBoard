using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Vector2 gridPosition = Vector2.zero;

    public Vector3 moveDestination;
	// Use this for initialization

        void Awake()
    {
        moveDestination = transform.position;
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    
    public virtual void TurnUpdate ()
    {  
      
    }
    public virtual void TurnOnGUI()
    {

    }
}
