using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpatialAnchorManager : MonoBehaviour
{
    // Start is called before the first frame update
    public OVRSpatialAnchor anchorPrefab;
    private Canvas canvas;
    private TextMeshProUGUI uuidText;
    private TextMeshProUGUI savedStatusText;
    private List<OVRSpatialAnchor> anchors = new List<OVRSpatialAnchor>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
