using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Animator KnifeAnimator;
    public bool IsCutting;
    private Rect screenBounds;
    public float TimeElapsed = 0f;
    private float ClickTimeFrame = 0.15f;
    

    void Start()
    {
        screenBounds = new Rect(0, 0, Screen.width, Screen.height - 200);
    }

    public void SetCuttingState(bool state)
    {
        IsCutting = state;
        KnifeAnimator.SetBool("IsCutting", state);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && screenBounds.Contains(Input.mousePosition) && !IsCutting)
        {
            TimeElapsed = 0f;
            SetCuttingState(true);
        }
        if (IsCutting)
        {
            TimeElapsed += Time.fixedDeltaTime;
            if (TimeElapsed >= ClickTimeFrame)
            {
                SetCuttingState(false);
                TimeElapsed = 0f;
            }
        }
    }
}
