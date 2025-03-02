using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : EntityHealth
{
    [SerializeField] private Skill enemySkill;
    [SerializeField] private float enemyHealth = 100;
    private StolenSkill stolenSkill;
    public bool isHurt = false;
    public bool isStolen = false;
    private void Awake()
    {
        this.DeadCheck = false;
        this.Health = enemyHealth;
        this.MaxHealth = enemyHealth;
        stolenSkill = GetComponent<StolenSkill>();
    }
    public override void Damage(float power)
    {
        isHurt = true;
        Health -= power;
        if (currentHealth <= 0f && !DeadCheck)
        {
            Die();
        }
    }
    public override void Heal(float healing)
    {
        base.Heal(healing);
    }

    protected override void Die()
    {
        base.Die();
        if (gameObject.name != "Boss")
        {
            if (GameManager.instance.IsStealUse)
            {
                isStolen = true;
                for (int j = 0; j < GameManager.instance.SkillList.Count; j++)
                {
                    var skill = GameManager.instance.SkillList[j];
                    if (skill.skill == enemySkill)
                    {
                        GameManager.instance.SetIncreaseSkill = j;
                    }
                }

            }
            else
            {
                EnemyDestroy();
            }
        }
    }
    public void EnemyDestroy()
    {
        Destroy(gameObject, 6);
    }

}
