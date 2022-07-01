using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySkill : MonoBehaviour
{
    //ScriptableObject�� ���� ��ų�� ��ų �ߵ��� Ȯ�� �ֱ�
    [SerializeField] private List<Skill> skills;
    //�� ��ų�� Ȯ������ �� ���κ��� �ִ� ����Ʈ
    private List<float> perList = new List<float>();
    //CallSkill �ڷ�ƾ�� ����Ǳ� ���� �ο� �÷���
    private bool isCallingComplete = true;
    //error���� �� ��Ÿ���� �ο� �÷���
    private bool isError = false;
    private int mid;

    private void Start()
    {
        //�� ��ų�� Ȯ�� ���� �� ������ ����Ʈ�� �ֱ�
        float per = 0;
        foreach(var skill in skills)
        {
            per += skill.Percentage;
            perList.Add(per);
        }
        //��� Ȯ���� �ۼ�Ʈ�� 100�� �ƴ� ��, ����â 
        if (per != 100)
        {
            Debug.LogError("�ۼ�Ʈ�� 100���� �����ּ���.");
            isError = true;
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
        float randomNum = Random.Range(1, 101);

        isCallingComplete = false;

        //��� ������ �ش�Ǵ� ��ų���� �˰� �ʹ�.
        int left = 0;
        int right = perList.Count - 1;
        mid = (left + right) / 2;
        while (mid >= right)
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
        //�� �ش�Ǵ� ��ų�� ����ϰ� �ʹ�.
        skills[mid].UseSkill();
        yield return new WaitForSeconds(5);

        isCallingComplete = true;
    }
}
