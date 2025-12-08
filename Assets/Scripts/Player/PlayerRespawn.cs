using Unity.Cinemachine;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("--Player Object--")]
    public GameObject playerObj;
    [Header("--Spawn Point--")]
    public GameObject spawnPoint;
    [Header("--Respawn Timer--")]
    public int respawnTime;

    private CinemachineCamera camFollower;
    private float time;
    private bool isRespawning;

    private void Start()
    {
        isRespawning = false;
        camFollower = GameObject.FindGameObjectWithTag("CameraFollower").GetComponent<CinemachineCamera>();
    }
    private void Update()
    {
        if(isRespawning)
        {
            time += Time.deltaTime;
            if(time >= respawnTime)
            {
                respawnPlayer();
                time = 0f;
                isRespawning = false;
            }
        }
        if(spawnPoint.transform.childCount <= 0)
        {
            isRespawning = true;
        }
    }

    private void respawnPlayer()
    {
        Vector2 spawnPos = spawnPoint.transform.position;
        GameObject tempPlayer = Instantiate(playerObj, spawnPoint.transform, true);
        tempPlayer.transform.position = spawnPos;
        camFollower.Target.TrackingTarget = tempPlayer.transform;
        tempPlayer.GetComponent<WeaponHandler>().resetPlayerInventory();

    }
}
