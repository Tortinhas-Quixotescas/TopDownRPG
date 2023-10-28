using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController uniqueInstance;
    public Rigidbody2D playerRB;
    public int moveSpeed = 5;
    public Animator playerAnimator;
    public string areaTransitionName;
    public bool busy = false;
    private bool isDelaying = false;

    private float lastXValue = 0;
    private float lastYValue = -1;
    // Start is called before the first frame update
    void Start()

    {
        if (uniqueInstance == null)
            uniqueInstance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!busy)
        {
            playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
            playerAnimator.SetFloat("xMovement", playerRB.velocity.x);
            playerAnimator.SetFloat("yMovement", playerRB.velocity.y);
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                lastXValue = Input.GetAxisRaw("Horizontal");
                playerAnimator.SetFloat("lastXValue", Input.GetAxisRaw("Horizontal"));
                lastYValue = Input.GetAxisRaw("Vertical");
                playerAnimator.SetFloat("lastYValue", Input.GetAxisRaw("Vertical"));
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && !busy)
        {
            busy = true;
            if (lastXValue > 0)
                playerAnimator.SetTrigger("swordAttackEast");
            else if (lastXValue < 0)
                playerAnimator.SetTrigger("swordAttackWest");
            else if (lastYValue > 0)
                playerAnimator.SetTrigger("swordAttackNorth");
            else if (lastYValue < 0)
                playerAnimator.SetTrigger("swordAttackSouth");
            StartCoroutine(DelayExecution(0.30f)); // Atraso de 1 segundo
        }


    }

    private IEnumerator DelayExecution(float delayTime)
    {
        isDelaying = true;

        yield return new WaitForSeconds(delayTime);

        isDelaying = false;

        // Agora você pode continuar com o restante do código após o atraso
        busy = false;
        playerAnimator.SetTrigger("notBusy");
    }
}
