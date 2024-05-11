using System;
using UnityEngine;
using UnityEngine.AI;

// ���� ������ public private protected
public class PlayerContoller : MonoBehaviour
{
    // Start, Update ����Ƽ �̺�Ʈ �Լ��� ���� �̸��� �ִ��� ����
    // ���� �̸��� ������? ����Ƽ���� ���س��� ���� �ð��� �� �Լ��� ����


    // Start is called before the first frame update
    // ù �������� �ҷ��������� (�ѹ�) �����Ѵ�. �ѹ���!

    // �ӵ�, ����
    [Header("�̵�")]
    public float moveSpeed = 5f;     // ĳ������ �̵� �ӵ�
    public float JumpForce = 10f;
    private float moveInput;  // �÷��̾��� ���� �� ���� ������ ����

    public Transform startTransform; // ĳ���Ͱ� ������ ��ġ�� �����ϴ� ����
    public new Rigidbody2D rigidbody2D;  // ����(����) ����� �����ϴ� ������Ʈ

    [Header("����")]
    public bool isGrounded;          // true : ĳ���Ͱ� ���� �� �� �ִ� ����, false : ���� ����   
    public float groundDistance = 2f;
    public LayerMask groundLayer;

    [Header("Flip")]
    public SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    private int facingDirection = 1;

    public Animator animator;
    private bool isMove;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        Debug.Log("Hello Unity");
        // ���� �� ��ġ <= ���ο� x,y �����ϴ� ������ Ÿ��(���� x��ǥ, 10 y��ǥ)
        //transform.position = new Vector2(transform.position.x, 10);

        // ���� �� ��ġ�� startTransform���� ����
        InitializePlayerStatus();

    }

    void InitializePlayerStatus()
    {
        transform.position = startTransform.position;
    }

    // Update is called once per frame
    // 1 �����ӿ� �ѹ� ȣ��ȴ�. - �ݺ������� ����
    void Update()
    {
        HandleAnimation();
        CollisionCheck();
        HandleInput();
        HandleFlip();
        Move();
        FallDownCheck();
        // ������ �� �� ������ �ƴ��� üũ �ϴ��� ��� -> Collider Check
        // �÷��̾��� �Է� ���� �޾ƿ;� �Ѵ�.  a,d Ű���� �� �� Ű�� ������ �� -1 ~ 1 ��ȯ�ϴ� Ŭ����
        // �÷��̾��� �Է��� �޾ƿ��� �ڵ�


    }

    private void FallDownCheck()
    {
        // y�� ���̰� Ư�� �������� ���� �� ������ ������ �����Ѵ�. -> �浹 üũ ��ü
        if(transform.position.y < -11)
        {
            InitializePlayerStatus();
            rigidbody2D.velocity = Vector2.zero;
            facingRight = true;
            spriteRenderer.flipX = false;
        }
    }

    private void HandleAnimation()
    {
        // rigidbody.velocity : ���� rigidbody �ӵ� = 0 �������� �ʴ� ����, !=0 �����̰� �ִ� ����
        isMove = rigidbody2D.velocity.x != 0;
        animator.SetBool("isMove", isMove);
        animator.SetBool("isGrounded", isGrounded);
        // SetFloat �Լ��� ���ؼ� y�ִ��� �� 1�� ��ȯ.. y
    }

    /// <summary>
    /// �÷��̾� �̵��� �ʿ��� Bool ���� �����ϴ� �Լ�
    /// </summary>
    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
    }

    /// <summary>
    /// ������ �Է��� �����ϴ� �Լ�
    /// </summary>

    private void HandleInput()
    {
        moveInput = Input.GetAxis("Horizontal");

        JumpButton();
    }

    private void HandleFlip()
    {
        // ������ �������� �ٶ󺸰� ���� ��
        if (facingRight && moveInput < 0)
        {
            Flip();
        }
        // ���� �������� �ٶ󺸰� ���� ��
        else if(!facingRight && moveInput > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingDirection = facingDirection * -1;
        facingRight = !facingRight;
        spriteRenderer.flipX = !facingRight;
    }

    private void JumpButton()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
    }


    private void Move()
    {
        rigidbody2D.velocity = new Vector2(moveSpeed * moveInput, rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));
    }
}
