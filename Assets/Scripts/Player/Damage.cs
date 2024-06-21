using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameObject firstHeart;
    public GameObject secondHeart;
    public GameObject thirdHeart;
    public Animator damageAnimator;
    public Animator healthAnimator1;
    public Animator healthAnimator2;
    public Animator healthAnimator3;

    private int _hitCount = 0;
    private List<GameObject> _monsters = new List<GameObject>();

    public void Awake()
    {
        // Находим все объекты с тегом "Monster" и добавляем их в список
        GameObject[] monsterObjects = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject monster in monsterObjects)
        {
            _monsters.Add(monster);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            _hitCount++;
            //Debug.Log("Привет");

            switch (_hitCount)
            {
                case 1:
                    PlayDamageAnimation();
                    PlayHealthAnimation1(firstHeart);
                    Destroy(firstHeart);
                    _monsters = new List<GameObject>();
                    GameObject[] monsterObjects1 = GameObject.FindGameObjectsWithTag("Monster");
                    foreach (GameObject monster in monsterObjects1)
                    {
                        _monsters.Add(monster);
                    }
                    break;
                case 2:
                    PlayDamageAnimation();
                    PlayHealthAnimation2(secondHeart);
                    Destroy(secondHeart);
                    _monsters = new List<GameObject>();
                    GameObject[] monsterObjects2 = GameObject.FindGameObjectsWithTag("Monster");
                    foreach (GameObject monster in monsterObjects2)
                    {
                        _monsters.Add(monster);
                    }
                    break;
                case 3:
                    PlayDamageAnimation();
                    PlayHealthAnimation3(thirdHeart);
                    Destroy(thirdHeart);
                    _monsters = new List<GameObject>();
                    GameObject[] monsterObjects3 = GameObject.FindGameObjectsWithTag("Monster");
                    foreach (GameObject monster in monsterObjects3)
                    {
                        _monsters.Add(monster);
                    }
                    break;
            }

            for (int i = 0; i < _monsters.Count; i++)
            {
                Destroy(_monsters[i]);
            }
            _monsters.Clear();
        }
    }

    private void PlayDamageAnimation()
    {
        damageAnimator.Play("Damage");
    }

    private void PlayHealthAnimation1(GameObject heart)
    {
        healthAnimator1.SetTrigger("Health");
    }
    private void PlayHealthAnimation2(GameObject heart)
    {
        healthAnimator2.SetTrigger("Health");
    }
    private void PlayHealthAnimation3(GameObject heart)
    {
        healthAnimator3.SetTrigger("Health");
    }
}