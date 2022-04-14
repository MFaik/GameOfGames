using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [SerializeField] GameObject CirclePrefab;
    [SerializeField] float SpawnInterval = 3f;

    BoxCollider2D _boxCollider2D;

    void Start() {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(nameof(SpawnCircle));
    }

    IEnumerator SpawnCircle() {
        while(true){
            yield return new WaitForSeconds(SpawnInterval);
            if(GameController.Dead)
                break;
            Vector2 RandomPos = new Vector2(Random.Range(_boxCollider2D.bounds.min.x,_boxCollider2D.bounds.max.x), 
                                            Random.Range(_boxCollider2D.bounds.min.y,_boxCollider2D.bounds.max.y));
            Instantiate(CirclePrefab, RandomPos, Quaternion.identity);
        }
    }
}
