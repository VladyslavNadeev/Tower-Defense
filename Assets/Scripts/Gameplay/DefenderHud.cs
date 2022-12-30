using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.Scripts.Loading;

public class DefenderHud : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _wavesText;

    [SerializeField]
    private TextMeshProUGUI _playerHealthText;

    [SerializeField]
    private ToggleWithSpriteSwap _pauseToggle;

    [SerializeField]
    private Button _quitButton;

    public event Action QuitGame;

    private void Awake()
    {
        _pauseToggle.ValueChanged += OnPauseClicked;
        _quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    public void UpdatePlayerHealth(float currentHp, float maxHp)
    {
        _playerHealthText.text = $"{(int)(currentHp / maxHp * 100)}%";
    }

    public void UpdateScenarioWaves(int currentWave, int wavesCount)
    {
        _wavesText.text = $"{currentWave}/{wavesCount}";
    }

    private async void OnQuitButtonClicked()
    {
        OnPauseClicked(true);
        var isConfirmed = await AlertPopup.Instance.AwaitForDecision("Are you sure to quit?");
        OnPauseClicked(false);
        if (isConfirmed)
        {
            QuitGame?.Invoke();
        }
    }

    private void OnPauseClicked(bool isPaused)
    {
        ProjectContext.Instance.PauseManager.SetPaused(isPaused);
    }

    private void OnDestroy()
    {
        _pauseToggle.ValueChanged -= OnPauseClicked;
    }
}
