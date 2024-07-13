using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HandPinch : MonoBehaviour
{

    [SerializeField] public OVRHand handRightPrefeb;
    [SerializeField] private AudioClip pinchSound;
    [SerializeField] private AudioClip releasesound;
    // Start is called before the first frame update
    public static HandPinch instance;
    public  bool _hasPinched;
    private bool _isIndexFingerPinching;
    private float _pinchStrenghth;
    public GameObject anchorPrefab;
    private OVRHand.TrackingConfidence _confidence;
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPinch(handRightPrefeb);
        
    }
    void CheckPinch(OVRHand hand)
    {
        _pinchStrenghth = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        _isIndexFingerPinching=hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        _confidence=hand.GetFingerConfidence(OVRHand.HandFinger.Index);

        if(!_hasPinched&&_isIndexFingerPinching&&_confidence==OVRHand.TrackingConfidence.High)
        {
           _hasPinched=true;
            Debug.Log("pinched");
            GameObject prefab = Instantiate(anchorPrefab, HandPinch.instance.handRightPrefeb.transform.position, HandPinch.instance.handRightPrefeb.transform.rotation);
            prefab.AddComponent<OVRSpatialAnchor>();

        }
        else if(_hasPinched&&!_isIndexFingerPinching)
        {
            _hasPinched = false;
            Debug.Log("pinched released" );

        }

    }
}
