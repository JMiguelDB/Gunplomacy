using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAsalto : MonoBehaviour
{
    public Sprite cursorTexture;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture.texture, Vector2.zero, CursorMode.Auto);
    }

    private void OnDestroy()
    {
        Cursor.SetCursor(cursorTexture.texture, Vector2.zero, CursorMode.Auto);
    }
}
