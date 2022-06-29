using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ʿ� �Ӽ�: ���콺 ������ ��ġ, �Ѿ� �ӵ�
public class Bullet : MonoBehaviour
{
    [Header("�Ѿ� �Ӽ�")]
    [SerializeField] private float speed = 10;
    [SerializeField] private float shootRange = 100f;
    private GameObject player;
    private PlayerInput playerInput;
    private Vector3 dir;
    //�Ѿ��� ���콺 ������ �������� �̵���Ų��.
    private void Awake()
    {
        //�ʿ�Ӽ�: �Է°�
        player = GameObject.Find("Player");
        playerInput = player.GetComponent<PlayerInput>();
    }
    private void Start()
    {
        //���콺 ������ ��������
        dir = new Vector3(this.transform.position.x + playerInput.MousePosition.x,playerInput.MousePosition.y, this.transform.position.z + shootRange);
        dir.Normalize();
    }
    void Update()
    {
        //�Ѿ��� �̵���Ų��.
        this.transform.position += dir * speed* Time.deltaTime;
    }
}
