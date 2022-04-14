using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshPro _scoreUI;

    float _score = 0;

    bool _dead = false;

    void Start() {
        _scoreUI = GetComponent<TextMeshPro>();
    }

    void Update() {
        if(!_dead){
            _score += Time.deltaTime;
            _scoreUI.text = (int)_score + "";
        }
    }

    public void Die(){
        _dead = true;
    }
}
