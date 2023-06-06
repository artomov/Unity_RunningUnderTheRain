using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlsUI : MonoBehaviour
{
    [SerializeField] private DropCounter _dropCounter;
    [Space]
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Slider _speedSlider;
    [SerializeField] private TextMeshProUGUI _speedSliderText;
    [SerializeField] private TextMeshProUGUI _dropCountText;
    [SerializeField] private TextMeshProUGUI _dropCountTextPrevious;

    void Start()
    {
        _startButton.onClick.AddListener(StartButton_OnClick);
        _resetButton.onClick.AddListener(ResetButton_OnClick);
        _speedSlider.onValueChanged.AddListener(SpeedSlider_OnValueChanged);
        _dropCounter.OnDropCountChanged += DropCounter_OnDropCountChanged;

        // Initial invokes
        DropCounter_OnDropCountChanged(0, 0); 
        SpeedSlider_OnValueChanged(_speedSlider.value);
    }

    private void StartButton_OnClick()
    {
        GameManager.Instance.SetShouldMove(true);
    }

    private void ResetButton_OnClick()
    {
        GameManager.Instance.ResetGame();
    }
    
    private void SpeedSlider_OnValueChanged(float value)
    {
        _speedSliderText.text = $"Guy speed: {((int)value)} km/h";
        GameManager.Instance.SetGuySpeed_kmh(value);
    }


    private void DropCounter_OnDropCountChanged(int dropCount, int dropCountPrevious)
    {
        _dropCountText.text = $"Drops count: {dropCount}";
        _dropCountTextPrevious.text = $"Previous: {dropCountPrevious}";
    }

}
