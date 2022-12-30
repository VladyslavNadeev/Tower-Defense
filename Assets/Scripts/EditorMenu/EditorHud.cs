using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

namespace Assets.Scripts.EditorMenu
{
    public class EditorHud : MonoBehaviour
    {
        [SerializeField]
        private Button _saveButton;
        [SerializeField]
        private Button _quitButton;

        public event Action SaveClicked;
        public event Action QuitGame;

        private void Awake()
        {
            _saveButton.onClick.AddListener(OnSaveButtonClicked);
            _quitButton.onClick.AddListener(OnQuitButtonClicked);
        }

        private async void OnQuitButtonClicked()
        {
            var isConfirmed = await AlertPopup.Instance.AwaitForDecision("Are you sure to quit?");
            if (isConfirmed)
                QuitGame?.Invoke();
        }

        private void OnSaveButtonClicked()
        {
            SaveClicked?.Invoke();
        }
    }
}
