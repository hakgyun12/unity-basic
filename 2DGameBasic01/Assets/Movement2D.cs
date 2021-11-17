using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f;                 //이동 속도
    // 1. 컴포넌트와 동일한 타입의 변수 생성
    private Rigidbody2D rigid2D;

    private void Awake()
    {   
        //2. 컴포넌트 정보를 얻어와서 변수에 저장
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Negative left, a : -1
        // Positive right, d : 1
        // None : 0
        float x = Input.GetAxisRaw("Horizontal");   //좌우 이동
        // Negative down, s : -1
        // Positive up, w : 1
        // None : 0
        float y = Input.GetAxisRaw("Vertical");     //위아래 이동

        //이동 방향 설정
        //moveDirection = new Vector3(x, y, 0);

        //새로운 위치 = 현재 위치 + (방향 * 속도)
        //transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //Rigidbody2D 컴포넌트에 있는 속력(velocity) 변수 설정
        // 컴포넌트 정보가 저장된 변수를 사용
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;
    }
}
