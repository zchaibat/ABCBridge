using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class AnchorPoint : MonoBehaviour
{
    public List<Bar> ConnectedBars = new List<Bar>();
    public bool Runtime = true;

    private void Update()
    {
        if (Runtime == false)
        {
            if (transform.hasChanged == true)
            {
                transform.hasChanged = false;
                transform.position = Vector3Int.RoundToInt(transform.position);
            }
        }
    }
}

