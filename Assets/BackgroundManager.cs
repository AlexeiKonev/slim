using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Slime {
public class BackgroundManager : MonoBehaviour {
    public Transform player;
    public SpriteRenderer background;
    public Sprite dayBackground;
    public Sprite nightBackground;
    public float threshold = 10f;

    private bool isDay = true;

    void Update() {
        // Проверяем расстояние между позицией игрока и позицией фона
        float distance = Mathf.Abs(player.position.z - transform.position.z);

        // Если расстояние больше, чем пороговое значение, то меняем задний план
        if (distance > threshold) {
            isDay = !isDay;
            if (isDay) {
                background.sprite = dayBackground;
            }
            else {
                background.sprite = nightBackground;
            }
            // Обновляем позицию фона, чтобы он оставался за игроком
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}
}

