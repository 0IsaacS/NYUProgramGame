using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    //Fields
    public List<GameObject> setpiecePrefabs, bossAreaPrefabs;
    public GameObject spawnPlatform, healthUpPrefab, RapidFirePrefab;
    public int piecesToGenerate;

    // Start is called before the first frame update
    void Start()
    {
        piecesToGenerate = 16; //for testing and stuff
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
            if (Random.Range(0.0f, 1.0f) < 0.25f) //1 in 4 chance to sapwn
            {
                spawnPowerUp(healthUpPrefab, last);
            }
            if (Random.Range(0.0f, 1.0f) < 0.20f) //1 in 5 chance to sapwn
            {
                spawnPowerUp(RapidFirePrefab, last);
            }
        }

        spawnPiece(bossAreaPrefabs[Random.Range(0, bossAreaPrefabs.Count)], last);
    }

    //returns the GameObject of the newly spawned piece and spawns it
    GameObject spawnPiece(GameObject pieceToSpawn, GameObject lastPiece)
    {
        Vector2 lastPos = lastPiece.transform.position;
        SetpieceInfo lastInfo = lastPiece.GetComponent<SetpieceInfo>();
        SetpieceInfo spawnInfo = pieceToSpawn.GetComponent<SetpieceInfo>();

        return Instantiate(pieceToSpawn, lastPos + new Vector2(lastInfo.xLength / 2 + spawnInfo.xLength / 2 + Random.Range(2f, 7f), Random.Range(-3f, 3f)), Quaternion.identity);
    }
    private void spawnPowerUp(GameObject spawn, GameObject last)
    {
        if (!last.GetComponent<SetpieceInfo>().hasPowerUp)
        {
            switch (last.tag)
            {
                case "short":
                    Instantiate(spawn, last.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
                    break;
                case "tall":
                    Instantiate(spawn, last.transform.position + new Vector3(0, 7, 0), Quaternion.identity);
                    break;
                case "negative":
                    Instantiate(spawn, last.transform.position + new Vector3(0, -3, 0), Quaternion.identity);
                    break;
                default:
                    Instantiate(spawn, last.transform.position + new Vector3(0, 4, 0), Quaternion.identity);
                    break;
            }
            last.GetComponent<SetpieceInfo>().hasPowerUp = true;
        }
    }
}
