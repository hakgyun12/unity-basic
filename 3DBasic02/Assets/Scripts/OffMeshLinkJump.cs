using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class OffMeshLinkJump : MonoBehaviour
{
    [SerializeField]
    private float jumpSpeed = 10.0f; //���� �ӵ�
    [SerializeField]
    private float gravity = -9.81f; //�߷� ���
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            //IsOnJump() �Լ��� ��ȯ ���� true�� ������ �ݺ� ȣ��
            yield return new WaitUntil(() => IsOnJump());

            // ���� �ൿ
            yield return StartCoroutine(JumpTo());
        }
    }

    public bool IsOnJump()
    {
        if (navMeshAgent.isOnOffMeshLink)
        {
            //���� ��ġ�� �ִ� OffMeshLink�� ������
            OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;

            // ���� OffMeshLinkType�� Manual=0, DropDown=1, JumpAcross=2��
            // �ڵ����� ������ OffMeshLink�� �Ӽ� ������ ���� ���(1, 2)

            // ���� ��ġ�� �ִ� OffMeshLnk�� OffMeshLinkType�� JumpAcross�̸�
            if (linkData.linkType == OffMeshLinkType.LinkTypeJumpAcross ||
                linkData.linkType == OffMeshLinkType.LinkTypeDropDown )
            {
                return true;
            }
        }

        return false;
    }

    IEnumerator JumpTo()
    {
        // �׺���̼��� �̿��� �̵��� ��� �����Ѵ�.
        navMeshAgent.isStopped = true;

        // ���� ��ġ�� �ִ� OffMeshLink�� ����/���� ��ġ
        OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;
        Vector3 start = transform.position;
        Vector3 end = linkData.endPos;

        // �پ �̵��ϴ� �ð� ����
        float jumpTime = Mathf.Max(0.3f, Vector3.Distance(start, end) / jumpSpeed);
        float currentTime = 0.0f;
        float percent = 0.0f;
        // y ������ �ʱ�ӵ�
        float v0 = (end - start).y - gravity;

        while (percent < 1)
        {
            // �ܼ��� deltaTime�� ���ϸ� ������ 1�� �Ŀ� percent�� 1�� �Ǳ� ������
            // jumpTime ������ �����ؼ� �ð��� �����Ѵ�.
            currentTime += Time.deltaTime;
            percent = currentTime / jumpTime;
            // �ð����( �ִ� 1)�� ���� ������Ʈ�� ��ġ(X, Z)�� �ٲ��ش�.
            Vector3 position = Vector3.Lerp(start, end, percent);
            // �ð� ����� ���� ������Ʈ�� ��ġ (y)�� �ٲ��ش�.
            // ������ � : ������ġ + �ʱ�ӵ� * �ð� + �߷� * �ð� ����
            position.y = start.y + (v0 * percent) + (gravity * percent * percent);
            // ������ ����� x, y, z ��ġ ���� ���� ������Ʈ�� ����
            transform.position = position;

            yield return null;
        }

        // OffMeshLink�� �̿��� �̵��Ϸ�
        navMeshAgent.CompleteOffMeshLink();
        // OffMeshLink �̵��� �Ϸ�Ǿ����� �׺���̼��� �̿��� �̵��� �ٽ� �����Ѵ�.
        navMeshAgent.isStopped = false;
    }
}
