using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityController
{
    public bool busy = false;
    public int cornAmount = 0;
    public int potatoAmount = 0;
    public int tomatoAmount = 0;
    public int spinachAmount = 0;

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

    public static PlayerController uniqueInstance;

    void Awake()
    {
        InitializeSingleton();
    }

    private void InitializeSingleton()
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
        HandleInput();
    }

    private void InitializeSlashPools()
    {
        eastSlashPool = new ObjectPool(eastSlash, 1);
        westSlashPool = new ObjectPool(westSlash, 1);
        northSlashPool = new ObjectPool(northSlash, 1);
        southSlashPool = new ObjectPool(southSlash, 1);
    }

    private void HandleInput()
    {
        HandleMovementInput();
        HandleSwordAttack();
    }

    private void HandleMovementInput()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        HandleMovementInput(input);
    }

    private void HandleSwordAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !busy)
        {
            busy = true;

            if (TryPerformSwordAttack("swordAttackEast", eastSlash, eastSlashPool))
            {
                StartCoroutine(DelayExecution(0.30f));
            }
            else if (TryPerformSwordAttack("swordAttackWest", westSlash, westSlashPool))
            {
                StartCoroutine(DelayExecution(0.30f));
            }
            else if (TryPerformSwordAttack("swordAttackNorth", northSlash, northSlashPool))
            {
                StartCoroutine(DelayExecution(0.30f));
            }
            else if (TryPerformSwordAttack("swordAttackSouth", southSlash, southSlashPool))
            {
                StartCoroutine(DelayExecution(0.30f));
            }
        }
    }

    private bool TryPerformSwordAttack(string triggerName, GameObject slash, ObjectPool slashPool)
    {
        this.animator.SetTrigger(triggerName);
        GameObject slashObject = slashPool.GetFromPool();
        if (slashObject != null)
        {
            Vector2 pos = transform.position;
            slashObject.transform.position = pos;
            slashObject.SetActive(true);
            return true;
        }
        return false;
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
        HandleSlashCollision(collider);
    }

    private void HandleSlashCollision(Collider2D collider)
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
            canReach = true;
        if (Input.GetKeyDown(KeyCode.Q) && canReach)
            HandleInteractiveObject(collider);

    }

    private void HandleInteractiveObject(Collider2D collider)
    {
        InteractiveObjectController interactiveObject = collider.GetComponent<InteractiveObjectController>();
        if (interactiveObject != null)
        {
            string itemName = interactiveObject.GetItem();
            if (itemName != null)
            {
                if (itemName.Equals("Corn"))
                    ++cornAmount;
                if (itemName.Equals("Potato"))
                    ++potatoAmount;
                if (itemName.Equals("Tomato"))
                    ++tomatoAmount;
                if (itemName.Equals("Spinach"))
                    ++spinachAmount;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Interactive"))
            canReach = false;
    }
}
