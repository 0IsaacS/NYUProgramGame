using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    //Fields
    public List<GameObject> setpiecePrefabs;
    public GameObject spawnPlatform, bossAreaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Generate(2);
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
            last = spawnPiece(last, setpiecePrefabs[Random.Range(0, setpiecePrefabs.Count - 1)]);
        }

        spawnPiece(bossAreaPrefab, last);
    }

    //returns the GameObject of the newly spawned piece and spawns it
    GameObject spawnPiece(GameObject pieceToSpawn, GameObject lastPiece)
    {
        Vector2 lastPos = lastPiece.transform.position;
        SetpieceInfo lastInfo = lastPiece.GetComponent<SetpieceInfo>();
        SetpieceInfo spawnInfo = pieceToSpawn.GetComponent<SetpieceInfo>();

        return Instantiate(pieceToSpawn, lastPos + new Vector2(lastInfo.xLength / 2 + spawnInfo.xLength / 2 + Random.Range(1f, 5f), Random.Range(-5f, 5f)), Quaternion.identity);
    }
}
