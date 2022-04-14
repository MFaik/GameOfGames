using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickManager : MonoBehaviour
{
    Camera _mainCamera;
    Collider2D _collider;

    [SerializeField] UnityEvent<Vector2> OnPressed;
    [SerializeField] UnityEvent OnReleased;
    
    void Start() {
        _mainCamera = Camera.main;
        _collider = GetComponent<Collider2D>();
    }

    void Update() {
        if(GameController.Dead){
            if(Input.GetMouseButton(0))
                OnReleased.Invoke();
            return;
        }
        Vector2 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0) && _collider.bounds.Contains(mousePos)){
            OnPressed.Invoke(mousePos);
        }
        if(Input.GetMouseButtonUp(0)){
            OnReleased.Invoke();
        }
    }
}
