using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowFish : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private BlowFishSkill skill;

    private Animation animation;
    private EnemyDetection detection;
    private EnemyHealth health;
    private Vector3 dir;
    private State curState;
    private State preState;
    private float curTime = 0;
    private float hurtAnimTime = 2f;
    private float hurtCurTime = 0;

    enum State
    {
        MOVE,
        FOLLOW,
        ATTACK,
        HURT,
        DIE
    }
    
    //To do 
    //�ִϸ��̼� �ֱ�


    private void Start()
    {
        skill.User = gameObject;
        curState = State.MOVE;
        preState = State.MOVE;
        detection = GetComponent<EnemyDetection>();
        animation = GetComponent<Animation>();
        health = GetComponent<EnemyHealth>();
        dir = Vector3.forward;
    }
    private void Update()
    {
        if (curState == State.MOVE)
        {
            Move();
        }
        if (curState == State.FOLLOW)
        {
            Follow();
        }
        if (curState == State.ATTACK)
        {
            Attack();
        }
        if (curState == State.HURT)
        {
            Hurt();
        }
        if(curState == State.DIE)
        {
            Die();
        }
        if (health.DeadCheck)
            curState = State.DIE;
    }
    private void Move()
    {

        //animation.clip = animation.GetClip("walk");
        
        //Move �ִϸ��̼� ����
        if (detection.Target)
        {
            curState = State.FOLLOW;
        }
        else
        {
            Debug.Log("Move ����");
            dir = Vector3.forward;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, turnSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position += dir.normalized * speed * Time.deltaTime;
        }
        if (health.isHurt)
        {
            curState = State.HURT;
            preState = State.MOVE;
        }
    }
    private void Attack()
    {
        //��Ǯ���� �ִϸ��̼� ����
        Debug.Log("Attack ����");
        curTime += Time.deltaTime;
        if (curTime >= skill.CoolTime)
        {
            skill.UseSkill();
            curTime = 0;
        }
        if (health.isHurt)
        {
            curState = State.HURT;
            preState = State.ATTACK;
        }
    }
    private void Follow()
    {
        //Move �ִϸ��̼� ����
        if (!detection.Target)
        {
            curState = State.MOVE;
        }
        else
        {
            Debug.Log("Follow ����");
            dir = detection.Target.transform.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, turnSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position += dir.normalized * speed * Time.deltaTime;
        }
        if (health.isHurt)
        {
            curState = State.HURT;
            preState = State.FOLLOW;
        }
    }
    private void Hurt()
    {
        //��ġ�� �ִϸ��̼� ����
        Debug.Log("Hurt ����");

        hurtCurTime += Time.deltaTime;
        if (hurtCurTime >= hurtAnimTime)
        {
            curState = preState;
        }
    }
    private void Die()
    {
        //���� �ִϸ��̼� ����
    }
}
