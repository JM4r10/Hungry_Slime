using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Scene currentScene;
    [SerializeField] int food;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MainScene")
        {
            food = GameObject.FindGameObjectsWithTag("Food").Length;
        }
    }

    private void LateUpdate()
    {
        if (food == 0 && currentScene.name == "MainScene") Victory();
    }

    public void GameOver() => SceneManager.LoadScene(currentScene.name);

    public void Victory() => SceneManager.LoadScene("Victory");

    public void ReduceFood() => --food;



}

