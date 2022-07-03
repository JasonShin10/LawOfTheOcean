using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillCopy : MonoBehaviour
{


    [System.Serializable]
    private struct SkillInfo
    {
        public Skill enemySkill;
        public int skillCnt;
    }
    [Header("��� ���� ��ų ����")]
    [SerializeField] private List<SkillInfo> skillList = new List<SkillInfo>();
}
