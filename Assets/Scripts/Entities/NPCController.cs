using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : EntityController
{
    public float minTimeSameDirection = 1.0f;
    public float maxTimeSameDirection = 3.0f;
    private float currentDirectionTime = 0;
    private bool isChangingDirection = false;

    public float minTimeIdle = 1.0f;
    public float maxTimeIdle = 3.0f;
    private bool isIdle = false;

    private float randomX = 0;
    private float randomY = 0;

    public ObjectPool chickenMeatPool;
    public GameObject chickenMeat;

    public bool isDead = false;

    public AudioClip deathSound;

    // Start is called before the first frame update
    private void Start()
    {
        base.Start();
        chickenMeatPool = new ObjectPool(chickenMeat, 1);
        HandleRandomMovement();
    }

    private void Update()
    {
        HandleDirectionChange();
        HandleIdleAnimation();
    }

    private void HandleDirectionChange()
    {
        if (!isChangingDirection)
        {
            currentDirectionTime += Time.deltaTime;

            if (currentDirectionTime >= minTimeSameDirection)
            {
                isChangingDirection = true;
                currentDirectionTime = 0;

                float delayTime = Random.Range(minTimeSameDirection, maxTimeSameDirection);

                if (!isIdle)
                {
                    this.animator.SetTrigger("idle");
                    isIdle = true;
                }

                StartCoroutine(ChangeDirectionAfterDelay(delayTime));
            }
        }
    }

    private void HandleIdleAnimation()
    {
        if (isIdle && this.rigidbody.velocity != Vector2.zero)
        {
            this.animator.ResetTrigger("idle");
            isIdle = false;
        }
    }

    private void HandleRandomMovement()
    {
        float shouldMove = Random.Range(0.0f, 1.0f);

        if (shouldMove < 0.8f)
        {
            randomX = Random.Range(-1.0f, 1.0f);
            randomY = Random.Range(-1.0f, 1.0f);
        }
        else
        {
            randomX = 0;
            randomY = 0;
        }

        Vector2 input = new Vector2(randomX, randomY);
        this.HandleMovementInput(input);
    }

    private IEnumerator ChangeDirectionAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        if (Random.Range(0, 2) == 0)
        {
            float idleTime = Random.Range(minTimeIdle, maxTimeIdle);
            Vector2 input = Vector2.zero;
            this.rigidbody.velocity = input;
            isIdle = true;
            yield return new WaitForSeconds(idleTime);
        }

        isChangingDirection = false;
        HandleRandomMovement();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Attack"))
        {
            GameObject chickenMeat = chickenMeatPool.GetFromPool();
            if (chickenMeat != null)
            {
                Vector2 pos = transform.position;

                chickenMeat.transform.position = pos;
                chickenMeat.SetActive(true);
            }
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            gameObject.SetActive(false);
            isDead = true;
        }
    }
}
