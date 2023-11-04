using System.Collections;
using UnityEngine;

public class SlashController : MonoBehaviour
{
    public float xPositionOffset;
    public float yPositionOffset;
    private Transform player;

    void Start()
    {
        this.SetItUp();
    }

    void Update()
    {
        this.UpdateCurrentPosition();
    }

    void OnEnable()
    {
        this.SetItUp();
    }

    protected void SetItUp()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        this.UpdateCurrentPosition();
        StartCoroutine(DelayExecution(0.05f));
    }
    private void UpdateCurrentPosition()
    {
        Vector2 position = new Vector2(
            player.position.x + this.xPositionOffset,
            player.position.y + this.yPositionOffset
        );
        this.transform.position = position;
    }

    private IEnumerator DelayExecution(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false);
    }

}
