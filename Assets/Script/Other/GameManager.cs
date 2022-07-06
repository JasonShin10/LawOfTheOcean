using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private GameManager() {

        instance = this;
    }
    public static GameManager getGameManager()
    {
        return instance;
    }
    
    //copy�� �� �ִ� ��ų�� Max ��
    [SerializeField] private int skillMaxCnt = 10;
    //���� ��ų ����
    [SerializeField] private int currentSkillCnt;

    [System.Serializable]
    public struct SkillInfo
    {
        public Skill skill;
        public int skillCnt;
    }
    //�� ��ų �ε���(����) ������ ���� �ʿ��Ұ� ����.
    //�� ���� ��ų�� copy���� ����� �� PlayerSkillCopy���� ��� ����� �� ������?
    [Header("Player�� copy�� Enemy Skill ����")]
    [SerializeField] private List<SkillInfo> skills;

    
    /// <summary>
    /// skill�� ī�ǰ��� ������ ����ü�� ��� ����Ʈ ���·� ��ȯ�ϴ� �б� ���� ������Ƽ
    /// [�ε��� ����]
    /// 0. Test1
    /// 1. Test2
    /// </summary>
    private void Start()
    {
        GameManager.instance.IsStealUse = false;
        
        int cnt = 0;
        foreach(var skill in skills)
        {
            cnt += skill.skillCnt;
        }
        if(cnt > skillMaxCnt)
        {
            Debug.LogError("��ų ���� Max���� �����ϴ�!!");
        }
        else
        {
            currentSkillCnt = cnt;
        }
    }
    /// <summary>
    /// ��ų�� �� ��ų�� ���� ������ ��Ƴ� skillList �б� ���� ������Ƽ 
    /// </summary>
    public List<SkillInfo> SkillList
    {
        get { return skills; }
        set { skills = value; }
        
    }

    /// <summary>
    /// �ε����� �־� ��ų�� ������Ű�� ���� ���� ������Ƽ 
    /// [�ε��� ����]
    /// 0. Test1
    /// 1. Test2
    /// </summary>
    public int SetIncreaseSkill
    {
        set
        {
            SkillInfo skill = skills[value];
            if(currentSkillCnt + 1 <= skillMaxCnt)
            {
                skill.skillCnt++;
                skills[value] = skill;
                currentSkillCnt++;
            }
        }
    }

    /// <summary>
    /// �ε����� �־� ��ų�� ���ҽ�Ű�� ���� ���� ������Ƽ
    /// [�ε��� ����]
    /// 0. Test1
    /// 1. Test2
    /// </summary>
    public int SetDecreaseSkill
    {
        set
        {
            SkillInfo skill = skills[value];
            if (currentSkillCnt - 1 >= 0)
            {
                skill.skillCnt--;
                skills[value] = skill;
                currentSkillCnt--;
            }
        }
    }

    //��ų�� ����ߴ°�
    public bool IsStealUse { get; set; }

    public bool IsStopAttack { get; set; }

}
