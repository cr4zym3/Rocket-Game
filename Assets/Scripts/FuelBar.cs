using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    private float fuelValue;
    public Slider slider;
    public Image fuelBar;
    private PlayerController playerController;
    public Gradient gradient;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        fuelValue = playerController.fuel / 100f;
        slider.value = fuelValue;
        Color color = gradient.Evaluate(fuelValue);
        fuelBar.color = color;
    }
}