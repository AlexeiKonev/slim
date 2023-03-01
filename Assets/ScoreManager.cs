using UnityEngine;

using UnityEngine.UI;
namespace Slime {
    public class ScoreManager : MonoBehaviour {
        public static ScoreManager instance;

        public int score;
        public Text scoreText;

        private void Awake() {
            if (instance == null) {
                instance = this;
            }
            else {
                Destroy(gameObject);
            }
        }

        public void AddScore(int points) {
            score += points;
            scoreText.text = "Score: " + score.ToString();
        }
    }

}
