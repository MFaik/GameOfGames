using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
    [SerializeField] Color Idle,Pressed;

    SpriteRenderer _spriteRenderer;

    void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnMousePressed() {
        _spriteRenderer.color = Pressed;
    }
    public void OnMouseReleased() {
        _spriteRenderer.color = Idle;
    }
}
