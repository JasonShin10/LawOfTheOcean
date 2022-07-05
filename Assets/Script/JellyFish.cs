using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour
{
    // ���ĸ�
    // �÷��̾ ���ĸ��� ���������� ������
    // �÷��̾�� ���� �ٰ��µ�

    // �÷��̾ �Ѿƿ��� ���Ÿ� �������Ѵ�.
    // �����Ҷ� �÷��̾��� hp�� �ް��ϰ�
    // ����ȿ���� �ش�
    // �÷��̾ ������ �����
    // �ٽ� ���ڸ��� ���ư���.

    // FSM���� ���¸� �����ϰ�ʹ�.
    public enum State
    {
        Idle,
        Move,
        Attack,
        Return
    }

    public State state;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;

        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Idle)
        {
            UpdateIdle();
        }
        else if (state == State.Move)
        {
            UpdateMove();
        }
        else if (state == State.Attack)
        {
            UpdateAttack();
        }
    }
    public float detect = 15;
    
    private void UpdateIdle()
    {
        Vector3 dir = Vector3.forward;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
      
        float distance = Vector3.Distance(target.transform.position, transform.position);

        // ���� �÷��̾���� �Ÿ��� �����Ÿ����� ������
        if (detect > distance)
        {
            state = State.Move;
        }
        // Move���·� �����Ѵ�.
    }
    public float speed = 3;
    public float attackDistance = 5;

   

    float currentTime;
    [SerializeField] private float createTime = 2;   
    private void UpdateAttack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        // 1. �ð��� �帣�ٰ�  
        currentTime += Time.deltaTime;
        // 2. �����ð��� �Ǹ�
        if (currentTime > createTime)
        {
            
            //GetComponent<JellyFishSkill>().UseSkill();
            currentTime = 0;
        }
            // 4. Ÿ�ٰ��� �Ÿ���
            // 5. ���� ���ݹ����� �����
            if (distance > attackDistance)
            {
                // 6. Move���·� �����Ѵ�.
                state = State.Move;
            }
    }
    private void UpdateMove()
    {   
        // 1. �÷��̾�� ���ϴ� �������� �����Ÿ� �ٰ�����
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        // 2. �÷��̾�� ������ �ݺ��Ѵ�.
        transform.position += dir * speed * Time.deltaTime;
        
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (attackDistance > distance)
        {
            // Attack ���·� �ٲ��.
            state = State.Attack;
        }
        if (detect < distance)
        {
            state = State.Idle;
        }
    }
   
}