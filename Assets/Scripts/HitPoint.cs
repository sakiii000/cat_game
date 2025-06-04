using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitPoint : MonoBehaviour
{
    public int hp;

    [SerializeField] UnityEvent OnDamageEvent;
    [SerializeField] UnityEvent OnDestroyEvent;

    GameManager gm => GameManager.instance;

    public void Damage(int damage)
    {
        if (gm.isGame)
        {
            hp -= damage;

            if (OnDamageEvent != null)
            {
                OnDamageEvent.Invoke();
            }

            if (hp <= 0)
            {
                if (OnDestroyEvent != null)
                {
                    OnDestroyEvent.Invoke();
                }
            }
        }
    }
}
