using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ʿ� �Ӽ�: �Է°�, �Ѿ�
public class PlayerShooter : MonoBehaviour
{
    [Header("�Ѿ� ���� ����")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletMaxDistance = 1100;

    private RaycastHit hit;
    private PlayerInput playerInput;
    public Vector3 EnemyPosition { get; private set; }
    public Vector3 BulletMaxDirection { get; private set; }
    public bool IsEnemyHit { get; set; }
    //��ų�� ����ߴ°�
    public bool IsStealUse { get; set; }
    private void Start()
    {
        IsStealUse = false;
        IsEnemyHit = false;
        //playerInput�� �ʿ��ϴ�.
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        Vector3 dir = new Vector3(transform.position.x + playerInput.MousePosition.x, playerInput.MousePosition.y, this.transform.position.z + bulletMaxDistance);
        Debug.DrawRay(transform.position, dir.normalized * bulletMaxDistance, Color.red);
        //��򰡿� ��Ҵٸ�(deadzone ����)
        if (Physics.Raycast(transform.position, dir.normalized, out hit, bulletMaxDistance) && hit.collider.tag != "DeadZone")
        {
            //���콺 ��Ŭ���� �Էµȴٸ�
            if (playerInput.IsShootingButton)
            {
                //Debug.Log("playerInput.MousePosition = " + playerInput.MousePosition);
                //Enemy ��ġ�� �߻��Ѵ�.
                if (hit.collider.tag == "Enemy")
                {
                    IsEnemyHit = true;
                    //Debug.Log("Enemy ����");
                    EnemyPosition = hit.transform.position;
                    Instantiate(bullet);
                }
            }
        }
        //deadzone�Ǵ� ��������� ���� �ʾ��� ���
        else
        {
            if (GameManager.instance.StealSkillButton)
            {
                //���콺 ��Ŭ���� �Էµȴٸ�
                if (playerInput.IsShootingButton)
                {
                    //SteaSkillButton �ʱ�ȭ
                    GameManager.instance.StealSkillButton = false;
                    IsStealUse = true;

                    BulletMaxDirection = dir;
                    //�Ѿ��� �����Ѵ�.
                    bullet.transform.position = transform.position;
                    Instantiate(bullet);
                }
            }
        }  
    }
}
