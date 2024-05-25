using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnTransform;

    private PlayerContoller playerContoller;
    [SerializeField] private PlayerCam playerCam;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer();
        }

        //if(player != null)
        //{
        //  RespawnPlayer();
        //}
    }

    public void RespawnPlayer()
    {
        player = Instantiate(playerPrefab, spawnTransform.position, Quaternion.identity);

        playerContoller = player.GetComponent<PlayerContoller>(); // 다른 코드에 접근 하는 방법
    }
}
