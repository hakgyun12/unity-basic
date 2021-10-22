using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5; //�̵� �ӵ�
    [SerializeField]
    private float gravity = -9.81f; //�߷� ���
    [SerializeField]
    private float jumpForce = 3.0f; //�پ� ������ ��
    private Vector3 moveDirection; //�̵� ����

    private CharacterController characterController;

    public float MoveSpeed
    {
        // �̵��ӵ��� 2~5 ������ ���� ��������
        set => moveSpeed = Mathf.Clamp(value, 2.0f, 5.0f);
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    { 
        // �߷� ����, �÷��̾ ���� ��� ���� �ʴٸ�
        // y�� �̵����⿡ gravity * Time.deltaTime�� �����ش�
        if (characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }
        // �̵� ����. CharacterController�� Move() �Լ��� �̿��� �̵�
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }

    public void JumpTo()
    {
        //ĳ���Ͱ� �ٴ��� ��� ������ ����
        if(characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }
}