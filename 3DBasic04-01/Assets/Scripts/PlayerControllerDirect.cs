using UnityEngine;
using System.Collections;

public class PlayerControllerDirect : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        KeyEvent(0, KeyCode.Q, "angry"); // QŰ�� ������ angry �Ķ���� �� ����
        KeyEvent(1, KeyCode.A, "angry"); // AŰ�� ������ angry �Ķ���� �� ����

        KeyEvent(0, KeyCode.W, "eye"); // WŰ�� ������ eye �Ķ���� �� ����
        KeyEvent(1, KeyCode.S, "eye"); // SŰ�� ������ eye �Ķ���� �� ����

        KeyEvent(0, KeyCode.E, "sap"); // EŰ�� ������ sap �Ķ���� �� ����
        KeyEvent(1, KeyCode.D, "sap"); // DŰ�� ������ sap �Ķ���� �� ����

        KeyEvent(0, KeyCode.R, "smile"); // RŰ�� ������ smile �Ķ���� �� ����
        KeyEvent(1, KeyCode.F, "smile"); // FŰ�� ������ smile �Ķ���� �� ����
    }

    private void KeyEvent(int type, KeyCode key, string parameter)
    {
        // key Ű�� ������ ��Ÿ���� �� ����/���� ����
        if (Input.GetKeyDown(key) )
        {
            string coroutine = type == 0 ? "ParameterUp" : "ParameterDown";
            StartCoroutine(coroutine, parameter);
        }

        // key Ű�� ���� ��Ÿ���� �� ����/���� ����
        else if ( Input.GetKeyUp(key) )
        {
            string coroutine = type == 0 ? "ParameterUp" : "ParameterDown";
            StopCoroutine(coroutine);
        }
    }

    private IEnumerator ParameterUp(string parameter)
    {
        // ���� �Ķ���� ���� �޾ƿ´�
        float percent = animator.GetFloat(parameter);

        // �Ķ���� ���� ������Ű�� �ڷ�ƾ�̱� ������ 1�� �ɶ����� ����
        while (percent < 1)
        {
            percent += Time.deltaTime; // percent �� ����
            animator.SetFloat(parameter, percent);

            yield return null;
        }
    }

    private IEnumerator ParameterDown(string parameter)
    {
        // ���� �Ķ���� ���� �޾ƿ´�.
        float percent = animator.GetFloat(parameter);

        // �Ķ���� ���� ���ҽ�Ű�� �ڷ�ƾ�̱� ������ 0�� �ɶ����� ����
        while (percent > 0)
        {
            percent -= Time.deltaTime; //percent �� ����
            animator.SetFloat(parameter, percent);

            yield return null;
        }
    }
}
