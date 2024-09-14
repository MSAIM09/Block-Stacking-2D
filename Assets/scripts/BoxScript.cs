using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public static BoxScript instance;
    public float min_X= -2f, max_X = 2f;
    private bool canMove;
    public float moveSpeed = 3.0f;
    private Rigidbody2D myBody;
    private bool gameOver;
    private bool ignoreCollosion;
    private bool ignoreTrigger;
    

    private void Awake()
    {
        if (instance == null)
            {
                instance = this;
            }

        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;
        MoveBox();
    }
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        if(Random.Range(0,2)> 0)
        {
            moveSpeed *= -1f;
        }
        GameplayController.instance.currentBox = this;

        

    }

    void MoveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;

            if (temp.x > max_X)
            {
                moveSpeed *= -1f;
            }
            else if (temp.x < min_X)
            {
                moveSpeed *= -1f;
            }

            transform.position = temp;
        }
    }

    public void DropBox()
    {
        canMove = false;
        myBody.gravityScale = Random.Range(2, 4);
    }

    void Landed()
    {
        if (gameOver)
            return;

        ignoreCollosion = true;
        
        Debug.Log("BoxLanded");
        
        ScoreManager.instance.AddScore();

        GameplayController.instance.Invoke("SpawnNewBox", 0.5f);
        GameplayController.instance.MoveCamera();
    }

    public void LevelFailed()
    {
        StartCoroutine(ActivateLevelFailedUI());
        GameplayController.instance.levelFailedUI.SetActive(true);
        Debug.Log("Game Restart"); // This will execute immediately
    }

    private IEnumerator ActivateLevelFailedUI()
    {
        
        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        // After 2 seconds, execute the following lines
        GameplayController.instance.RestartGame();
        
    }



    // Update is called once per frame
    void Update()
    {
        MoveBox();
    }

    public void OnCollisionEnter2D(Collision2D target) 
    {
        if (ignoreCollosion)
         
            return;
        if (target.gameObject.tag == "platform")
        {
            Invoke("Landed", 1);
            ignoreCollosion = true;
        }

        if (target.gameObject.tag == "Box")
        {
            Invoke("Landed", 1);
            ignoreCollosion = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D target)
    {
        if (ignoreTrigger)
            return;

        if (target.tag == "GameOver")
        {
            CancelInvoke("Landed");
            Debug.Log("GameOver taged");
            gameOver = true;
            ignoreTrigger = false;
            ignoreCollosion = false;


            LevelFailed();
        }
    }
}
