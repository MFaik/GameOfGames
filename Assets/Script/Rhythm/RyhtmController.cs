using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyhtmController : MonoBehaviour
{
    [SerializeField] GameObject Left,Mid,Right;
    [SerializeField] float SpawnInterval = 3f;
    [SerializeField] GameObject NotePrefab;
    [SerializeField] float NoteSpeed = 3f;
    
    void Start() {
        StartCoroutine(nameof(SpawnNote));
    }

    IEnumerator SpawnNote() {
        while(true){
            yield return new WaitForSeconds(SpawnInterval);
            if(GameController.Dead)
                break;
            Note note = Instantiate(NotePrefab, transform.position + new Vector3(Random.Range(-1,2)*1.5f,5.5f), Quaternion.identity).GetComponent<Note>();
            note.Init(-NoteSpeed);
        }
    }

    public void LeftPressed() {
        Left.SetActive(true);
        Mid.SetActive(false);
        Right.SetActive(false);
    }

    public void MidPressed() {
        Left.SetActive(false);
        Mid.SetActive(true);
        Right.SetActive(false);
    }

    public void RightPressed() {
        Left.SetActive(false);
        Mid.SetActive(false);
        Right.SetActive(true);
    }
}
