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

    // Debug.Log(���� ���¸� ����غ��� �ڵ� �ۼ�)
    // Tge�� ����ؼ� Player�� �ۼ��� �� �ֵ��� �ۼ��ϱ�

    public bool isStayOn = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && isStayOn)
        {
            isGasState = true;
            Debug.Log($"���� ������ ���Խ��ϴ�.  {isGasState}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isGasState = false;
            Debug.Log($"���� �ȿ��� �������Խ��ϴ�. {isGasState} ");
        }
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= checkTime)
        {
            Timer = 0;
            PlayerHP = PlayerHP - Damage;
            Debug.Log($"������ ���̴� �� {PlayerHP}");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("������ ���� �������� �ް� �ֽ��ϴ�.");
            PlayerHP = PlayerHP - Damage;
        }
    }
}
