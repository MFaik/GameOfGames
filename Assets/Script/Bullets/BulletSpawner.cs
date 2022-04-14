using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] float SpawnInterval = .5f;
    [SerializeField] float DegreeOffset = 31;
    [SerializeField] float BulletSpeed = 4f;

    float _degree = 0;

    void Start() {
        StartCoroutine(nameof(Shoot));
    }

    IEnumerator Shoot() {
        while(true){
            yield return new WaitForSeconds(SpawnInterval);
            if(GameController.Dead)
                yield break;
            for(int i = 0;i < (int)(360/DegreeOffset);i++){
                Instantiate(Bullet, transform.position, Quaternion.Euler(0,0,_degree))
                    .GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0,0,_degree) * new Vector2(BulletSpeed,0);

                _degree += DegreeOffset;
            }
        }
    }
}
