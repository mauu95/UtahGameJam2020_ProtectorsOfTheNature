using UnityEngine;

public class LayerAdderButton : MonoBehaviour
{

    private void Start()
    {
        if (FindObjectOfType<Tower>().MaxTreeReached())
            gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                FindObjectOfType<Tower>().AddLayer();
                Destroy(gameObject);
            }
        }
    }
}