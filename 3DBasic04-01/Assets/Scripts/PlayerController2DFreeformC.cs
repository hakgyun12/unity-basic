using UnityEngine;

public class PlayerController2DFreeformC : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // ��, �� ����Ű �Է�
        float vertical = Input.GetAxis("Vertical"); // ��, �Ʒ� ����Ű �Է�

        // horizontal ���� ���� �ִϸ��̼� ��� (-1:���� , 0: ���, 1: ������)
        animator.SetFloat("Horizontal", horizontal);
        // vertical ���� ���� �ִϸ��̼� ��� (0:���, 1:��)
        animator.SetFloat("Vertical", vertical);
    }
}
