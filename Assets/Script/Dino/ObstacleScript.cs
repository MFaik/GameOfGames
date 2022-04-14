using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    float _speed, _TTL, _timeLeft;

    void Start() {
        _timeLeft = _TTL;  
    }

    public void Init(float speed, float TTL) {
        _speed = speed;
        _TTL = TTL;
    }

    void Update() {
        if(GameController.Dead)
            return;

        _timeLeft -= Time.deltaTime;
        if(_timeLeft <= 0)
            Destroy(gameObject);
        transform.position += new Vector3(_speed*Time.deltaTime,0,0);
    }
}
