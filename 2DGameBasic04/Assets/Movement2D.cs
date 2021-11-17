using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f; //�̵��ӵ�
    [SerializeField]
    private float jumpForce = 8.0f; //���� �� (Ŭ���� ���� ����)
    private Rigidbody2D rigid2D;
    [HideInInspector]
    public bool isLongJump = false;

    [SerializeField]
    private LayerMask groundLayer; // �ٴ� üũ�� ���� �浹 ���̾�
    private CapsuleCollider2D capsuleCollider2D; // ������Ʈ�� �浹 ���� ������Ʈ
    private bool isGrounded; // �ٴ� üũ (�ٴڿ� ��� ���� �� true)
    private Vector3 footPosition; // ���� ��ġ

    [SerializeField]
    private int maxJumpCount = 2; // ���� ��� ������ �� �� �ִ� �ִ� ���� Ƚ��
    private int currentJumpCount = 0; // ���� ������ ���� Ƚ��

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        //�÷��̾� ������Ʈ�� Collider2D min, center, max ��ġ ����
        Bounds bounds = capsuleCollider2D.bounds;
        // �÷��̾��� �� ��ġ ����
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        // �÷��̾��� �� ��ġ�� ���� �����ϰ�, ���� �ٴڰ� ��������� isGrounded = true
        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        // �÷��̾��� ���� ���� ��� �ְ�, y�� �ӵ��� 0�����̸� ���� Ƚ�� �ʱ�ȭ
        // velocity.y <= 0�� �߰����� ������ ����Ű�� ������ �������� �ʱ�ȭ�� �Ǿ�
        // �ִ� ���� Ƚ���� 2�� �����ϸ� 3������ ������ �����ϰ� �ȴ�.
        if (isGrounded == true && rigid2D.velocity.y <= 0)
        {
            currentJumpCount = maxJumpCount;
        }

        // ���� ����, ���� ���� ������ ���� �߷� ���(gravityScale) ���� (Jump Up�� ���� ����)
        // �߷� ����� ���� if ���� ���� ������ �ǰ�, �߷� ����� ���� else ���� ���� ������ �ȴ�.
        if( isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = 1.0f;
        }
        else
        {
            rigid2D.gravityScale = 2.5f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footPosition, 0.1f);
    }

    public void Move(float x)
    {
        //x�� �̵��� x * speed��, y�� �̵��� ������ �ӷ� ��(����� �߷�)
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if (isGrounded == true)
        {
            // jumpForce�� ũ�⸸ŭ ���� �������� �ӷ� ������
            rigid2D.velocity = Vector2.up * jumpForce;
            // ���� Ƚ�� 1����
            currentJumpCount--;
        }
    }
}
