using UnityEngine;
using UnityEngine.UI;

namespace Slime {


    public class HealthBar : MonoBehaviour {
        public Slider slider;

        public void SetMaxHealth(int maxHealth) {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;
        }

        public void SetHealth(int health) {
            slider.value = health;
        }
    }

}