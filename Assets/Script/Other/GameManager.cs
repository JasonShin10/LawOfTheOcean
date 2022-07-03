using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�� ��ų �ε��� ������ ���� �ʿ��Ұ� ����.
    //�� ���� ��ų�� copy���� ����� �� PlayerSkillCopy���� ��� ����� �� ������?

    private int enemySkillNum;
    public static GameManager instance = new GameManager();
    private GameManager(){ }
    public static GameManager getGameManager()
    {
        return instance;
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
