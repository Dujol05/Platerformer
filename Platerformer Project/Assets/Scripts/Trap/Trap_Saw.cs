using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Saw : Trap
{
    private Animator anim;
    [SerializeField] private Transform[] MovePoints;
    [SerializeField] private float speed;
    public readonly int workParameterHash = Animator.StringToHash("isWorking");

    private SpriteRenderer spriteRenderer;
    private int movePointIndex;
    private bool goingForward;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        movePointIndex = 0;
    }

    void Update()
    {
        anim.SetBool(workParameterHash, isWorking);

        transform.position = Vector3.MoveTowards(transform.position, MovePoints[movePointIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, MovePoints[movePointIndex].position) < 0.15f)
        {
            if (movePointIndex == 0)
            {
                Flip(goingForward);
                goingForward = true;
            }

            if (goingForward)
                movePointIndex++;
            else
                movePointIndex--;

            if (movePointIndex >= MovePoints.Length)
            {
                movePointIndex = MovePoints.Length - 1;
                goingForward = false;
            }
        }
    }

    private void Flip(bool isFlip)
    {
        spriteRenderer.flipX = isFlip;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
