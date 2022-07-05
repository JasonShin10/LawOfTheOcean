using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [Header("��ų �Ӽ�")]
    [SerializeField] private float power;
    [SerializeField] private float cooltime;
    private GameObject user;


    /// <summary>
    /// ��ų ��Ÿ�� ������Ƽ
    /// </summary>
    public float CoolTime { get { return cooltime; } set { cooltime = value; } }
    /// <summary>
    /// ��ų ������
    /// </summary>
    public float Power { get { return power; } set { power = value; } }

    /// <summary>
    /// ���� ���� ������Ƽ EnemySkill���� ����� ������Ʈ �ڵ� ����
    /// </summary>
    public GameObject User { get { return user; } set { user = value; } }
    public abstract void UseSkill();
}
