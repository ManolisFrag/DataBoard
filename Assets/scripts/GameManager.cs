using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameObject TilePrefab;
    public GameObject UserPlayerPrefab;
    

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
	}
	
	// Update is called once per frame
	void Update () {
        players[currentPlayerIndex].TurnUpdate();
        
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
        players.Add(player);        

        player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3((mapSize-1) - Mathf.Floor(mapSize / 2), 1.5f, -(mapSize - 1) + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
        players.Add(player);

        player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(4 - Mathf.Floor(mapSize / 2), 1.5f, -4 + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
        players.Add(player);

        player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(5 - Mathf.Floor(mapSize / 2), 1.5f, -6 + Mathf.Floor(mapSize / 2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
        players.Add(player);
    }
}
