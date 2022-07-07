using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private UIManager()
    {
        instance = this;
    }
    public Stack<GameObject> UIObject;
    private GameObject enemy;
    private void Update()
    {
        if (enemy)
            Debug.Log($"Enemy �̸�:{enemy.GetComponent<NameTag>().Name} \nEnemy Health: {enemy.GetComponent<EnemyHealth>().Health}");
        else
        {
            Debug.Log("enemy ����");
        }
    }

    public GameObject CurrentEnemy { get { return enemy; } set { enemy = value; } }
    public bool IsOrbMoving { get; set; }
}
