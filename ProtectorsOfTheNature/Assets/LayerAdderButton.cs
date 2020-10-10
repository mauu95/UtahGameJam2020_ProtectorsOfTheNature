using UnityEngine;

public class LayerAdderButton : MonoBehaviour
{
    [Tooltip("Set the maximum height of the tower")][SerializeField] [Range(1, 6)] private int maxLayer;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                FindObjectOfType<Tower>().addLayer();
                Destroy(gameObject);
            }
        }
    }
}