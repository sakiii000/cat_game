using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    public enum TYPE
    {
        PLAYER,
        ENEMY,
    }
    public TYPE type = TYPE.PLAYER;

    float direction;
    Vector3 pos;
    [SerializeField] AudioClip attackSound;
    AudioSource audioSource;
    bool isMove = true;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        switch (type)
        {
            case TYPE.PLAYER:
                // Playerの時の処理
                direction = -1;
                break;

            case TYPE.ENEMY:
                // Enemyの時の処理
                direction = 1;
                break;
        }
        pos = new Vector3(direction, 0, 0);
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            transform.position += pos * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 敵にぶつかったら移動を止める
        if (collision.gameObject.tag == "Enemy" && type == TYPE.PLAYER
            || collision.gameObject.tag == "Player" && type == TYPE.ENEMY)
        {
            isMove = false;
            // 攻撃をし始める
            // 攻撃アニメーションの再生
            anim.SetBool("Attack", true);
            // 相手のHPを削る
            HitPoint hitPoint = collision.gameObject.GetComponent<HitPoint>();
            StartCoroutine(AttackAction(hitPoint));
            // 倒したらまた前に進む
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && type == TYPE.PLAYER
            || collision.gameObject.tag == "Player" && type == TYPE.ENEMY)
        {
            isMove = true;
            anim.SetBool("Attack", false);
        }
    }

    IEnumerator AttackAction(HitPoint hitPoint)
    {
        while(hitPoint.hp > 0)
        {
            if (attackSound != null && audioSource != null && !audioSource.isPlaying)
            {
                audioSource.clip = attackSound;
                audioSource.Play();
            }

            yield return new WaitForSeconds(0.5f);
            hitPoint.Damage(1);
            
        }
        // 攻擊結束後停止音效
        audioSource.Stop();
    }

    public void DestroyEvent()
    {
        Destroy(gameObject);
    }
}
