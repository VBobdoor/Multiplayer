using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float minX, minY, maxX, maxY;

    void Start()
    {
        Vector2 randomPosition = new Vector3(Random.Range(minX, maxX), 1 , Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(player.name, randomPosition, Quaternion.identity);
    }
}
