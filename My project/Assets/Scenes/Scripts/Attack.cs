using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Hero
{
    public GameObject attackTrigger; // ������� ��� �����
    private Animator anim; // �������� ���������

    private void Awake()
    {
        anim = GetComponent<Animator>(); // �������� �������� ���������
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ���� ������ ������� ������
        {
            AttackTrigger(); // �������� ����� �����
        }
    }

    private void AttackTrigger()
    {
        anim.SetTrigger("attack"); // ������������� ������� �������� �����
        attackTrigger.SetActive(true); // �������� �������
        Invoke("DisableAttackTrigger", 0.5f); // ��������� ������� ����� 0.5 �������
    }

    private void DisableAttackTrigger()
    {
        attackTrigger.SetActive(false); // ��������� �������
    }
}
