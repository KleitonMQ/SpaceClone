using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    Transform bonusTransform;
    Animator bonusAnimator;
    Fase fase;
    public AudioSource bonusExplosion;

    public float speed;
    public bool isAlive;

    public int scorePoint;
    // Start is called before the first frame update
    void Start()
    {
        bonusExplosion.Stop();
        isAlive= true;
        bonusAnimator= GetComponent<Animator>();
        bonusTransform = GetComponent<Transform>();
        Destroy(gameObject, 6f);

        //Outra forma pegar ponteiro da classe.
        fase = FindObjectOfType(typeof(Fase)) as Fase;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            Move();
        }
    }

    void Move()
    {
        bonusTransform.position = new Vector2(bonusTransform.position.x + speed * Time.deltaTime, bonusTransform.position.y);
    }
    public void Explosion()
    {
        isAlive = false;
        fase.AddScore(scorePoint);
        GetComponent<BoxCollider2D>().enabled = false;
        bonusAnimator.SetBool("explosion", true);
        bonusExplosion.Play();
        Invoke(nameof(Destroy), 0.5f);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
