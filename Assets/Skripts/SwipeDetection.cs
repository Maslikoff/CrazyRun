using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    /// <summary>
    /// Swip
    /// </summary>
    private Vector2 touchStartPos;
    private bool isSwipeRight;

    /// <summary>
    /// Zoom
    /// </summary>
    private Vector2 touchStartPos1;
    private Vector2 touchStartPos2 = new Vector2(150,150);
    private float initialDistance;

    void Update()
    {
        CheckSwip();
        ZoomGesture();
    }

    private void CheckSwip()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                isSwipeRight = false;
            }
            else if (touch.phase == TouchPhase.Moved && !isSwipeRight)
            {
                Vector2 direction = touch.position - touchStartPos;

                if (Mathf.Abs(direction.x) >= 100f && Mathf.Abs(direction.y) <= 50f)
                {
                    if (direction.x > 0f)
                    {
                        isSwipeRight = true;
                        Debug.Log("Swipe вправо");

                        touchStartPos = touch.position;
                    }
                }
            }
        }
    }

    private void ZoomGesture()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began)
            {
                touchStartPos1 = touch1.position;
                touchStartPos2 = touch2.position;
                initialDistance = Vector2.Distance(touchStartPos1, touchStartPos2);
            }
            else if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);

                if (currentDistance >= initialDistance * 1.1f) // Увеличение на 10%
                {
                    Vector2 direction1 = touch1.position - touchStartPos1;
                    Vector2 direction2 = touch2.position - touchStartPos2;

                    if (Vector2.Dot(direction1, direction2) <= 0) // Разнонаправленные изменения
                    {
                        Debug.Log("Жест увеличения");
                    }
                }
            }
        }
    }
}
