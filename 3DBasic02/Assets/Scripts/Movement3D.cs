using System.Collections;
using UnityEngine;
using UnityEngine.AI;
// NavMeshAgent�� ���� ����Ƽ���� ���� �ΰ������� �̿��ϱ� ���ؼ� UnityEngine.AI�� �ʿ��ϴ�

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 goalPosition)
    {
        // ������ �̵� �ൿ�� �ϰ� �־��ٸ� �ڷ�ƾ ����
        StopCoroutine("OnMove");
        // �̵� �ӵ� ����
        navMeshAgent.speed = moveSpeed;
        // position�� ��ǥ�������� ���� (��ǥ������ ��� ��� �� �˾Ƽ� �����δ�)
        navMeshAgent.SetDestination(goalPosition);
        // �̵� �ൿ�� ���� �ڷ�ƾ ����
        StartCoroutine("OnMove");
    }

    IEnumerator OnMove()
    {
        while(true)
        {
            // ��ǥ ��ġ(navMeshAgent.destination)�� �� ��ġ(transform.position)�� �Ÿ��� 0.1�̸��� ��
            // ��, ��ǥ ��ġ�� ���� �������� ��
            if(Vector3.Distance(navMeshAgent.destination, transform.position) < 0.1f )
            {
                // �� ��ġ�� ��ǥ ��ġ�� ����
                transform.position = navMeshAgent.destination;
                // SetDestination()�� ���� ������ ��θ� �ʱ�ȭ, �̵��� �����.
                navMeshAgent.ResetPath();

                break;
            }

            yield return null;
        }
    }
}
