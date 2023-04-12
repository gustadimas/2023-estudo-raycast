using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    float rotationSpeed = 100f;

    [SerializeField] Transform point;

    LayerMask layer;

    private void Start()
    {
        layer = LayerMask.GetMask("Enemy");
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchLayer();
        }

        transform.eulerAngles += new Vector3(0f, 0f, -Input.GetAxis("Horizontal")) * rotationSpeed * Time.deltaTime;

        RayHit();
    }

    void RayHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(point.position, transform.up, 10f, layer);

        if (hit)
        {
            float distance = Vector2.Distance(point.position, hit.point);
            Debug.DrawRay(point.position, transform.up * distance, Color.green);
            Debug.Log(hit.transform.name);

            if (Input.GetKeyDown(KeyCode.K))
            {
                Destroy(hit.collider.gameObject);

                SwitchLayer();
            }
        }
    }

    void SwitchLayer()
    {
        if (layer == LayerMask.GetMask("Water"))
        {
            layer = LayerMask.GetMask("Enemy");
        }
        else
        {
            layer = LayerMask.GetMask("Water");
        }
    }
}
