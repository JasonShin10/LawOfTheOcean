using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    // ��
    // �÷��̾ ���� ���������� ������
    // ������ ���� �پ������ õõ�� �����ϰ�

    // �÷��̾ �Ѿƿ��� �����Ѵ�.
    // �����Ҷ� �÷��̾��� hp�� �ް��ϰ�
    // ������ hp�� ȸ���Ѵ�.
    // �÷��̾ ������ �����
    // �ٽ� ���ڸ��� ���ư���.

    // FSM���� ���¸� �����ϰ�ʹ�.
    public enum State
    {
        Idle,
        Move,
        Attack,
        Die
    }
    
    State state;

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
        if ( state == State.Idle)
        {
            UpdateIdle();
        }
        else if( state == State.Move)
        {
            UpdateMove();
        }
        else if( state == State.Attack)
        {
            UpdateAttack();
        }
        else if( state == State.Die)
        {

        }
    }
    float detect = 10;
    private void UpdateIdle()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

            // ���� �÷��̾���� �Ÿ��� �����Ÿ����� ������
        if ( detect > distance)
        {
            state = State.Move;
        }
         // Move���·� �����Ѵ�.
    }
    float speed = 3;
    float attackDistance = 1;
    private void UpdateMove()
    {
        // Ÿ���� ��������
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        // ��� �̵��Ѵ�.
        //transform.position += dir * speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x,target.transform.position.y,transform.position.z) , 0.05f);
        float distance = Vector3.Distance(target.transform.position, transform.position);
        // ���� Ÿ�ٰ��� �Ÿ��� ���ݹ������� ������

        if (attackDistance > distance)
        {
        // Attack ���·� �ٲ��.
            state = State.Attack;
        }
    }
    float currentTime;
    public float createTime = 2;
    private void UpdateAttack()
    {
        // 1. �ð��� �帣�ٰ�  
        currentTime += Time.deltaTime;
            // 2. �����ð��ܵǸ�
        if (currentTime > createTime)
        {
            // 2. ������ �Ѵ�.

            // 3. ������ �ѵڿ��� �ð��� �ʱ�ȭ�Ѵ�.
            currentTime = 0;
            // 4. Ÿ�ٰ��� �Ÿ���
            float distance = Vector3.Distance(target.transform.position, transform.position);
        // 5. ���� ���ݹ����� �����
        if(distance > attackDistance)
            {
                state = State.Move;
        // 6. Move���·� �����Ѵ�.
            }
        }
    }

    private void UpdateDie()
    {

    }

    
}
