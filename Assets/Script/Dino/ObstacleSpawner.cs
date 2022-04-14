using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> Obstacles;
    [SerializeField] float SpawnInterval = 2f;
    [SerializeField] float ObstacleSpeed = 2f,ObstacleTTL = 5f;

    void Awake() {
        StartCoroutine(nameof(SpawnObject));
    }

    IEnumerator SpawnObject() {
        while(true){
            yield return new WaitForSeconds(SpawnInterval);
            if(GameController.Dead)
                break; 
            ObstacleScript obstacle = Instantiate(Obstacles[Random.Range(0,Obstacles.Count)], transform.position, Quaternion.identity).GetComponent<ObstacleScript>();
            obstacle.Init(-ObstacleSpeed, ObstacleTTL);
        }
    }
}
