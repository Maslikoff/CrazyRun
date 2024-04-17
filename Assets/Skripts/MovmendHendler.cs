using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmendHendler : MonoBehaviour
{
    public InputHendler InputHendler;
    [SerializeField] private float ballSpeed;

    void Start()
    {
        if (InputHendler == null)
            Debug.LogError("Input Hendler не назначен!");
    }

    void Update()
    {
        MoveBall();
    }

    private void MoveBall()
    {
        if (InputHendler.IsThereTouchOnScreen())
        {
            Vector2 currDeltaPos = InputHendler.GetTouchDeltaPosition();
            currDeltaPos = currDeltaPos * ballSpeed;
            Vector3 newGravityVector = new Vector3((currDeltaPos.y)*-1, Physics.gravity.y, currDeltaPos.x);
            Physics.gravity = newGravityVector;
        }
    }
}
