using UnityEngine;
using System.Collections;

public class UserPlayer : Player
{
    public float moveSpeed = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.players[GameManager.instance.currentPlayerIndex] == this)
        {
            transform.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            transform.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public override void TurnUpdate()
    {
        if (Vector3.Distance(moveDestination, transform.position) > 0.1f)
        {
            transform.position += (moveDestination - transform.position).normalized * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(moveDestination, transform.position) <= 0.1f)
            {
                transform.position = moveDestination;
                //Debug.Log(moveDestination);
                
            }
        }
        base.TurnUpdate();
    }

    public override void TurnOnGUI()
    {
        float buttonHeight = 50;
        float buttonWidth = 100;
        
        //move button
        Rect buttonRect = new Rect(0, Screen.height - buttonHeight * 2, buttonWidth, buttonHeight);
        if (GUI.Button(buttonRect, "Move"))
        {

        }
        //end turn button
        Rect buttonRect2 = new Rect(0, Screen.height - buttonHeight * 1, buttonWidth, buttonHeight);
        if (GUI.Button(buttonRect2, "End Turn"))
        {
            GameManager.instance.nextTurn();
        }

        base.TurnOnGUI();
    }
}