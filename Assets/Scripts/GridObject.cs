using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    public void OnBulletCollision()
    {
        Destroy(gameObject);
    }
}
