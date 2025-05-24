using System.Collections.Generic;
using UnityEngine;

public class AnchorPoint : MonoBehaviour
{
    public List<Bar> ConnectedBars = new List<Bar>();
    public bool Runtime = true;

    private void Update()
    {
        if (!Runtime && transform.hasChanged)
        {
            transform.hasChanged = false;
            transform.position = Vector3Int.RoundToInt(transform.position);
        }
    }
}
