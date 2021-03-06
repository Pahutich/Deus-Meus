using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Transform playerPosition;
    private Transform targetTileTransform;
    private Tile targetTileInfo;
    public Transform initialTileTransform;
    void Start()
    {
        targetTileTransform = initialTileTransform;
        playerPosition = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                targetTileTransform = hit.transform;
                if (targetTileTransform != null && targetTileTransform.CompareTag("Tile"))
                {
                    targetTileInfo = hit.collider.gameObject.GetComponent<Tile>();
                    Move();
                }
            }
        }
            
    }
     void Move()
    {
        if(targetTileTransform != null && targetTileInfo.isWalkable == true)
        {
            this.transform.position = targetTileTransform.position + new Vector3(0, 0.6f, 0);
        }
    }
}
