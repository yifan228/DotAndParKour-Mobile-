using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCrack : MonoBehaviour
{
    void CreatSprite(Color c, List<Vector2> area)
    {
        //if (area.Count <= 0) return;
        //int minX = (int)area[0].x;
        //int minY = (int)area[0].y;
        //int maxX = (int)area[0].x;
        //int maxY = (int)area[0].y;
        //for (int i = 1; i < area.Count; i++)
        //{
        //    if (area[i].x < minX) minX = (int)area[i].x;
        //    if (area[i].x > maxX) maxX = (int)area[i].x;
        //    if (area[i].y < minY) minY = (int)area[i].y;
        //    if (area[i].y > maxY) maxY = (int)area[i].y;
        //}
        //int textureWidth = maxX - minX + 1;
        //int textureHeight = maxY - minY + 1;
        //Vector2 center = new Vector2((maxX + minX) / 2f, (maxY + minY) / 2f);
        //colorToCenter.Add(c, Camera.main.ViewportToWorldPoint(new Vector3(center.x / _screenWidth, center.y / _screenHeight, Camera.main.nearClipPlane + 1)));
        //Color[] initColor = new Color[textureWidth * textureHeight];
        //for (int i = 0; i < initColor.Length; i++)
        //{
        //    initColor[i] = new Color(0f, 0f, 0f, 0f);
        //}
        //Texture2D spriteTexture = new Texture2D(textureWidth, textureHeight, TextureFormat.ARGB32, false);
        //spriteTexture.SetPixels(initColor);
        //GameObject spriteObj = new GameObject();
        //spriteObj.transform.localScale = new Vector3(spriteScale, spriteScale, 1f);
        //spriteObj.transform.SetParent(transform);
        //colorToTrans.Add(c, spriteObj.transform);
        //SpriteRenderer sr = spriteObj.AddComponent<SpriteRenderer>();
        //sr.sortingOrder = 100;
        //colorToSprite.Add(c, sr);
        //colorToBasePoint.Add(c, new Vector2(minX, minY));
        //colorToSize.Add(c, new Vector2(textureWidth, textureHeight));
        //spriteObj.SetActive(false);
    
    }
}
