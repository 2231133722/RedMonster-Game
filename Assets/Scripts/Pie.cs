using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pie : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lives.Instance.ExtraLife();
        Score.Instance.AddPie();
        Destroy(this.gameObject, 0.2f);
    }
}
