using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip block, miss, hit, takeDamage1, takeDamage2, takeDamage3, fall;
    public static Animator anim;
    public static int enemyCurrentHP;
    public static int enemyMaxHP;
    float timer;
    public GameObject person;
    SpriteRenderer personColor;
    Color startPersonColor;
    void Start()
    {
        personColor = person.GetComponent<SpriteRenderer>(); // даём доступ к SpriteRenderer врага
        startPersonColor = personColor.color; // записываем изначальный цвет врага в переменную
        anim = GetComponent<Animator>();
        enemyMaxHP = 100;
        enemyCurrentHP = enemyMaxHP;
    }
    void FixedUpdate()
    {
        if (enemyCurrentHP > 0)
        {
            if (Management.turn == false)
            {
                timer += Time.deltaTime;
                int AttackTypeChoice = Random.Range(1, 4);
                float TimerRandom = Random.Range(3, 6);
                if (timer > TimerRandom)
                {
                    if (AttackTypeChoice == 1)
                    {
                        int isBlock = Random.Range(1, 11);
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
                        person.transform.position = new Vector3(person.transform.position.x, person.transform.position.y, person.transform.position.z + 0.5f);
                        if (isBlock > 7)
                        {
                            Management.turn = true;
                            anim.SetTrigger("TA");
                            PlayerBehaviour.anim.SetTrigger("PersonTopBlock");
                            AudioPlay(block);
                            timer = 0;
                        }
                        else
                        {
                            anim.SetTrigger("TA");
                            RecountPersonHP(10, 15);
                            Management.turn = true;
                            StartCoroutine(Damage(0.3f));
                            AudioPlay(hit);
                            AudioPlayTakingDamage(takeDamage1, takeDamage2, takeDamage3);
                            timer = 0;
                        }
                    }
                    if (AttackTypeChoice == 2)
                    {
                        int isBlock = Random.Range(1, 11);
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
                        person.transform.position = new Vector3(person.transform.position.x, person.transform.position.y, person.transform.position.z + 0.5f);
                        if (isBlock > 7)
                        {
                            Management.turn = true;
                            anim.SetTrigger("MA");
                            PlayerBehaviour.anim.SetTrigger("PersonMidBlock");
                            AudioPlay(block);
                            timer = 0;
                        }
                        else
                        {
                            anim.SetTrigger("MA");
                            RecountPersonHP(11, 14);
                            Management.turn = true;
                            StartCoroutine(Damage(0.4f));
                            AudioPlay(hit);
                            AudioPlayTakingDamage(takeDamage1, takeDamage2, takeDamage3);
                            timer = 0;
                        }
                    }
                    if (AttackTypeChoice == 3)
                    {
                        int isBlock = Random.Range(1, 11);
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
                        person.transform.position = new Vector3(person.transform.position.x, person.transform.position.y, person.transform.position.z + 0.5f);
                        if (isBlock > 7)
                        {
                            Management.turn = true;
                            anim.SetTrigger("BA");
                            PlayerBehaviour.anim.SetTrigger("PersonBotBlock");
                            AudioPlay(miss);
                            timer = 0;
                        }
                        else
                        {
                            anim.SetTrigger("BA");
                            RecountPersonHP(11, 14);
                            Management.turn = true;
                            StartCoroutine(Damage(0.35f));
                            AudioPlay(hit);
                            AudioPlayTakingDamage(takeDamage1, takeDamage2, takeDamage3);
                            timer = 0;
                        }
                    }
                }
            }
        }
        if (enemyCurrentHP <= 0)
        {
            enemyCurrentHP = 0;
            anim.SetInteger("EnemyState", 1);
        }
    }

    void RecountPersonHP(int a, int b)
    {
        int damage = Random.Range(a, b);
        PlayerBehaviour.currentHP -= damage;
    }
    IEnumerator Damage(float delay)
    {
        yield return new WaitForSeconds(delay);
        personColor.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        personColor.color = startPersonColor;
        yield return new WaitForSeconds(0.1f);
        personColor.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        personColor.color = startPersonColor;
    }
    public void AudioPlay(AudioClip clip)
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


