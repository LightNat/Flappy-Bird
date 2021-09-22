using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    float birdXPosition;
    bool isScoreAdded;

    GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myRigidBody.velocity = new Vector2(-2.5f, 0);

        birdXPosition = GameObject.Find("Bird").transform.position.x;

        isScoreAdded = false;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= birdXPosition)
        {
            if (!isScoreAdded)
            {
                AddScore();
                isScoreAdded = true;
            }
        }
        if (transform.position.x < -14)
        {
            Destroy(gameObject);
        }
    }

    void AddScore()
    {
        gameManager.GmAddScore();
    }
}
