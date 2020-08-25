using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    public static bool turn;
    public GameObject battlepanel;
    public GameObject enemy, hero, restart;
    Animator anim;
    void Start()
    {
        restart.SetActive(false);
        anim = restart.GetComponent<Animator>();
        battlepanel = GameObject.FindWithTag("battlepanel");
        turn = true;
    }

    void Update()
    {
        if (PlayerBehaviour.currentHP <= 0 || EnemyBehaviour.enemyCurrentHP <= 0)
        {
            restart.SetActive(true);
            anim.SetBool("isAppear", true);
        }
        if (PlayerBehaviour.currentHP > 0)
        {
            if (turn == true)
            {
                battlepanel.SetActive(true);
            }
            else
            {
                battlepanel.SetActive(false);
            }
        }
    }
}
