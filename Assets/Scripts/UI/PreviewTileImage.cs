using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreviewTileImage : MonoBehaviour
{


    private TileGridInteraction tileGridInteraction;
    private int tileIndex;
    [SerializeField]private TextMeshProUGUI previewText;
    private Image previewTileImage;
    public Sprite[] previewSprite;
    

    // Start is called before the first frame update
    void Start()
    {
        previewText = GetComponentInChildren<TextMeshProUGUI>();
        previewTileImage = GetComponent<Image>();
        tileGridInteraction = GameObject.FindGameObjectWithTag("TilemapManager").GetComponent<TileGridInteraction>();
        tileIndex = tileGridInteraction.selectedTileIndex;
        previewTileImage.sprite = previewSprite[tileIndex];
    }



    // Update is called once per frame
    void LateUpdate()
    {
        if (tileIndex != tileGridInteraction.selectedTileIndex)
        {
            tileIndex = tileGridInteraction.selectedTileIndex;
            previewText.text = Enum.GetName(typeof(Tiles.TileType), tileIndex);
            previewTileImage.sprite = previewSprite[tileIndex];
        }

        if (tileGridInteraction.rotatePreview)
        {
            tileGridInteraction.rotatePreview = false;
            previewTileImage.rectTransform.rotation = Quaternion.identity;
            previewTileImage.transform.Rotate(0, 0, 90 * tileGridInteraction.rotValue);
        }
    }
}
