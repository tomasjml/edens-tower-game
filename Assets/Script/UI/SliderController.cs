using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Text label;

    public void increase(float value)
    {
        GetComponent<Slider>().value += value;
        value = GetComponent<Slider>().value * 100;
        label.text = value.ToString();
    }

    public void decrease(float value)
    {
        GetComponent<Slider>().value -= value;
        value = GetComponent<Slider>().value * 100;
        label.text = value.ToString();
    }
}
