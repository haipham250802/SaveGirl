using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxElement : MonoBehaviour
{
    public SpriteRenderer IconBox;
    public SpriteRenderer Arrow;
    public BoxController BoxController;
    public void SetColorBox(Color color)
    {
        IconBox.color = color;
    }
}
