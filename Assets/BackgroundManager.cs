using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {
    public Transform player;
    public SpriteRenderer background;
    public Sprite dayBackground;
    public Sprite nightBackground;
    public float threshold = 10f;

    private bool isDay = true;

    void Update() {
        // ��������� ���������� ����� �������� ������ � �������� ����
        float distance = Mathf.Abs(player.position.z - transform.position.z);

        // ���� ���������� ������, ��� ��������� ��������, �� ������ ������ ����
        if (distance > threshold) {
            isDay = !isDay;
            if (isDay) {
                background.sprite = dayBackground;
            }
            else {
                background.sprite = nightBackground;
            }
            // ��������� ������� ����, ����� �� ��������� �� �������
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}
