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
        // 생성할 프리팹 , 생성할 위치 (Vector), 오브젝트의 Rotation

        Instantiate(prefab); // prefabd의 위치는 기본 위치, 회전 값으로 생성된다.
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
