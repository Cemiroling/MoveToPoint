using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    [SerializeField] private BallMoving ball;
    [SerializeField] private Slider slider;

    void Start()
    {
        ball.SetSpeed(slider.value);
    }
    
    public void OnSpeedValue(float speed)
    {
        ball.SetSpeed(speed);
    }
}
