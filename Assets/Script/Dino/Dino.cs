using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

    [SerializeField] float JumpSpeed = 5;

    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(transform.position.y < 0 && !GameController.Dead)
            GameController.Die();    
    }

    public void Jump() {
        if(transform.position.x >= -1)
            _rigidbody2D.velocity = new Vector2(0, JumpSpeed);
    }
}
