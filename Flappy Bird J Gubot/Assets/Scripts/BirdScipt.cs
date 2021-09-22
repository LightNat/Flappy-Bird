using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScipt : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;
    private float jumpforce;
    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;

        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myAnimator = gameObject.GetComponent<Animator>();

        jumpforce = 10f;
        myRigidBody.gravityScale = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (Input.GetMouseButton(0) || Input.GetKeyDown("space"))
            {
                Flap();
            }
            CheckIfBirdVisibleOnScreen();
        }
    }

    void Flap()
    {
        myRigidBody.velocity = new Vector2(0, jumpforce);

        myAnimator.SetTrigger("Flap");
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Obstacles")
        {
            isAlive = false;
            Time.timeScale = 0f;
        }
    }

    //
    void CheckIfBirdVisibleOnScreen()
    {
        if (Mathf.Abs(gameObject.transform.position.y) > 5.75f)
        {
            isAlive = false;
            Time.timeScale = 0f;
        }
    }
}
