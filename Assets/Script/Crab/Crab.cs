using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    // ��
    // �÷��̾ ���� ���������� ������
    // ������ ���� �پ������ õõ�� �����Ѵ�.
    // �÷��̾ �Ѿƿ��� �����Ѵ�.
    // �����Ҷ� �÷��̾��� hp�� �ް��ϰ�
    // ������ hp�� ȸ���Ѵ�.
    // �÷��̾ ������ �����
    // �ٽ� ���ڸ��� ���ư���.

    // FSM���� ���¸� �����ϰ�ʹ�.

    [SerializeField] private Skill crab;

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
        if ( state == State.Idle)
        {
            UpdateIdle();
        }
        else if( state == State.Move)
        {
            
            StartCoroutine("IeMove");
        }
        else if( state == State.Attack)
        {
            UpdateAttack();
        }
        else if( state == State.Return)
        {
            UpdateReturn();
        }
    }
    float firstDetect = 20;
    float detect = 10;
    Vector3 start;
    private void UpdateIdle()
    {
        start = transform.position;
        float distance = Vector3.Distance(target.transform.position, transform.position);

        bool isInSight = CheckPlayerAngle(target.transform.position);
            // ���� �÷��̾���� �Ÿ��� �����Ÿ����� ������
        if ( firstDetect > distance && isInSight)
        {
            state = State.Move;
        }
         //  Move���·� �����Ѵ�.
    }
    float speed = 3;
    float attackDistance = 5;

    float currentTime;
    [SerializeField] private float createTime = 1;
    [SerializeField] private float attackTime = 1;

    bool CheckPlayerAngle(Vector3 position)
    {
        // 1. üũ�Ϸ��� ����� �ٶ󺸴� ���͸� ���Ѵ�.
        Vector3 direction = position - transform.position;
        // 2. ���� ���� ���Ϳ� �տ��� ���� ���͸� ���� ���ؼ� ���հ��� ���Ѵ�.
        float checkDegree = Vector3.Angle(transform.up, direction);
       
        // 3. ������ ������ 45�� �̳���� true, 45�� ���̸� false��� ��ȯ�Ѵ�.
        if (checkDegree <= 45)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    private void UpdateAttack()
    {
            float distance = Vector3.Distance(target.transform.position, transform.position);
        // 1. �ð��� �帣�ٰ�  
        currentTime += Time.deltaTime;
            // 2. �����ð��� �Ǹ�
        if (currentTime > createTime)
        {
            crab.User = gameObject;
            // 3. ������ �Ѵ�.
            crab.UseSkill();
            // 4. ������ �ѵڿ��� �ð��� �ʱ�ȭ�Ѵ�.
            currentTime = 0;
        }
            // 5. Ÿ�ٰ��� �Ÿ���
        // 6. ���� ���ݹ����� �����
        if(distance > attackDistance)
            {
            
                state = State.Move;
            

        // 7. Move���·� �����Ѵ�.
            }
    }
    bool jump = true;
   
 
    IEnumerator IeMove()
    {

        // start coroutine�ϴ� ����
        if (jump) 
        {
        // 1. �÷��̾��� ��ġ���� �ö����ʹ�
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, target.transform.position.y, transform.position.z), 0.009f);
        // 2. �ڷ�ƾ���� �ѹ��� �����ϰ� 
            yield return new WaitForSeconds(1f);
            jump = false;
        }
        // 3. �� ������ ������ �Ѿƿ��°ɷ�
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
     
        float distance = Vector3.Distance(target.transform.position, transform.position);
        //�Ÿ��� ���ݰŸ����� ������
        if (attackDistance > distance)
        {
         //Attack ���·� �ٲ��.
            state = State.Attack;
        }
        if (distance > detect)
        {
            state = State.Return;
        }
        
    }
    private void UpdateReturn()
    {
        // ����, ���� ������ġ�� start ��ġ���� 10��Ƽ���� �̻��̶��..

        Vector3 back = start - transform.position;
        if(back.magnitude > 0.1f)
        {
        // start ��������
        // �ǵ��ư���.
            transform.position += back.normalized * speed * Time.deltaTime;
        }
        // �׷��� �ʴٸ�, ���� ��ġ�� start���� �����Ѵ�.       
        else
        {
            transform.position = start;
            state = State.Idle;
            jump = true;

        }
        float distance = Vector3.Distance(target.transform.position, transform.position);

        // ���� �÷��̾���� �Ÿ��� �����Ÿ����� ������
        if (detect > distance)
        {
        // Move���·� �����Ѵ�.
            state = State.Move;
        }
    }


}
