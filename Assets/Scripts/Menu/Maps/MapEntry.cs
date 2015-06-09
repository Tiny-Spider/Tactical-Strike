using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapEntry : MonoBehaviour {
    public Image mapImage;
    public Text mapInfo;
    public Image background;

    private MapDisplayer mapDisplayer;
    private MapData map;

    public void Initalize(MapDisplayer mapDisplayer, MapData map) {
        this.mapDisplayer = mapDisplayer;
        this.map = map;

        mapImage.sprite = map.image;
        mapInfo.text = map.GetInfo();
    }

    public void SelectMap() {
        NetworkHandler networkHandler = NetworkHandler.instance;
        networkHandler.ChangeMap(map);
    }

    public void ClosePopup() {
        mapDisplayer.ClosePopup();
    }

    public void SetColor(Color color) {
        background.color = color;
    }
}
