using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "EnemySkill/testSkill")]
public class test : Skill
{
    public override void UseSkill()
    {
        Debug.Log("Skill �ߵ�");
        Debug.Log($"power = {this.Power}");
    }
}
