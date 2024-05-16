using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class tilemapShadowCasterTesla : MonoBehaviour
{
    public static tilemapShadowCasterTesla Instance;

    public GameObject sc;
    public Tilemap tilemap;

    private List<GameObject> shadowCasters = new List<GameObject>(), toDelete = new List<GameObject>();

    public void Start()
    {
        Instance = this;

        int i = 0;
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.GetTile(position) == null)
                continue;
            if (tilemap.GetColliderType(position) != Tile.ColliderType.Grid)
                continue;
            if (position.x != 0 || position.x != 0)
            {
                GameObject shadowCaster = GameObject.Instantiate(sc, gameObject.transform);
                shadowCaster.transform.position = new Vector3((position.x + 0.5f), (position.y + 0.5f), 0);
                shadowCaster.name = "shadow_caster_" + i;
                i++;
            }
        }
    }
}