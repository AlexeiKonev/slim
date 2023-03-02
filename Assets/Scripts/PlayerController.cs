using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Slime {
    public class PlayerController : MonoBehaviour {
        public float speed = 10.0f; // скорость перемещения

        void Update() {
            if (Input.GetKey(KeyCode.W)) {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }
}
