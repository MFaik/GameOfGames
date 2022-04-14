using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] float MaxLength = 3;
    float _length;
    float _depletionSpeed = 0;
    [SerializeField] float DepletionAcceleration = .2f;
    bool _isDepleting = true;
    [SerializeField] float FillSpeed = .5f;

    float _startPos, _startScale;
    void Start() {
        _length = MaxLength;
        _startPos = transform.position.x;
        _startScale = transform.localScale.x;
    }

    void Update() {
        if(_isDepleting){
            _depletionSpeed += DepletionAcceleration * Time.deltaTime;
            _length -= _depletionSpeed * Time.deltaTime;
        } else {
            _length += FillSpeed * Time.deltaTime;
        }

        if(_length <= 0 && !GameController.Dead){
            GameController.Die();
        }
        _length = Mathf.Clamp(_length, 0, MaxLength);

        transform.localScale = new Vector3(_length / MaxLength * _startScale,transform.localScale.y,transform.localScale.z);
        transform.position = new Vector2(_startPos - (MaxLength-_length) / MaxLength * _startScale / 2, transform.position.y);
    }

    public void StartFill() {
        _isDepleting = false;
        _depletionSpeed = 0;
    }

    public void StopFill() {
        _isDepleting = true;
    }
}
