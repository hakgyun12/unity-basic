using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target; //ī�޶� �����ϴ� ���
    [SerializeField]
    private float minDistance = 3; // ī�޶�� target�� �ּҰŸ�
    [SerializeField]
    private float maxDistance = 30; // ī�޶�� target�� �ִ� �Ÿ�
    [SerializeField]
    private float wheelSpeed = 500; // ���콺 �� ��ũ�� �ӵ�
    [SerializeField]
    private float xMoveSpeed = 500; // ī�޶� y�� ȸ�� �ӵ�
    [SerializeField]
    private float yMoveSpeed = 250; // ī�޶��� x�� ȸ�� �ӵ�
    private float yMinLimit = 5; //ī�޶� x�� ȸ�� ���� �ּ� ��
    private float yMaxLimit = 80; //ī�޶� x�� ȸ�� ���� �ִ� ��
    private float x, y; //���콺 �̵� ���� ��
    private float distance; //ī�޶�� target�� �Ÿ�

    private void Awake()
    {
        // ���� ������ target�� ī�޶��� ��ġ�� �������� distance �� �ʱ�ȭ
        distance = Vector3.Distance(transform.position, target.position);
        // ���� ī�޶��� ȸ�� ���� x, y ������ ����
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    private void Update()
    {
        if (target == null) return; // target�� �������� ������ ���� ���� �ʴ´�.

        // ������ ���콺�� ������ ���� ��
        if (Input.GetMouseButton(1))
        {
            //���콺�� x, y�� ������ ���� ����
            x += Input.GetAxis("Mouse X") * xMoveSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * yMoveSpeed * Time.deltaTime;
            // ������Ʈ�� ��/�Ʒ� (x��) �Ѱ� ���� ����
            y = ClampAngle(y, yMinLimit, yMaxLimit);
            // ī�޶��� ȸ��(Rotation) ���� ����
            transform.rotation = Quaternion.Euler(y, x, 0);
        }

        // ���콺 �� ��ũ���� �̿��� target�� ī�޶��� �Ÿ��� (distance) ����
        distance -= Input.GetAxis("Mouse ScrollWheel") * wheelSpeed * Time.deltaTime;
        // �Ÿ��� �ּ�, �ִ� �Ÿ��� �����ؼ� �� ���� ����� �ʵ��� �Ѵ�.
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }

    private void LateUpdate()
    {
        if (target == null) return; //target�� �������� ������ ���� ���� �ʴ´�.

        // ī�޶��� ��ġ(Position) ���� ����
        // target�� ��ġ�� �������� distacne��ŭ �������� �Ѿư���
        transform.position = transform.rotation * new Vector3(0, 0, -distance) + target.position;
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}