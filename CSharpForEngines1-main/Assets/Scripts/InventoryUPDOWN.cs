using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUPDOWN : MonoBehaviour
{

    
    private float transitionSpeed = 5f;
    private bool isMoving = false;
    RectTransform rectTransform;

    private void Awake()
    {
        //Yoink
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // You could probably get away with just clamping the position when the player presses E instead of every frame, but im not smart enough to figure that out
        ClampPosition();

        if (Input.GetKeyDown(KeyCode.E) && isMoving == false)
        {
            StartCoroutine(MoveInventory(200));

        }
        if (Input.GetKeyUp(KeyCode.E) && isMoving == false)
        {
            StartCoroutine(MoveInventory(-200));
        }
        
    }
    // Real men use functions
    void ClampPosition()
    {
        Vector3 currentPosition = rectTransform.anchoredPosition;
        currentPosition.y = Mathf.Clamp(currentPosition.y, -200, 0);

        rectTransform.anchoredPosition = currentPosition;
    }
    // I hate coroutines
    IEnumerator MoveInventory(float yOffset)
    {
        isMoving = true;
        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(startPos.x, startPos.y + yOffset, startPos.z);
        float elapsedTime = 0f;
       

        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime);
            elapsedTime += Time.deltaTime * transitionSpeed;
             yield return null;
        }
       
       
        transform.position = targetPos;
        isMoving = false;
       
    }

}
