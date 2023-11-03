using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : EntityController
{
    // Movement AI
    public float minTimeSameDirection = 1.0f;
    public float maxTimeSameDirection = 3.0f;
    private float currentDirectionTime = 0;
    private bool isChangingDirection = false;
    private float randomX = 0;
    private float randomY = 0;

    // Idle AI
    public float minTimeIdle = 1.0f;
    public float maxTimeIdle = 3.0f;
    private bool isIdle = false;

    // Death data
    public ObjectPool meatPool;
    public GameObject meatPrefab;
    public bool isDead = false;
    public AudioClip deathSound;
    public int health = 1;
    public float knocback = 0.3f;

    private void Start()
    {
        base.Start();
        this.ResetMeatPool();
        HandleRandomMovement();
    }

    private void Update()
    {
        HandleDirectionChange();
        HandleIdleAnimation();
    }

    public void ResetMeatPool()
    {
        meatPool = new ObjectPool(meatPrefab, 1);
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
        Vector2 aux = Vector2.zero;
        Vector2 LastPos = Vector2.zero;
        if (collider.CompareTag("AttackEast"))
        {
            moveSpeed = 3 * moveSpeed;
            isChangingDirection = true;
            HandleRandomMovement();
            --health;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            LastPos = transform.position;
            aux = new Vector2(transform.position.x + knocback, transform.position.y);
            transform.position = aux;
        }
        if (collider.CompareTag("AttackWest"))
        {
            moveSpeed = 3 * moveSpeed;
            isChangingDirection = true;
            HandleRandomMovement();
            --health;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            LastPos = transform.position;
            aux = new Vector2(transform.position.x - knocback, transform.position.y);
            transform.position = aux;
        }
        if (collider.CompareTag("AttackNorth"))
        {
            moveSpeed = 3 * moveSpeed;
            isChangingDirection = true;
            HandleRandomMovement();
            --health;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            LastPos = transform.position;
            aux = new Vector2(transform.position.x, transform.position.y + knocback);
            transform.position = aux;
        }
        if (collider.CompareTag("AttackSouth"))
        {
            moveSpeed = 3 * moveSpeed;
            isChangingDirection = true;
            HandleRandomMovement();
            --health;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            LastPos = transform.position;
            aux = new Vector2(transform.position.x, transform.position.y - knocback);
            transform.position = aux;
        }

        if (health < 0)
        {
            GameObject meat = this.meatPool.GetFromPool();
            if (meat != null)
            {
                meat.transform.position = LastPos;
                meat.SetActive(true);
            }
            gameObject.SetActive(false);
            isDead = true;
        }
    }
}

