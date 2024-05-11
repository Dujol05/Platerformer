using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerCam : MonoBehaviour
{
    // ������ �������� ����
    public Transform target;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // transform = ī�޶�, ������ ��, ���� -> A - B : B���� ����ؼ� A���� �̵��ϴ� ȭ��ǥ
        offset = transform.position - target.position;  // �÷��̾� ��ġ���� ī�޶� ��ġ������ ����
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        offset = transform.position - target.position;
    }
}
