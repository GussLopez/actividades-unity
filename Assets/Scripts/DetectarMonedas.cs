using UnityEngine;
using UnityEngine.Tilemaps;

public class DetectarMonedas : MonoBehaviour
{
    public Tilemap tilemapCoins;
    public int monedas = 0;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void CambiarColor()
    {
        spriteRenderer.color = Random.ColorHSV(
            0f, 1f,
            0.4f, 1f,
            0.9f, 1f
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != tilemapCoins.gameObject) return;

        RecogerMonedas();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject != tilemapCoins.gameObject) return;

        RecogerMonedas();
    }

    private void RecogerMonedas()
    {
        var colisionador = GetComponent<CircleCollider2D>();

        Bounds bounds = colisionador.bounds;

        Vector3Int min = tilemapCoins.WorldToCell(bounds.min);
        Vector3Int max = tilemapCoins.WorldToCell(bounds.max);

        for (int x = min.x; x <= max.x; x++)
        {
            for (int y = min.y; y <= max.y; y++)
            {
                Vector3Int posicion = new Vector3Int(x, y, 0);

                if (!tilemapCoins.HasTile(posicion)) continue;

                Vector3 centroMoneda = tilemapCoins.GetCellCenterWorld(posicion);
                Vector2 puntoCercano = colisionador.ClosestPoint(centroMoneda);

                float distancia = Vector2.Distance(
                    puntoCercano,
                    centroMoneda
                );

                if (distancia > .01f) continue;

                tilemapCoins.SetTile(posicion, null);
                monedas++;
                CambiarColor();
                Debug.Log("Monedas recogidas: " + monedas);
            }
        }
    }
}
