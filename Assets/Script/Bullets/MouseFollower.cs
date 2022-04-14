using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField] GameObject DieParticle;

    Camera _mainCamera;

    void Start() {
        _mainCamera = Camera.main;    
    }

    void Update() {
        transform.position = (Vector2)_mainCamera.ScreenToWorldPoint(Input.mousePosition);  
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")){
            Instantiate(DieParticle, transform.position, Quaternion.identity);
            GameController.Die();
        }    
    }
}
