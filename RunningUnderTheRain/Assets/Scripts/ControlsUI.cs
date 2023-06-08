using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlsUI : MonoBehaviour
{
    [SerializeField] private DropCounter _dropCounter;

    [Space]

    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _resetButton;

    [Space]
    [SerializeField] private Slider _speedSlider;
    [SerializeField] private TextMeshProUGUI _speedSliderText;
    [SerializeField] private Slider _angleSlider;
    [SerializeField] private TextMeshProUGUI _angleSliderText;
    [SerializeField] private TextMeshProUGUI _angleSliderComentText;
    
    [Space]
    [SerializeField] private TextMeshProUGUI _dropCountText;
    [SerializeField] private TextMeshProUGUI _dropCountTextPrevious;

    public float GuyAngle {get; private set;}

    void Start()
    {
        _startButton.onClick.AddListener(StartButton_OnClick);
        _quitButton.onClick.AddListener(QuitButton_OnClick);
        _resetButton.onClick.AddListener(ResetButton_OnClick);
        _speedSlider.onValueChanged.AddListener(SpeedSlider_OnValueChanged);
        _angleSlider.onValueChanged.AddListener(AngleSlider_OnValueChanged);
        _dropCounter.OnDropCountChanged += DropCounter_OnDropCountChanged;

        // Initial invokes
        DropCounter_OnDropCountChanged(0, 0); 
        SpeedSlider_OnValueChanged(_speedSlider.value);
        AngleSlider_OnValueChanged(_angleSlider.value);
    }

    private void QuitButton_OnClick()
    {
        Application.Quit();
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

    private void AngleSlider_OnValueChanged(float value)
    {
        GuyAngle = value;
        _angleSliderText.text = $"Guy angle: {((int)value)}°";
        GameManager.Instance.SetGuyAngle(value);
        ManageAngleSliderComment(value);
    }

    private void ManageAngleSliderComment(float angle)
    {
        if (angle <= - 70)
        {
            _angleSliderComentText.text = "(Reversed Superman)";
        }
        else if(angle > - 70 && angle <= - 40)
        {
            _angleSliderComentText.text = "(Yeah, I'd like to see you running like that!)";
        }
        else if(angle > - 40 && angle <= - 10)
        {
            _angleSliderComentText.text = "(Is there something interesting in the sky?)";
        }
        else if(angle > 10 && angle <= 40)
        {
            _angleSliderComentText.text = "(Running really hard)";
        }
        else if(angle > 40 && angle <= 70)
        {
            _angleSliderComentText.text = "(Naruto)";
        }
        else if(angle > 70)
        {
            _angleSliderComentText.text = "(Superman sniffing the ground)";
        }
        else 
        {
            _angleSliderComentText.text = "";
        }
         
    }


    private void DropCounter_OnDropCountChanged(int dropCount, int dropCountPrevious)
    {
        _dropCountText.text = $"Drops count: {dropCount}";
        _dropCountTextPrevious.text = $"Previous: {dropCountPrevious}";
    }

}
