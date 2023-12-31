using System.Collections;
using UnityEngine;

public class PlayerController : EntityController
{
    public bool busy = false;
    public ObjectPool eastSlashPool;
    public GameObject eastSlash;
    public ObjectPool westSlashPool;
    public GameObject westSlash;
    public ObjectPool northSlashPool;
    public GameObject northSlash;
    public ObjectPool southSlashPool;
    public GameObject southSlash;
    private bool isDelaying = false;
    private bool canReach = false;
    private Collider2D interactiveCollider;
    public static PlayerController uniqueInstance;

    void Awake()
    {
        if (uniqueInstance == null)
        {
            uniqueInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        base.Start();
        InitializeSlashPools();
    }

    private void Update()
    {
        HandleMovementInput();
        HandleSwordAttack();
        if (Input.GetKeyDown(KeyCode.Q) && canReach)
            HandleInteractiveObject(this.interactiveCollider);
    }

    private void OnLevelWasLoaded()
    {
        InitializeSlashPools();
    }

    private void InitializeSlashPools()
    {
        eastSlashPool = new ObjectPool(eastSlash, 1);
        westSlashPool = new ObjectPool(westSlash, 1);
        northSlashPool = new ObjectPool(northSlash, 1);
        southSlashPool = new ObjectPool(southSlash, 1);
    }

    private void HandleMovementInput()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        this.HandleMovementInput(input);
    }

    private void HandleSwordAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !busy)
        {
            busy = true;

            if (this.lastXValue > 0)
            {
                PerformSwordAttack("swordAttackEast", eastSlash, eastSlashPool);
            }
            else if (this.lastXValue < 0)
            {
                PerformSwordAttack("swordAttackWest", westSlash, westSlashPool);
            }
            else if (this.lastYValue > 0)
            {
                PerformSwordAttack("swordAttackNorth", northSlash, northSlashPool);
            }
            else if (this.lastYValue < 0)
            {
                PerformSwordAttack("swordAttackSouth", southSlash, southSlashPool);
            }

            StartCoroutine(DelayExecution(0.30f));
        }
    }

    private void HandleInteractiveObject(Collider2D collider)
    {
        InteractiveObjectController interactiveObject = collider.GetComponent<InteractiveObjectController>();
        if (interactiveObject != null)
        {
            interactiveObject.Interact();
        }
    }

    private void PerformSwordAttack(string triggerName, GameObject slash, ObjectPool slashPool)
    {
        this.animator.SetTrigger(triggerName);
        GameObject slashObject = slashPool.GetFromPool();
        if (slashObject != null)
        {
            Vector2 pos = transform.position;
            slashObject.transform.position = pos;
            slashObject.SetActive(true);
        }
    }

    private IEnumerator DelayExecution(float delayTime)
    {
        isDelaying = true;
        yield return new WaitForSeconds(delayTime);
        isDelaying = false;
        busy = false;
        this.animator.SetTrigger("notBusy");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("ChickenMeat"))
            MainManager.Instance.UpdateInventory(Inventory.InventoryItems.ChickenMeat);
        else if (collider.CompareTag("CowMeat"))
            MainManager.Instance.UpdateInventory(Inventory.InventoryItems.CowMeat);
        else if (collider.CompareTag("PigMeat"))
            MainManager.Instance.UpdateInventory(Inventory.InventoryItems.PigMeat);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Interactive"))
        {
            canReach = true;
            this.interactiveCollider = collider;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Interactive"))
            canReach = false;
    }
}
