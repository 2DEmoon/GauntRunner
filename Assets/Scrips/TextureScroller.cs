using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroller : MonoBehaviour
{
	public float speed = 2f;

	Renderer tmpRenderer;
	float offset;
    // Start is called before the first frame update
    void Start()
    {
        tmpRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed;

        if (offset > 1)
        	offset -= 1;
        tmpRenderer.material.mainTextureOffset = new Vector2(0, offset);
    }
}
