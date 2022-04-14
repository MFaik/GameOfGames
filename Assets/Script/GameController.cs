using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static GameController _Instance;
    public static GameController Instance
    {
        get
        {
            if (!_Instance)
            {
                _Instance = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            }
            return _Instance;
        }
    }

    public static bool Dead{get;private set;}

    [SerializeField] Score Score;
    [SerializeField] GameObject RestartMenu;

    [SerializeField] float DinoWait = 3f;
    [SerializeField] GameObject Dino;

    [SerializeField] float OsuWait = 8f;
    [SerializeField] GameObject Osu;

    [SerializeField] float RhythmWait = 8f;
    [SerializeField] GameObject Rhythm;

    [SerializeField] float BulletSpawnerWait = 15f;
    [SerializeField] GameObject BulletSpawner;

    void Awake() {
        if(!_Instance){
            _Instance = this;
        } else
            Destroy(gameObject);
        
        Time.timeScale = 1;
    }

    void Start() {
        Dead = false;
        StartCoroutine(nameof(UnlockGames));
    }

    IEnumerator UnlockGames() {
        yield return new WaitForSeconds(DinoWait);
        Dino.SetActive(true);
        yield return new WaitForSeconds(OsuWait);
        Osu.SetActive(true);
        yield return new WaitForSeconds(RhythmWait);
        Rhythm.SetActive(true);
        yield return new WaitForSeconds(BulletSpawnerWait);
        BulletSpawner.SetActive(true);
    }

    public static void Die() {
        Time.timeScale = 0;
        Dead = true;
        Instance.Score.Die();
        Instance.RestartMenu.SetActive(true);
        Instance.StopAllCoroutines();
    }

    public static void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

}
