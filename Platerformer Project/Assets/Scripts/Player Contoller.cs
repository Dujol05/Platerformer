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
    public Rigidbody2D rigidbody2D;  // ����(����) ����� �����ϴ� ������Ʈ

    [Header("����")]
    public bool isGrounded;          // true : ĳ���Ͱ� ���� �� �� �ִ� ����, false : ���� ����   
    public float groundDistance = 2f;
    public LayerMask groundDistanc;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        Debug.Log("Hello Unity");
        // ���� �� ��ġ <= ���ο� x,y �����ϴ� ������ Ÿ��(���� x��ǥ, 10 y��ǥ)
        //transform.position = new Vector2(transform.position.x, 10);

        // ���� �� ��ġ�� startTransform���� ����
        transform.position = startTransform.position;

    }

    // Update is called once per frame
    // 1 �����ӿ� �ѹ� ȣ��ȴ�. - �ݺ������� ����
    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 2, groundDistanc);

        // �÷��̾��� �Է� ���� �޾ƿ;� �Ѵ�.

        moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(moveSpeed * moveInput, rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            // ���� : Y Position _ rigidbody Y velocity�� ���� �Ŀ���ŭ �÷��ָ�ȴ�.
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);  
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));
    }
}
