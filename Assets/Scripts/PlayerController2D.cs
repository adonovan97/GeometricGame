using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed;
    public Transform movePoint;
    public static int numTriangles;

    public LayerMask whatStopsMovement;
    public LayerMask CollectionShape;
    public LayerMask WrongShapeCollected;

    public Animator animator;

    public GameObject heart, heart2, heart3, gameOver, winGame;
    public static int health;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        numTriangles = 0;
        health = 3;
        heart.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        winGame.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }

            }
        }
        animator.SetFloat("SpeedVertical", Input.GetAxisRaw("Vertical"));
        animator.SetFloat("SpeedHorizontal", Input.GetAxisRaw("Horizontal"));
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }
        switch (health)
        {
            case 3:
                heart.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                break;
        }

        if(numTriangles == 5)
        {
            winGame.gameObject.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D node)
    {
        if (node.gameObject.CompareTag("EquilateralTriangle"))
        {
            ScoreScript.scoreValue += 1;
            numTriangles += 1;
            node.gameObject.SetActive(false);
        }
        if (node.gameObject.CompareTag("WrongCollect"))
        {
            health -= 1;
        }
    }
}
