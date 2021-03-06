using UnityEngine;

public class SimplePatrol : MonoBehaviour
{
    [SerializeField]
    private Transform[] paths; // 순찰 경로
    private int currentPath = 0; // 현재 목표지점 인덱스
    private float moveSpeed = 3.0f; // 이동 속도

    private void Update()
    {
        //이동 방향 설정: (목표위치-내위치). 정규화
        Vector3 direction = (paths[currentPath].position - transform.position).normalized;
        // 오브젝트 이동
        transform.position += direction * moveSpeed * Time.deltaTime;

        // 목표 위치에 거의 도달했을 때
        // Vector3.distance 보다 연산속도가 더 빠르다.
        if ( (paths[currentPath].position - transform.position).sqrMagnitude< 0.1f)
        {
            // 목표 위치 변경 (순찰 경로 순환)
            if (currentPath < paths.Length - 1) currentPath++;
            else currentPath = 0;
        }
    }
}
