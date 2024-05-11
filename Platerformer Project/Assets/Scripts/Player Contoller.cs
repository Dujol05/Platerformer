using System;
using UnityEngine;
using UnityEngine.AI;

// 접근 지정자 public private protected
public class PlayerContoller : MonoBehaviour
{
    // Start, Update 유니티 이벤트 함수의 같은 이름이 있는지 조사
    // 같은 이름이 있으면? 유니티에서 정해놓은 실행 시간에 그 함수를 실행


    // Start is called before the first frame update
    // 첫 프레임이 불러지기전에 (한번) 시작한다. 한번만!

    // 속도, 방향
    [Header("이동")]
    public float moveSpeed = 5f;     // 캐릭터의 이동 속도
    public float JumpForce = 10f;
    private float moveInput;  // 플레이어의 방향 및 인폿 데이터 저장

    public Transform startTransform; // 캐릭터가 시작할 위치를 저장하는 변수
    public new Rigidbody2D rigidbody2D;  // 물리(강제) 기능을 제어하는 컴포넌트

    [Header("점프")]
    public bool isGrounded;          // true : 캐릭터가 점프 할 수 있는 상태, false : 점프 못함   
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
        // 현재 내 위치 <= 새로운 x,y 저장하는 데이터 타입(현재 x좌표, 10 y좌표)
        //transform.position = new Vector2(transform.position.x, 10);

        // 현재 내 위치를 startTransform으로 변경
        InitializePlayerStatus();

    }

    void InitializePlayerStatus()
    {
        transform.position = startTransform.position;
    }

    // Update is called once per frame
    // 1 프레임에 한번 호출된다. - 반복적으로 실행
    void Update()
    {
        HandleAnimation();
        CollisionCheck();
        HandleInput();
        HandleFlip();
        Move();
        FallDownCheck();
        // 점프를 할 때 땅인지 아닌지 체크 하는지 기능 -> Collider Check
        // 플레이어의 입력 값을 받아와야 한다.  a,d 키보드 좌 우 키를 눌렀을 때 -1 ~ 1 반환하는 클래스
        // 플레이어의 입력을 받아오는 코드


    }

    private void FallDownCheck()
    {
        // y의 높이가 특정 지점보다 낮을 때 낙사한 것으로 간주한다. -> 충돌 체크 대체
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
        // rigidbody.velocity : 현재 rigidbody 속도 = 0 움직이지 않는 상태, !=0 움직이고 있는 상태
        isMove = rigidbody2D.velocity.x != 0;
        animator.SetBool("isMove", isMove);
        animator.SetBool("isGrounded", isGrounded);
        // SetFloat 함수에 의해서 y최대일 때 1로 변환.. y
    }

    /// <summary>
    /// 플레이어 이동에 필요한 Bool 값을 제어하는 함수
    /// </summary>
    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
    }

    /// <summary>
    /// 유저의 입력을 관리하는 함수
    /// </summary>

    private void HandleInput()
    {
        moveInput = Input.GetAxis("Horizontal");

        JumpButton();
    }

    private void HandleFlip()
    {
        // 오른쪽 방향으로 바라보고 있을 때
        if (facingRight && moveInput < 0)
        {
            Flip();
        }
        // 왼쪽 방향으로 바라보고 있을 때
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
