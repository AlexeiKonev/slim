using UnityEngine;
namespace Slime {
    public class Game : MonoBehaviour {
        public GameObject playerObject;
        Vector3 direction;
        Transform nextPlayerTransform;


        void AutoMoving(Transform playertransform) {
            playertransform.Translate(direction, nextPlayerTransform);

        }
    }
}
