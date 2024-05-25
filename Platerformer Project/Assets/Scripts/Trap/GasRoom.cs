using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasRoom : MonoBehaviour
{
    private bool isGasState = false;

    public float checkTime = 2f;
    public float Timer = 0;
    private int PlayerHP = 100;
    private int Damage = 0;

    // Debug.Log(현재 상태를 출력해보는 코드 작성)
    // Tge를 사용해서 Player만 작성할 수 있도록 작성하기

    public bool isStayOn = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && isStayOn)
        {
            isGasState = true;
            Debug.Log($"가스 안으로 들어왔습니다.  {isGasState}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isGasState = false;
            Debug.Log($"가스 안에서 빠져나왔습니다. {isGasState} ");
        }
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= checkTime)
        {
            Timer = 0;
            PlayerHP = PlayerHP - Damage;
            Debug.Log($"데미지 깎이는 중 {PlayerHP}");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("가스로 인해 데미지를 받고 있습니다.");
            PlayerHP = PlayerHP - Damage;
        }
    }
}
