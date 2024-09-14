using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    public BoxSpawner boxSpawner;
    public Text timerText;
    private float timeRemaining = 60f;
    private bool timerRunning = true;
    public GameObject levelFailedUI;

    [HideInInspector]
    public BoxScript currentBox;
    public CameraFollow CameraScript;
    private int moveCount;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       // levelFailedUI.SetActive(false);
        boxSpawner.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();

        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerRunning = false;
                BoxScript.instance.LevelFailed();
                Debug.Log("Timeup, Game restart");
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void DetectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentBox.DropBox();
        }
    }

    public void SpawnNewBox()
    {
        Invoke("NewBox", 1f);
    }

    void NewBox()
    {
        boxSpawner.SpawnBox();
    }

    public void MoveCamera()
    {
        moveCount++;
        if (moveCount == 3)
        {
            moveCount = 0;
            CameraScript.targetPos.y += 1f;
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Handle scenario when there's no next level (you've reached the end)
            Debug.Log("No more levels!");
        }
    }

    
}
