using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;
    [SerializeField]
    private Transform cameraTransform;
    private Movement3D movement3D;
    private PlayerAnimator playerAnimator;

    private void Awake()
    {
        Cursor.visible = false; // ���콺 Ŀ���� ������ �ʰ�
        Cursor.lockState = CursorLockMode.Locked; // ���콺 Ŀ�� ��ġ ����

        movement3D = GetComponent<Movement3D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    private void Update()
    {
        // ����Ű�� ���� �̵�
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // �ִϸ��̼� �Ķ���� ���� (horizontal, vertical)
        playerAnimator.OnMovement(x, z);
        // �̵� �ӵ� ���� (������ �̵��Ҷ��� 5, �������� 2)
        movement3D.MoveSpeed = z > 0 ? 5.0f : 2.0f;
        // �̵� �Լ� ȣ�� (ī�޶� ���� �ִ� ������ �������� ����Ű�� ���� �̵�)
        movement3D.MoveTo(cameraTransform.rotation * new Vector3(x, 0, z));

        // ȸ�� ���� (�׻� �ո� ������ ĳ���� ȸ���� ī�޶�� ���� ȸ�� ������ ����)
        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

        // Space Ű�� ������ ����
        if (Input.GetKeyDown(jumpKeyCode))
        {
            playerAnimator.OnJump(); // �ִϸ��̼� �Ķ���� ���� (onJump)
            movement3D.JumpTo(); // ���� �Լ� ȣ��
        }
    }
}
