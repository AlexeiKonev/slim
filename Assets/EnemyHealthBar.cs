using UnityEngine;
using UnityEngine.UI;
namespace Slime {
    public class EnemyHealthBar : MonoBehaviour {
        [SerializeField] private Slider slider;
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Vector3 offset;

        private void Update() {
            transform.position = Camera.main.WorldToScreenPoint(targetTransform.position + offset);
        }

        public void SetHealth(float health, float maxHealth) {
            slider.value = health;
            slider.maxValue = maxHealth;
        }
    }

}

