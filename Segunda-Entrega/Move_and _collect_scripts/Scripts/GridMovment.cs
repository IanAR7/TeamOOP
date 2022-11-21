using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//basado en el código de INDIERAMA
//https://www.youtube.com/watch?v=A4FT5ZYbI1c&t=310s

public class GridMovment : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    //SerializField can be changed in the unity engine
    [SerializeField] private float moveTime = 0.14f;

    private Vector2 targetPosition;
    private float xInput, yInput;
    private bool isMoving;

    // Update is called once per frame
    void Update()
    {
        
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        //to only move the player one square in the  grid like chess
        if((xInput != 0f || yInput != 0f) && !isMoving && Input.anyKeyDown)
        {
            
            CalculateTargetPosition();
            if (CanMoveToTargetPosition())
            {
                StartCoroutine(Move());
            }
            
        } 
    }

    //moves the player
    IEnumerator Move()
    {
        isMoving = true;
        float timeElapsed = 0f;
        Vector2 startPosition = transform.position;

        while (timeElapsed < moveTime)
        {
            //to move the player in the engine
            transform.position = Vector2.Lerp(startPosition, targetPosition, timeElapsed / moveTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }
    

    // moves the player depending on the key pressed
    private void CalculateTargetPosition()
    {
        if(xInput == 1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.right;
        }
        else if (xInput == -1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.left; 
        }
        else if (yInput == 1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.up; 
        }
        else if (yInput == -1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.down; 
        }

        
    }

    //to see if there is a collider in the position we want to move
    private bool CanMoveToTargetPosition()
    {
        return !Physics2D.OverlapCircle(targetPosition, 0.20f);
    }
}
