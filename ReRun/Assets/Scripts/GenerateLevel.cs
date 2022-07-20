using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    //Fields
    public List<GameObject> setpiecePrefabs;
    public GameObject spawnPlatform, bossAreaPrefab;
    public int piecesToGenerate;

    // Start is called before the first frame update
    void Start()
    {
        piecesToGenerate = 10; //for testing and stuff
        Generate(piecesToGenerate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Generate(int numPieces)
    {
        GameObject last = spawnPlatform; //change later maybe
        for (int i = 0; i < numPieces; i++)
        {
            last = spawnPiece(setpiecePrefabs[Random.Range(0, setpiecePrefabs.Count)], last);
        }

        spawnPiece(bossAreaPrefab, last);
    }

    //returns the GameObject of the newly spawned piece and spawns it
    GameObject spawnPiece(GameObject pieceToSpawn, GameObject lastPiece)
    {
        Vector2 lastPos = lastPiece.transform.position;
        SetpieceInfo lastInfo = lastPiece.GetComponent<SetpieceInfo>();
        SetpieceInfo spawnInfo = pieceToSpawn.GetComponent<SetpieceInfo>();

        return Instantiate(pieceToSpawn, lastPos + new Vector2(lastInfo.xLength / 2 + spawnInfo.xLength / 2 + Random.Range(2f, 7f), Random.Range(-3f, 3f)), Quaternion.identity);
    }
}
