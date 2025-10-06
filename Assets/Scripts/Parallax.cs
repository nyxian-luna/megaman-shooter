using System;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float moveSpeed;
    public bool scrollLeft;

    private float _initialXPosition;
    private float _singleTextureWidth;
    
    void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        _singleTextureWidth = sprite.texture.width / sprite.pixelsPerUnit;
        _initialXPosition = transform.position.x;
        if (scrollLeft)
        {
            moveSpeed = -moveSpeed;
        }
    }

    void Update()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        if (Mathf.Abs(transform.position.x - _initialXPosition) - _singleTextureWidth > 0)
        {
            transform.position = new Vector3(_initialXPosition, transform.position.y, transform.position.z);
        }
    }
}
