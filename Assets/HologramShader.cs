using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramShader : MonoBehaviour
{

    public Material hologrammat;
    public Vector2 initialtiling;
    // Update is called once per frame
    private void Awake()
    {
        hologrammat.SetVector("_Hologram_texture_Tiling", initialtiling);
    }
    void Update()
    {
       Vector2 tiling  = hologrammat.GetVector("_Hologram_texture_Tiling");

        hologrammat.SetVector("_Hologram_texture_Tiling", new Vector2(initialtiling.x, initialtiling.y /( GameSettings.GetScaleMultiplier()) ));
    }
}
