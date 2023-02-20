using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    Transform bonusTransform;
    Animator bonusAnimator;
    
    public float speed;
    public bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        isAlive= true;
        bonusAnimator= GetComponent<Animator>();
        bonusTransform = GetComponent<Transform>();
        Destroy(gameObject, 6f);
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
        GetComponent<BoxCollider2D>().enabled = false;
        bonusAnimator.SetBool("explosion", true);
        Invoke(nameof(Destroy), 0.5f);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
