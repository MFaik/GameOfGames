using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] GameObject HitParticle;
    [SerializeField] GameObject MissParticle;
    float _speed;

    public void Init(float speed) {
        _speed = speed;
    }

    void Update() {
        if(GameController.Dead)
            return;

        transform.position += new Vector3(0,_speed) * Time.deltaTime;
        if(transform.position.y < -5){
            GameController.Die();
            Instantiate(MissParticle,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("BeatHit")){
            Instantiate(HitParticle,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }   
    }
}
