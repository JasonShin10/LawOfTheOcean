using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySkill : MonoBehaviour
{

    [Serializable]
    //��ų�� ������ ���� ����ü ����
    public struct SkillSystem
    {
        public Skill skill;
        public float percent;
    }

    [Header("��ų")]
    public List<SkillSystem> skills;
    //�� ��ų�� Ȯ������ �� ���κ��� �ִ� ����Ʈ
    private List<float> perList = new List<float>();
    //CallSkill �ڷ�ƾ�� ����Ǳ� ���� �ο� �÷���
    private bool isCallingComplete = true;
    //error���� �� ��Ÿ���� �ο� �÷���
    private bool isError = false;

    private int mid;
    //ScriptableObject�� ���� ��ų�� ��ų �ߵ��� Ȯ�� �ֱ�
    private void Start()
    {
        float per = 0;
        foreach (var skill in skills)
        {
            per += skill.percent;
            perList.Add(per);
        }
        if (per != 1)
        {
            Debug.LogError("�ۼ�Ʈ�� ���� 1�� �Ǿ���մϴ�.");
        }
    }
    private void Update()
    {
        //Callskill�� �ѹ��� ��ų �ߵ� �� ���� �ʹ�.
        if (isCallingComplete && !isError)
        {
            StartCoroutine("CallSkill");
        }
    }
    private IEnumerator CallSkill()
    {
        //���� �� ���
        float randomNum = Random.Range(0.0f, 1.0f);
        isCallingComplete = false;

        //��� ������ �ش�Ǵ� ��ų���� �˰� �ʹ�.
        int left = 0;
        int right = perList.Count - 1;
        mid = (left + right) / 2;
        while (mid < right)
        {
            if (perList[mid] <= randomNum)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
            mid = (left + right) / 2;
            yield return null;
        }
        //User���� ���
        skills[mid].skill.User = gameObject;
        //�� �ش�Ǵ� ��ų�� ����ϰ� �ʹ�.
        skills[mid].skill.UseSkill();
        //�� �ش�Ǵ� ��ų�� ��Ÿ�Ӹ�ŭ ��ٸ���.
        yield return new WaitForSeconds(skills[mid].skill.CoolTime);

        isCallingComplete = true;
    }
}
