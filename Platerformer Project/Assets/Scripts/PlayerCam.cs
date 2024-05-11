using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerCam : MonoBehaviour
{
    // 백터의 연산으로 구현
    public Transform target;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // transform = 카메라, 백터의 합, 빼기 -> A - B : B에서 출발해서 A까지 이동하는 화살표
        offset = transform.position - target.position;  // 플레이어 위치에서 카메라 위치까지의 백터
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        offset = transform.position - target.position;
    }
}
