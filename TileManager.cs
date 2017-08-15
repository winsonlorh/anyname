using UnityEngine;
using Assets.Helpers;
using System;
using System.Collections;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private Settings _settings;

    [SerializeField]
    private Texture2D texture;
    private GameObject tile;

    private float lat, lon;

    IEnumerator Start {
         while (!Input.location.isEnabledByUser){
            yield return new waitForSeconds(1f);
        }
        Input.location.Start(10f, 5f);

        int maxWait = 20;
        while(Input.location.status ==LocationServiceStatus.Initializing && maxWait>0){
            yield return new waitForSeconds(1f);
            maxWait--;
        }
        if(maxWait<1)
            yield break;
        if(Input.location.status==LocationServiceStatus.Failed)
            yield break;
        else{
            lat=Input.location.lastData.latitude;
            lon=Inut.location.lastData.longitude;
        }
	}

    void update
    {

    }
    [Serializable]
    public class Settings
    {
        [SerializeField]
        public Material material;
        [SerializeField]
        public int zoom = 18f;
        [SerializeField]
        public int size = 640;
        [SerializeField]
        public float scale = 1f;
        [SerializeField]
        public string key;
        [SerializeField]
        public string style = "emerald";
    }
}
