using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{   
    public GameObject[] tilePrefabs; // This allows us to make an array of game objects that we can assign to the tile prefabs that I made
    public float zGenerate = 0; // This variable was made to decide the starting point of the infinite generation of the tiles
    public float tileLength = 30; // This tells the game how long each tile is (each tile is from 0-30 on the z axis)
    public int numTiles = 5; // This is the number of tiles that apppear all at once on the screen
    private List<GameObject> liveTiles = new List<GameObject>(); // This creates a list of new used tiles

    public Transform playerTrans; // This is the players transform

    void Start()
    {
        for (int i = 0; i < numTiles; i++) // This is a for loop that will spawn 5 tiles at random
        {   
            if(i == 0)
                GenerateTile(0); // This makes sure that the first tile is the tile with no obstacles as that is what we want
            else
                GenerateTile(Random.Range(0,tilePrefabs.Length)); // This spawns 5 random tiles
        }
    }

    void Update()
    {                   // -35 creates a safe zone so that when the game starts the first tile isnt deleted 
       if (playerTrans.position.z - 35 > zGenerate - (numTiles * tileLength)) //This checks if the player transform is greater than the z generate and if so it generates more tiles
       {
        GenerateTile(Random.Range(0,tilePrefabs.Length)); // This makes infinite tiles being generated while the player moves forward
        DelTile(); // This helps to delete tiles
       }
    }
    
    public void GenerateTile(int tileIndex) // This takes the index of the tile that needs to be generated
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zGenerate, transform.rotation); // This uses the instantiate function which instantiates the tileIndex in the tilePrefabs
        liveTiles.Add(go); // This adds the live tiles that are being used to the live tiles list
        zGenerate += tileLength; // This adds the length of the tiles to the zgenerate so that it knows where to generate the next tile from the tile before as they have to be in 30 intervals
    }
    private void DelTile()
    {
        Destroy(liveTiles[0]); // This deletes/destroys the first tile in the list
        liveTiles.RemoveAt(0); // This removes the first tile from the list
    }

}