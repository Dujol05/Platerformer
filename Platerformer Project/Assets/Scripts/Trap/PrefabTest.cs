using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        // ������ ������ , ������ ��ġ (Vector), ������Ʈ�� Rotation

        Instantiate(prefab); // prefabd�� ��ġ�� �⺻ ��ġ, ȸ�� ������ �����ȴ�.
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            spawnPosition;
        }
    }
}
