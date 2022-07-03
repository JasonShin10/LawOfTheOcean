using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    private struct EnemySkillInfo
    {
        public Skill skillName;
        public int skillCnt;
    }
    Dictionary<string, int> skillInfo = new Dictionary<string, int>();
    //�� ��ų �ε���(����) ������ ���� �ʿ��Ұ� ����.
    //�� ���� ��ų�� copy���� ����� �� PlayerSkillCopy���� ��� ����� �� ������?
    [Header("Player�� copy�� Enemy Skill ����")]
    [SerializeField] private List<EnemySkillInfo> enemySkillInfos = new List<EnemySkillInfo>();

    private int enemySkillNum;
    public static GameManager instance = new GameManager();
    private GameManager() { }
    public static GameManager getGameManager()
    {
        return instance;
    }
    public Dictionary<string,int> SkillProp
    {
        set
        {

        }
    }
    //�� ��ų ����
    public int EnemySkillNum
    {
        get
        {
            return enemySkillNum;
        }
        set
        {
            enemySkillNum = value < 0 ? 0 : value;
            
        }
    }
}
