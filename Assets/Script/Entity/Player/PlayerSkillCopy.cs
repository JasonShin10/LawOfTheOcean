using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//copy�� ��ų ���
public class PlayerSkillCopy : MonoBehaviour
{
    [SerializeField] private int curIndex = 0;
    // UI�� tab������ ��ų swap ����
    // UI�� � ��ų���� ��Ÿ������ ��� �ؾ��ұ�
    // 1. Dictionary ���·� �ش� key(�Ƹ� skillInfo�� index)�� value(skill�̸�)�� UI�̸��� �Ȱ���? �ؼ� setActive�ؾ��ұ�
    //      -> find ��� (���� ����) ���� �ش� UI�� �˾Ƴ� �� �ִ� �ٸ� ����� ������ 
    // 2. �ƿ� �����ִ� ������� �ұ� (�����ڰ� �� ���� ������)
    // 3. UIManager���� ���� ���� -> �̰� ���� ������� ������..?
    //      -> UIManager�� �ش� �ε��� ���� �� UIManager���� �ش� UI�� setActive


    private void Update()
    {
        if (Input.GetButtonDown("Swap"))
        {
            if(curIndex == GameManager.instance.SkillList.Count - 1)
            {
                curIndex = 0;
            }
            else
            {
                curIndex++;
            }
            
        }
        if (Input.GetButtonDown("Use Skill"))
        {
            //���߿��� ��ų ������ ���
            //GameManager.instance.SkillList[curIndex].skill.UseSkill();
            
            //��ų�� enemy�� �׿��� �� Ȯ�������� ���
        }
    }


}
