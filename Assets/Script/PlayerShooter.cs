using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ʿ� �Ӽ�: �Է°�, �Ѿ�
public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    
    [System.NonSerialized]
    private PlayerInput playerInput;
    
    private void Start()
    {
        //playerInput�� �ʿ��ϴ�.
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        //���콺 ��Ŭ���� �Էµȴٸ�
        if (playerInput.IsShootingButton)
        {
            Debug.Log("���콺 ������: " + playerInput.MousePosition);
            //�Ѿ��� �����Ѵ�.
            bullet.transform.position = this.transform.position;
            Instantiate(bullet);
        }  
    }
}
