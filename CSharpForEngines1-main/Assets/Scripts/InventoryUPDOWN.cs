using System.Collections;
using UnityEngine;


public class InventoryUpdown : MonoBehaviour
{
    private const float TransitionSpeed = 10f;
    private bool _isMoving;
    private RectTransform _rectTransform;

    private void Awake()
    {
        //Yoink
        _rectTransform = GetComponent<RectTransform>();
    }


    

    private void Update()
    {
        // You could probably get away with just clamping the position when the player presses E instead of every frame, but im not smart enough to figure that out
        ClampPosition();

        if (Input.GetKeyDown(KeyCode.E) && _isMoving == false)
        {

            StartCoroutine(MoveInventory(200));

        }
        if (Input.GetKeyUp(KeyCode.E) && _isMoving == false)
        {
            StartCoroutine(MoveInventory(-200));
        }
        
    }

    private void ClampPosition()
    {
        Vector3 currentPosition = _rectTransform.anchoredPosition;
        currentPosition.y = Mathf.Clamp(currentPosition.y, 200, 300);

        _rectTransform.anchoredPosition = currentPosition;
    }

    private IEnumerator MoveInventory(float y)
    {
        _isMoving = true;
        var startPos = transform.position;
        var targetPos = new Vector3(startPos.x, startPos.y + y, startPos.z);
        var elapsedTime = 0f;
       

        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime);
            elapsedTime += Time.deltaTime * TransitionSpeed;
             yield return null;
        }
       
       
        transform.position = targetPos;
        _isMoving = false;
       
    }

}
