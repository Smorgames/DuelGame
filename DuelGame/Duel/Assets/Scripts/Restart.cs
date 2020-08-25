using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    Animator anim, loseImageAnimator, winImageAnimator;
    public GameObject loseImage, winImage;

    void Start()
    {
        anim = GetComponent<Animator>();
        loseImageAnimator = loseImage.GetComponent<Animator>();
        winImageAnimator = winImage.GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerBehaviour.currentHP <= 0)
        {
            loseImageAnimator.SetBool("Lose", true);
        }
        if (EnemyBehaviour.enemyCurrentHP <= 0)
        {
            winImageAnimator.SetBool("Win", true);
        }
    }
}
