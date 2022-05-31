using UnityEngine;
using UnityEngine.UI;
using UI.Dialogs;
using UnityEngine.SceneManagement;


namespace GameManagerSpace
{
    //separate class for static var to show best score after multiple games
    public class ApplicationModel
    {
        public static int bestScore = 0;
    }
    public class GameManager : MonoBehaviour
    {
        int Score;

        //singelton for game manager to use across scripts
        public static GameManager inst;

        int Lives=3;

        [SerializeField] Player_Control playerControl;
        [SerializeField] UIManager manager;

        [SerializeField] Text textScore;
        [SerializeField] Text bestScore;
        [SerializeField] Text textLives;


        private void Awake()
        {
            inst = this;

            playerControl = GameObject.FindObjectOfType<Player_Control>();
            //UI manager to display best score
            manager = GameObject.FindObjectOfType<UIManager>();
            bestScore.text = "Best Score: " + ApplicationModel.bestScore;
            //UIManager.inst.Show();
            manager.Show();
        }

        //function to increment score and gradually change speed depending on the score
        public void IncrementScore()
        {
            Score++;
            textScore.text = "Score: " + Score;
      
            switch (Score)
            {
                case 10:
                    playerControl.speedIncrVal = 1.5f;
                    playerControl.StartCoroutine(playerControl.speedIncrease());
                    break;
                case 25:
                    playerControl.speedIncrVal = 2f;
                    playerControl.StartCoroutine(playerControl.speedIncrease());
                    break;
                case 50:
                    playerControl.speedIncrVal = 3f;
                    playerControl.StartCoroutine(playerControl.speedIncrease());
                    break;
                case 100:
                    playerControl.speedIncrVal = 4f;
                    playerControl.StartCoroutine(playerControl.speedIncrease());
                    break;
                default:
                    break;
            }
        }

        //decreasing lives and setting best score before reloading scene if dead
        public void DecrementLives()
        {
            Lives--;
            textLives.text = "Lives: " + Lives;

            if (ApplicationModel.bestScore <=Score)
            {
                ApplicationModel.bestScore = Score;
            }

            if (Lives==0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           
            }
        }

        

    }
}
