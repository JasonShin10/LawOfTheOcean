using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ʿ� �Ӽ�: �Է°�, �Ѿ�
public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletMaxDistance = 300;

    private RaycastHit hit;
    private PlayerInput playerInput;
    public Vector3 EnemyPosition { get; private set; }
    public Vector3 BulletMaxDirection { get; private set; }
    public bool IsEnemyHit { get; private set; }
    private void Start()
    {
        IsEnemyHit = false;
        //playerInput�� �ʿ��ϴ�.
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        //���콺 ��Ŭ���� �Էµȴٸ�
        if (playerInput.IsShootingButton)
        {
            Vector3 dir = new Vector3(this.transform.position.x + playerInput.MousePosition.x, playerInput.MousePosition.y, this.transform.position.z + bulletMaxDistance);
            dir.Normalize();
            Debug.DrawRay(transform.position, dir * 300, Color.red);
            //Enemy�� �¾Ҵٸ�,
            if (Physics.Raycast(transform.position, dir, out hit, bulletMaxDistance, 6))
            {
                Debug.Log("Enemy ����");
                IsEnemyHit = true;
                EnemyPosition = hit.transform.position;
            }
            else
            {
                IsEnemyHit = false;
                BulletMaxDirection = dir;
            }
            //�Ѿ��� �����Ѵ�.
            bullet.transform.position = this.transform.position;
            Instantiate(bullet);
        }  
    }
}
