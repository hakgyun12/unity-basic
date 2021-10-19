using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    //private float walkSpeed = 4.0f;
    //private float runSpeed = 8.0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical"); //��, �Ʒ� ����Ű �Է�
        // ShiftŰ�� �ȴ����� �ִ� 0.5 ShiftŰ�� ������ �ִ� 1���� ���� �ٲ�� �ȴ�.
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;
        // ������ ����Ű�� ������ forward�� +������ ���ʹ���Ű�� ������ forward�� -�̱� ������
        // �ִϸ��̼� �Ķ���͸� ������ �� ���밪���� �����Ѵ�
        float moveParameter = Mathf.Abs(vertical * offset);

        // moveParameter ���� ���� �ִϸ��̼� ��� (0:���, 0.5: �ȱ�, 1: �ٱ�)
        animator.SetFloat("moveSpeed", moveParameter);

        // �̵��ӵ� : ShiftŰ�� �ȴ����� �� walkSpeed, ShiftŰ�� ������ �� runSpeed���� moveSpeed�� ����
        // float moveSpeed = Mathf.Lerp(walkSpeed, runSpeed, Input.GetAxis("Sprint"));
        // ���� �̵�
        // transform.position += new Vector3(vertical, 0, 0) * moveSpeed * Time.deltaTime;
    }
}
