using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f;                 //�̵� �ӵ�
    // 1. ������Ʈ�� ������ Ÿ���� ���� ����
    private Rigidbody2D rigid2D;

    private void Awake()
    {   
        //2. ������Ʈ ������ ���ͼ� ������ ����
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Negative left, a : -1
        // Positive right, d : 1
        // None : 0
        float x = Input.GetAxisRaw("Horizontal");   //�¿� �̵�
        // Negative down, s : -1
        // Positive up, w : 1
        // None : 0
        float y = Input.GetAxisRaw("Vertical");     //���Ʒ� �̵�

        //�̵� ���� ����
        //moveDirection = new Vector3(x, y, 0);

        //���ο� ��ġ = ���� ��ġ + (���� * �ӵ�)
        //transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //Rigidbody2D ������Ʈ�� �ִ� �ӷ�(velocity) ���� ����
        // ������Ʈ ������ ����� ������ ���
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;
    }
}
