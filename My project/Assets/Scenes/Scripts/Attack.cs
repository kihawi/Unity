using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Hero
{
    public GameObject attackTrigger; // Триггер для атаки
    private Animator anim; // Аниматор персонажа

    private void Awake()
    {
        anim = GetComponent<Animator>(); // Получаем аниматор персонажа
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Если нажата клавиша пробел
        {
            AttackTrigger(); // Вызываем метод атаки
        }
    }

    private void AttackTrigger()
    {
        anim.SetTrigger("attack"); // Устанавливаем триггер анимации атаки
        attackTrigger.SetActive(true); // Включаем триггер
        Invoke("DisableAttackTrigger", 0.5f); // Выключаем триггер через 0.5 секунды
    }

    private void DisableAttackTrigger()
    {
        attackTrigger.SetActive(false); // Выключаем триггер
    }
}
