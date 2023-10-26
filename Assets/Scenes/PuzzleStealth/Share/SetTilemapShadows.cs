using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class SetTilemapShadows : MonoBehaviour
{
    public static SetTilemapShadows Instance;

    private CompositeCollider2D tilemapCollider;
    private GameObject shadowCasterContainer;
    private List<GameObject> shadowCasters = new List<GameObject>(), toDelete = new List<GameObject>();
    private List<PolygonCollider2D> shadowPolygons = new List<PolygonCollider2D>();
    private List<UnityEngine.Rendering.Universal.ShadowCaster2D> shadowCasterComponents = new List<UnityEngine.Rendering.Universal.ShadowCaster2D>();
    private GameObject sc;
    private Tilemap tilemap;

    public void Start()
    {
        sc = GameObject.Find("tilemapshadow");
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        Instance = this;
        tilemapCollider = GetComponent<CompositeCollider2D>();
        shadowCasterContainer = GameObject.Find("shadow_casters");
        int i = 0;
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.GetTile(position) == null)
                continue;
            if (position.x != 0 || position.x != 0)
            {
            GameObject shadowCaster = GameObject.Instantiate(sc, shadowCasterContainer.transform);
            shadowCaster.transform.position = new Vector3((position.x + 0.5f), (position.y + 0.5f), 0);
            shadowCaster.name = "shadow_caster_" + i;
            i++;
            }
        }
    }
}