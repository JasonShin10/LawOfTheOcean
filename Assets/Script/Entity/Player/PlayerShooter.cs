using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ʿ� �Ӽ�: �Է°�, �Ѿ�
public class PlayerShooter : MonoBehaviour
{
    [Header("�Ѿ� ���� ����")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletMaxDistance = 1100;

    private PlayerInput playerInput;
    public Vector3 EnemyPosition { get; private set; }
    public Vector3 BulletMaxDirection { get; private set; }
    private void Start()
    {
        //playerInput�� �ʿ��ϴ�.
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        Vector3 dir = new Vector3(transform.position.x + playerInput.MousePosition.x, playerInput.MousePosition.y, this.transform.position.z + bulletMaxDistance);
        Debug.DrawRay(transform.position, dir.normalized * bulletMaxDistance, Color.red);
        //��򰡿� ��Ҵٸ�(deadzone ����)
        if (playerInput.StealSkillButton)
        {
            //SteaSkillButton �ʱ�ȭ
            playerInput.StealSkillButton = false;
            GameManager.instance.IsStealUse = true;
        }
        //���콺 ��Ŭ���� �Էµȴٸ�
        if (playerInput.IsShootingButton)
        {
            //�Ѿ��� �����Ѵ�.
            bullet.transform.position = transform.position;
            Instantiate(bullet);
        }
        BulletMaxDirection = dir;
    }
}
