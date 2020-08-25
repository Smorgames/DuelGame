using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public AudioClip block, miss, hit, takeDamage1, takeDamage2, takeDamage3, fall;
    public Text amountOfHP;
    public Text amountOfEnemyHP;
    public static Animator anim;
    public static int currentHP, maxHP;
    public GameObject battlepanel;
    public GameObject enemy;
    SpriteRenderer enemyColor;
    Color startEnemyColor;
    void Start()
    {
        enemyColor = enemy.GetComponent<SpriteRenderer>(); // даём доступ к SpriteRenderer врага
        startEnemyColor = enemyColor.color; // записываем изначальный цвет врага в переменную
        anim = GetComponent<Animator>();
        maxHP = 100;
        currentHP = maxHP;
        amountOfHP.text = currentHP + "HP";
        amountOfEnemyHP.text = EnemyBehaviour.enemyCurrentHP + "HP";
    }
    void Update()
    {
        amountOfHP.text = currentHP + "HP";
        if(currentHP <= 0 && Management.turn == true)
        {
            Death();
        }
    }
    public void topattack()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
        enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z + 0.5f);
        int isBlock = Random.Range(1, 11);
        if (isBlock > 7)
        {
            Management.turn = false;
            anim.SetTrigger("PersonTopAttack");
            EnemyBehaviour.anim.SetTrigger("TB");
            AudioPlay(block);
        }
        else
        {
            Management.turn = false;
            RecountEnemyHP(10, 15);
            anim.SetTrigger("PersonTopAttack");
            amountOfEnemyHP.text = EnemyBehaviour.enemyCurrentHP + "HP";
            StartCoroutine(Damage(0.3f));
            AudioPlay(hit);
            AudioPlayTakingDamage(takeDamage1, takeDamage2, takeDamage3);
        }
    }
    public void midattack()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
        enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z + 0.5f);
        int isBlock = Random.Range(1, 11);
        if (isBlock > 8)
        {
            Management.turn = false;
            anim.SetTrigger("PersonMidAttack");
            EnemyBehaviour.anim.SetTrigger("MB");
            AudioPlay(block);
        }
        else
        {
            Management.turn = false;
            RecountEnemyHP(11, 14);
            anim.SetTrigger("PersonMidAttack");
            amountOfEnemyHP.text = EnemyBehaviour.enemyCurrentHP + "HP";
            StartCoroutine(Damage(0.4f));
            AudioPlay(hit);
            AudioPlayTakingDamage(takeDamage1, takeDamage2, takeDamage3);
        }
    }
    public void botattack()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
        enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z + 0.5f);
        int isBlock = Random.Range(1, 11);
        if (isBlock > 8)
        {
            Management.turn = false;
            anim.SetTrigger("PersonBotAttack");
            EnemyBehaviour.anim.SetTrigger("BB");
            AudioPlay(miss);
        }
        else
        {
            Management.turn = false;
            RecountEnemyHP(11, 14);
            anim.SetTrigger("PersonBotAttack");
            amountOfEnemyHP.text = EnemyBehaviour.enemyCurrentHP + "HP";
            StartCoroutine(Damage(0.35f));
            AudioPlay(hit);
            AudioPlayTakingDamage(takeDamage1, takeDamage2, takeDamage3);
        }
    }
    void RecountEnemyHP(int a, int b)
    {
        int damage = Random.Range(a, b);
        EnemyBehaviour.enemyCurrentHP -= damage;
    }
    void Death()
    {
        currentHP = 0;
        battlepanel.SetActive(false);
        anim.SetInteger("PersonCondition", 1);
    }
    IEnumerator Damage(float delay)
    {
        yield return new WaitForSeconds(delay);
        enemyColor.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        enemyColor.color = startEnemyColor;
        yield return new WaitForSeconds(0.1f);
        enemyColor.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        enemyColor.color = startEnemyColor;
    } // карутина демонстрации нанесения урона
    public void AudioPlay (AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
    public void AudioPlayTakingDamage(AudioClip clip1, AudioClip clip2, AudioClip clip3)
    {
        int i = Random.Range(1, 4);
        if (i == 1)
        {
            StartCoroutine(Wait());
            GetComponent<AudioSource>().PlayOneShot(clip1);
        }
        if (i == 2)
        {
            StartCoroutine(Wait());
            GetComponent<AudioSource>().PlayOneShot(clip2);
        }
        if (i == 3)
        {
            StartCoroutine(Wait());
            GetComponent<AudioSource>().PlayOneShot(clip3);
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
    }
}
