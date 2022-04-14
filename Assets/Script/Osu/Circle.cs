using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Circle : MonoBehaviour
{
    [SerializeField] TextMeshPro CountDownText;

    [SerializeField] float MinSize = .3f, MaxSize = 1.5f;
    [SerializeField] float TTL = 10;
    float _timer;

    [SerializeField] GameObject ParentObject;
    [SerializeField] GameObject DieParticle;
    [SerializeField] GameObject ClickParticle;

    void Start() {
        _timer = TTL;    
    }

    void Update() {
        if(GameController.Dead)
            return;
        CountDownText.text = (int)_timer+"";

        if(_timer <= 0){
            GameController.Die();
            Instantiate(DieParticle, transform.position, Quaternion.identity);
        } else {
            _timer -= Time.deltaTime;
            float scale = (TTL-_timer).Remap(0,TTL,MinSize,MaxSize);
            transform.localScale = new Vector2(scale, scale);
        }
    }

    public void OnPressed() {
        Instantiate(ClickParticle, transform.position, Quaternion.identity);
        Destroy(ParentObject);
    }
}
