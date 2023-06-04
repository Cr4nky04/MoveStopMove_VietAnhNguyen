using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MissionWaypoint : GameUnit
{
    public Player player;
    public GameObject image;
    public Image Indicator;
    public GameObject Original;
    public Transform target;
    public UnityEngine.Vector2 imageSize;
    public UnityEngine.Vector3 offset;
    public Vector3 direction;
    public Image arrow;
    public Image Name;
    public TMP_Text PointDisplay;   
    public TMP_Text NameDisplay;
    public int Point;

    private void Update()
    {
        float minX = imageSize.x / 2 + 100f;
        float minY = imageSize.y / 2 + 100f;

        float maxX = Screen.width - minX - 50f;
        float maxY = Screen.height - minY - 50f;
        Vector3 pos = Camera.main.WorldToScreenPoint(target.position + offset);
        if (pos.z < 0)
        {
            pos.y = Screen.height - pos.y;
            pos.x = Screen.width - pos.x;
        }
        if (pos.x < maxX && pos.x > minX && pos.y < maxY && pos.y > minY)
        {
            arrow.gameObject.SetActive(false);
            Name.gameObject.SetActive(true);
        }
        else
        {
            arrow.gameObject.SetActive(true);
            Name.gameObject.SetActive(false);
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = 0;
        RotateArrow(pos.x, pos.y);

        image.transform.position = pos;
        Indicator.transform.position = pos;
        Name.transform.position = pos;  
    }
    public override void OnInit()
    {

    }
    public override void OnDespawn()
    {
        gameObject.SetActive(false);
    }

    public void RotateArrow(float x, float y)
    {
        Vector2 centerPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Vector2 target = new Vector2(x, y);
        Vector2 direction = target - centerPoint;
        Vector2 defualtdirection = new Vector2(1f, 0f);
        float angle = Vector2.Angle(defualtdirection, direction);
        Vector3 cross = Vector3.Cross(defualtdirection, direction);
        if (cross.z < 0) angle = -angle;
        Original.transform.rotation = UnityEngine.Quaternion.Euler(0f, 0f, angle);
    }

    public void ShowPoint(int point)
    {
        PointDisplay.text = point.ToString();
    }

    public void ShowName(string name)
    {
        NameDisplay.text = name;
    }

}
