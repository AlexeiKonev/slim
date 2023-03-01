using UnityEngine;
using UnityEngine.UI;
namespace Slime {


    public class DamageText : MonoBehaviour {
        public float moveSpeed = 2f;
        public float destroyTime = 2f;

        private Text damageText;

        private void Awake() {
            damageText = GetComponent<Text>();
        }

        void Update() {
            transform.position += new Vector3(0f, moveSpeed * Time.deltaTime, 0f);
            Destroy(gameObject, destroyTime);
        }

        public void SetText(int damageAmount) {
            damageText.text = "-" + damageAmount.ToString();
        }
    }

}