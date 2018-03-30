using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour {

    public List<Camera> _cameras;
    //public Camera cameraA;
    //public Camera cameraB;
    //public Camera cameraC;

    public List<Material> _cameraMat;
    //public Material cameraMatB;
    //public Material cameraMatA;
    //public Material cameraMatC;

    // Use this for initialization
    void Start ()
    {
        for (int n=0; n<_cameras.Count; n++)
        {
            if (_cameras[n].targetTexture != null)
            {
                _cameras[n].targetTexture.Release();
            }
            _cameras[n].targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            _cameraMat[n].mainTexture = _cameras[n].targetTexture;
        }

        //if (cameraA.targetTexture != null)
        //{
        //    cameraA.targetTexture.Release();
        //}
        //if (cameraB.targetTexture != null )
        //{
        //    cameraB.targetTexture.Release();
        //}

        //cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        //cameraMatA.mainTexture = cameraA.targetTexture;
        //cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        //cameraMatB.mainTexture = cameraB.targetTexture;
	}
	
}
