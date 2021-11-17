using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomImage : MonoBehaviour
{
    // 임의의 위치에서 프로젝트 생성하기
    [SerializeField]
    private int objectSpawnCount = 30;
    [SerializeField]
    private GameObject[] prefabArray;

    private void Awake()
    {
        for (int i = 0; i < objectSpawnCount; ++i)
        {
            int index = Random.Range(0, prefabArray.Length);
            float x = Random.Range(-7.5f, 7.5f);
            float y = Random.Range(-4.5f, 4.5f);
            Vector3 position = new Vector3(x, y, 0);

            Instantiate(prefabArray[index], position, Quaternion.identity);
        }
    }
}
