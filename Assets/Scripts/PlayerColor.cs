using UnityEngine;
using System.Collections;

public class PlayerColor {
    private static PlayerColor[] colors = new PlayerColor[] {
        new PlayerColor(Color.blue, 0),
        new PlayerColor(Color.red, 1)
    };
    
    public Color color { private set; get; }
    public int id { private set; get; }

    public PlayerColor(Color color, int id) {
        this.color = color;
        this.id = id;
    }

    public static PlayerColor GetColor(int id) {
        if (id < colors.Length) {
            return colors[id];
        }

        return null;
    }

    public static PlayerColor[] Values() {
        return colors;
    }
}
