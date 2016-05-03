using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameObject TilePrefab;
    public GameObject UserPlayerPrefab;
    public GameObject mainObject;
    public GameObject mainObject2;
    public GameObject mainObject3;
    public GameObject mainObject4;
    public GameObject mainObject5;
    public GameObject mainObject6;
    public GameObject mainObject7;
    public GameObject mainObject8;
    public GameObject mainObject9;
    public GameObject mainObject10;

    public int mapSize = 10;

    List <List<Tile>> map = new List<List<Tile>>();
    public List <Player> players = new List<Player>();
    public int currentPlayerIndex = 0;

	// Use this for initialization

    void Awake()
    {
        instance = this;
    }
	void Start () {

        generateMap();
        generatePlayers();        
            mainObject.SetActive(false);
            mainObject2.SetActive(false);
            mainObject3.SetActive(false);
        mainObject4.SetActive(false);
        mainObject5.SetActive(false);
        mainObject6.SetActive(false);
        mainObject7.SetActive(false);
        mainObject8.SetActive(false);
        mainObject9.SetActive(false);
        mainObject10.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        players[currentPlayerIndex].TurnUpdate();
        //Attack();
    }

    void OnGUI()
    {
        players[currentPlayerIndex].TurnOnGUI();
    }

    public void nextTurn()
    {
        if (currentPlayerIndex + 1 < players.Count)
        {
            currentPlayerIndex++;
        } else
        {
            currentPlayerIndex = 0;
        }
       
    }

    public void moveCurrentPlayer (Tile destTile)
    {
        players[currentPlayerIndex].moveDestination = destTile.transform.position + 1.5f * Vector3.up;
        Debug.Log(destTile.gridPosition);

        if (destTile.gridPosition == new Vector2(1, 0)) //Building   THIS IS WHERE i CAN SHOW THE TEXT
        {
            //Debug.Log("DONE");
            mainObject.SetActive(true);
            mainObject2.SetActive(false);
            mainObject3.SetActive(false);
            mainObject4.SetActive(false);
            mainObject5.SetActive(false);
            mainObject6.SetActive(false);
            mainObject7.SetActive(false);
            mainObject8.SetActive(false);
            mainObject9.SetActive(false);
            mainObject10.SetActive(false);

        }
        else
        {
            if (destTile.gridPosition == new Vector2(2, 0)) //Personnel
            {
                mainObject.SetActive(false);
                mainObject2.SetActive(true);
                mainObject3.SetActive(false);
                mainObject4.SetActive(false);
                mainObject5.SetActive(false);
                mainObject6.SetActive(false);
                mainObject7.SetActive(false);
                mainObject8.SetActive(false);
                mainObject9.SetActive(false);
                mainObject10.SetActive(false);

            }
            else
            {
                if (destTile.gridPosition == new Vector2(4, 1)) //Microphones
                {
                    mainObject.SetActive(false);
                    mainObject2.SetActive(false);
                    mainObject3.SetActive(true);
                    mainObject4.SetActive(false);
                    mainObject5.SetActive(false);
                    mainObject6.SetActive(false);
                    mainObject7.SetActive(false);
                    mainObject8.SetActive(false);
                    mainObject9.SetActive(false);
                    mainObject10.SetActive(false);

                }
                else
                {
                    if (destTile.gridPosition == new Vector2(4, 2)) //Cameras
                    {
                        mainObject.SetActive(false);
                        mainObject2.SetActive(false);
                        mainObject3.SetActive(false);
                        mainObject4.SetActive(true);
                        mainObject5.SetActive(false);
                        mainObject6.SetActive(false);
                        mainObject7.SetActive(false);
                        mainObject8.SetActive(false);
                        mainObject9.SetActive(false);
                        mainObject10.SetActive(false);

                    }
                    else
                    {
                        if (destTile.gridPosition == new Vector2(4, 3)) //Cars
                        {
                            mainObject.SetActive(false);
                            mainObject2.SetActive(false);
                            mainObject3.SetActive(false);
                            mainObject4.SetActive(false);
                            mainObject5.SetActive(true);
                            mainObject6.SetActive(false);
                            mainObject7.SetActive(false);
                            mainObject8.SetActive(false);
                            mainObject9.SetActive(false);
                            mainObject10.SetActive(false);

                        }
                        else
                        {
                            if (destTile.gridPosition == new Vector2(2,4)) //Genre
                            {
                                mainObject.SetActive(false);
                                mainObject2.SetActive(false);
                                mainObject3.SetActive(false);
                                mainObject4.SetActive(false);
                                mainObject5.SetActive(false);
                                mainObject6.SetActive(true);
                                mainObject7.SetActive(false);
                                mainObject8.SetActive(false);
                                mainObject9.SetActive(false);
                                mainObject10.SetActive(false);

                            }
                            else
                            {
                                if (destTile.gridPosition == new Vector2(1, 4)) //Logo
                                {
                                    mainObject.SetActive(false);
                                    mainObject2.SetActive(false);
                                    mainObject3.SetActive(false);
                                    mainObject4.SetActive(false);
                                    mainObject5.SetActive(false);
                                    mainObject6.SetActive(false);
                                    mainObject7.SetActive(true);
                                    mainObject8.SetActive(false);
                                    mainObject9.SetActive(false);
                                    mainObject10.SetActive(false);

                                }
                                else
                                {
                                    if (destTile.gridPosition == new Vector2(0, 3)) //Satelite
                                    {
                                        mainObject.SetActive(false);
                                        mainObject2.SetActive(false);
                                        mainObject3.SetActive(false);
                                        mainObject4.SetActive(false);
                                        mainObject5.SetActive(false);
                                        mainObject6.SetActive(false);
                                        mainObject7.SetActive(false);
                                        mainObject8.SetActive(true);
                                        mainObject9.SetActive(false);
                                        mainObject10.SetActive(false);
                                    }
                                    else
                                    {
                                        if (destTile.gridPosition == new Vector2(0, 2)) //Control room
                                        {
                                            mainObject.SetActive(false);
                                            mainObject2.SetActive(false);
                                            mainObject3.SetActive(false);
                                            mainObject4.SetActive(false);
                                            mainObject5.SetActive(false);
                                            mainObject6.SetActive(false);
                                            mainObject7.SetActive(false);
                                            mainObject8.SetActive(false);
                                            mainObject9.SetActive(true);
                                            mainObject10.SetActive(false);
                                        }
                                        else
                                        {
                                            if (destTile.gridPosition == new Vector2(0, 1)) // Presentor
                                            {
                                                mainObject.SetActive(false);
                                                mainObject2.SetActive(false);
                                                mainObject3.SetActive(false);
                                                mainObject4.SetActive(false);
                                                mainObject5.SetActive(false);
                                                mainObject6.SetActive(false);
                                                mainObject7.SetActive(false);
                                                mainObject8.SetActive(false);
                                                mainObject9.SetActive(false);
                                                mainObject10.SetActive(true);
                                            }
                                            else
                                            {
                                                mainObject.SetActive(false);
                                                mainObject2.SetActive(false);
                                                mainObject3.SetActive(false);
                                                mainObject4.SetActive(false);
                                                mainObject5.SetActive(false);
                                                mainObject6.SetActive(false);
                                                mainObject7.SetActive(false);
                                                mainObject8.SetActive(false);
                                                mainObject9.SetActive(false);
                                                mainObject10.SetActive(false);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }
        
    }

    

    void generateMap ()
    {
        map = new List<List<Tile>>();
        for (int i = 0; i < mapSize; i++)
        {
            List<Tile> row = new List<Tile>();
            for (int j = 0; j < mapSize; j++)
            {                
                Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(mapSize/2),0, -j + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
                tile.gridPosition = new Vector2(i, j);
                row.Add(tile);               
            }
            map.Add(row);
        }
    }

    void generatePlayers()
    {

        UserPlayer player;
        player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(0 - Mathf.Floor(mapSize / 2), 1.5f, -0 + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
        player.gridPosition = new Vector2(0,0);
        players.Add(player);        

        player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3((mapSize-1) - Mathf.Floor(mapSize / 2), 1.5f, -(mapSize - 1) + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
        player.gridPosition = new Vector2(mapSize - 1, -(mapSize - 1));
        players.Add(player);

        player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(4 - Mathf.Floor(mapSize / 2), 1.5f, -4 + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
        player.gridPosition = new Vector2(4, -4);
        players.Add(player);

        player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(5 - Mathf.Floor(mapSize / 2), 1.5f, -6 + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
        player.gridPosition = new Vector2(5, -6);
        players.Add(player);
    }

    
}
