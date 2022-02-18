using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSpriteManager : MonoBehaviour
{
    [SerializeField]
    List<CharSprite> charSprites = new List<CharSprite>();

    private void Start()
    {
        LoadIntoList();
    }
    void LoadIntoList()
    {
        CharSprite[] loadedRes = Resources.FindObjectsOfTypeAll<CharSprite>();

        foreach (CharSprite sprite in loadedRes)
        {
            Debug.Log(sprite.name);
            charSprites.Add(sprite);
        }

    }
}
