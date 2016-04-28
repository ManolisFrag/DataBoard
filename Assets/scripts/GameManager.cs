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

        if (destTile.gridPosition == new Vector2(5, 0) || destTile.gridPosition == new Vector2(6, 0) || destTile.gridPosition == new Vector2(0, 1) || destTile.gridPosition == new Vector2(0, 4) || destTile.gridPosition == new Vector2(7, 1) || destTile.gridPosition == new Vector2(6,7) || destTile.gridPosition == new Vector2(5, 7) || destTile.gridPosition == new Vector2(7, 6))   // THIS IS WHERE i CAN SHOW THE TEXT
        {
            //Debug.Log("DONE");
            mainObject.SetActive(true);
            mainObject2.SetActive(false);
            mainObject3.SetActive(false);
            mainObject4.SetActive(false);
            mainObject5.SetActive(false);
            mainObject6.SetActive(false);
            mainObject7.SetActive(false);
        }
        else
        {
            if (destTile.gridPosition == new Vector2(0, 5) || destTile.gridPosition == new Vector2(7, 5) || destTile.gridPosition == new Vector2(0, 6) || destTile.gridPosition == new Vector2(3,7) || destTile.gridPosition == new Vector2(4, 7))
            {
                mainObject.SetActive(false);
                mainObject2.SetActive(true);
                mainObject3.SetActive(false);
                mainObject4.SetActive(false);
                mainObject5.SetActive(false);
                mainObject6.SetActive(false);
                mainObject7.SetActive(false);
            }
            else
            {
                if (destTile.gridPosition == new Vector2(4, 0) || destTile.gridPosition == new Vector2(0, 2) || destTile.gridPosition == new Vector2(7, 2) || destTile.gridPosition == new Vector2(2, 7))
                {
                    mainObject.SetActive(false);
                    mainObject2.SetActive(false);
                    mainObject3.SetActive(true);
                    mainObject4.SetActive(false);
                    mainObject5.SetActive(false);
                    mainObject6.SetActive(false);
                    mainObject7.SetActive(false);
                }
                else
                {
                    if (destTile.gridPosition == new Vector2(7, 3) || destTile.gridPosition == new Vector2(1, 7))
                    {
                        mainObject.SetActive(false);
                        mainObject2.SetActive(false);
                        mainObject3.SetActive(false);
                        mainObject4.SetActive(true);
                        mainObject5.SetActive(false);
                        mainObject6.SetActive(false);
                        mainObject7.SetActive(false);
                    }
                    else
                    {
                        if (destTile.gridPosition == new Vector2(3, 0))
                        {
                            mainObject.SetActive(false);
                            mainObject2.SetActive(false);
                            mainObject3.SetActive(false);
                            mainObject4.SetActive(false);
                            mainObject5.SetActive(true);
                            mainObject6.SetActive(false);
                            mainObject7.SetActive(false);
                        }
                        else
                        {
                            if (destTile.gridPosition == new Vector2(1, 0))
                            {
                                mainObject.SetActive(false);
                                mainObject2.SetActive(false);
                                mainObject3.SetActive(false);
                                mainObject4.SetActive(false);
                                mainObject5.SetActive(false);
                                mainObject6.SetActive(true);
                                mainObject7.SetActive(false);
                            }
                            else
                            {
                                if (destTile.gridPosition == new Vector2(2, 0))
                                {
                                    mainObject.SetActive(false);
                                    mainObject2.SetActive(false);
                                    mainObject3.SetActive(false);
                                    mainObject4.SetActive(false);
                                    mainObject5.SetActive(false);
                                    mainObject6.SetActive(false);
                                    mainObject7.SetActive(true);
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
