using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameObject player;
    public GameObject chunkPrefab;
    List<Vector2> chunks = new List<Vector2>();
    public Vector2 playersLocation;
    private Vector2 oldPlayersLocation;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playersLocation = new Vector2((int)(player.transform.position.x / 14), (int)(player.transform.position.z / 14));
        //StartCoroutine(makeLand());
    }

    // Update is called once per frame
    void Update()
    {
        //playersLocation = new Vector2((int)(player.transform.position.x / 14), (int)(player.transform.position.z / 14));
        //if (oldPlayersLocation != playersLocation)
        //{        
        //    oldPlayersLocation = playersLocation;
        //    StartCoroutine(makeLand());
        //}


    }

    public IEnumerator makeLand()
    {
        bool done = false;
        float playerX = playersLocation.x;
        float playerY = playersLocation.y;
        Transform tform = transform;

            for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {

                bool alreadyThere = false;
                for (int i = 0; i < chunks.Count; i++)
                {
                    if (chunks[i] == new Vector2(playersLocation.x + x, playersLocation.y + y))
                        alreadyThere = true;
                }
                if(!alreadyThere)
                {
                    GameObject chunk = Instantiate(chunkPrefab, new Vector3((playerX + x) * 14, 0, (playerY + y) * 14), Quaternion.identity, tform);
                    chunks.Add(new Vector2(playersLocation.x + x, playersLocation.y + y));
                }

            }

        }
            done = true;

        // Do nothing on each frame until the thread is done
        while (!done)
        {
            yield return null;
        }
    }

}
