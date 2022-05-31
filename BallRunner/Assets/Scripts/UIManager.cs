using UnityEngine;
using UnityEngine.UI;

namespace UI.Dialogs
{
    //UI class
    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject canvas;
        [SerializeField] Button PlayButton;
        [SerializeField] Button QuitButton;

        //singelton for UI manager to use across scripts
        public static UIManager inst;

        
        private void Awake()
        {
            inst = this;

            //pausing game while UI runs
            Time.timeScale = 0;

            PlayButton.onClick.RemoveAllListeners();
            PlayButton.onClick.AddListener(Hide);

            QuitButton.onClick.AddListener(Quit);
        }

        //quit button
        private void Quit()
        {
            Application.Quit();
        }

        //show and hide UI
        public void Show()
        {
            if (canvas!=null)
            {
                canvas.SetActive(true);
            }
        }

        public void Hide()
        {
            canvas.SetActive(false);
            Time.timeScale = 1;
            
        }
    }
}
