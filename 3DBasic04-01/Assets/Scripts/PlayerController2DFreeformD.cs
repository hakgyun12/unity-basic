using UnityEngine;

public class PlayerController2DFreeformD : MonoBehaviour
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
        float horizontal = Input.GetAxis("Horizontal"); //��, �� ����Ű �Է�
        float vertical = Input.GetAxis("Vertical"); // ��, �Ʒ� ����Ű �Է�
        // Shift Ű�� �ȴ����� �ִ� 0.5, ShiftŰ�� ������ �ִ� 1���� ���� �ٲ�� �ȴ�.
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

        // horizontal ���� ���� �ִϸ��̼� ��� (-1:����, 0: ���, 1: ������)
        animator.SetFloat("Horizontal", horizontal * offset);
        // vertical ���� ���� �ִϸ��̼� ��� (-1:��, 0: ���, 1: ��)
        animator.SetFloat("Vertical", vertical * offset);

        // �̵��ӵ� : shiftŰ�� �ȴ����� ��, walkSpeed, ShiftŰ�� ������ �� runSpeed ���� moveSpeed�� ����
        // float moveSpeed = Mathf.Lerp(walkSpeed, runSpeed, Input.GetAxis("Sprint"));
        // ���� �̵�
        // transform.position += new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
    }
}
