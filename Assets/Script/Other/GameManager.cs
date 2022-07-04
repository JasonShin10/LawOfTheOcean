using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = new GameManager();
    private GameManager() { }
    public static GameManager getGameManager()
    {
        return instance;
    }
    
    
    //copy�� �� �ִ� ��ų�� Max ��
    [SerializeField] private int skillMaxCnt = 10;

    [System.Serializable]
    public struct SkillInfo
    {
        public Skill skill;
        public int skillCnt;
    }
    //�� ��ų �ε���(����) ������ ���� �ʿ��Ұ� ����.
    //�� ���� ��ų�� copy���� ����� �� PlayerSkillCopy���� ��� ����� �� ������?
    [Header("Player�� copy�� Enemy Skill ����")]
    [SerializeField] private List<SkillInfo> skills = new List<SkillInfo>();

    /// <summary>
    /// skill�� ī�ǰ��� ������ ����ü�� ��� ����Ʈ ���·� ��ȯ�ϴ� �б� ���� ������Ƽ
    /// [�ε��� ����]
    /// 0. Test1
    /// 1. Test2
    /// </summary>
    public List<SkillInfo> SkillList
    {
        get { return skills; }
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
            skill.skillCnt = skill.skillCnt >= skillMaxCnt ? skillMaxCnt : skill.skillCnt + 1;
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
            skill.skillCnt = skill.skillCnt >= skillMaxCnt ? skillMaxCnt : skill.skillCnt - 1;
        }
    }
}
