using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;
using UnityEngine.UI;
using System;

public class BridgeManager : MonoBehaviour
{
    public static BridgeManager instance;
    public GameObject vlpTemplate;

    public Transform container;

    public float deltaTime = 0f;
    public int index = 0;

    public GameObject Main;
    public SliderManager zoomSlider;

    public Color back_color;
    public Color vlp_color;
    public Color cabin_color;

    public bool isStart = false;

    public int tickCounter = 0;


    // Start is called before the first frame update
    void Awake(){
        instance = this;

        Screen.fullScreen = false;
        Screen.SetResolution(1680, 1188, FullScreenMode.Windowed, 24);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError(Screen.width.ToString() + "," + Screen.height.ToString());
        //create wlps every 1 second
        if(isStart){
            deltaTime += Time.deltaTime;
            int nowIndex = (int)(deltaTime);
            if(nowIndex > index){
                // Debug.LogError("insert:" + deltaTime);
                index = nowIndex;

                CreatePoints();
            }

            if(deltaTime >= 30f){
                float alpha = deltaTime - 30f;
                if(alpha > 1f) alpha = 1f;
                cabin_color = new Color(cabin_color.r, cabin_color.g, cabin_color.b, alpha);
            }

            if(deltaTime >= 60f){
                float alpha = 61f - deltaTime;
                if(alpha < 0f) alpha = 0f;
                vlp_color = new Color(vlp_color.r, vlp_color.g, vlp_color.b, alpha);
            }

            if(deltaTime >= 90f){
                float val = 1 + (deltaTime - 90f) / 15f;
                if(val > 2f) val = 2f;
                Main.transform.localScale = Vector3.one * val;
                zoomSlider.mainSlider.value = val - 1f;
            }
        }
    }
    //control zooming
    public void OnZoomChange(){
        float val = 1 + zoomSlider.mainSlider.value;
        Main.transform.localScale = Vector3.one * val;
    }
    //create wlps
    void CreatePoints(){
        tickCounter ++;

        for(int i = 0; i < 8; i ++){
            GameObject obj = (GameObject)Instantiate(vlpTemplate, container);
            VLPMovement vlp = obj.GetComponent<VLPMovement>();
            List<PositionInfo> baseTable = new List<PositionInfo>();
            bool direction = false;
            bool show_cabin = false;

            switch(i) {
            case 0:
                baseTable = CommonFuns.bridge_a;
                direction = false;
                break;
            case 1:
                baseTable = CommonFuns.bridge_b;
                direction = false;
                break;
            case 2:
                baseTable = CommonFuns.bridge_c;
                direction = false;
                break;
            case 3:
                baseTable = CommonFuns.bridge_d;
                direction = false;
                break;
            case 4:
                baseTable = CommonFuns.bridge_e;
                direction = true;
                break;
            case 5:
                baseTable = CommonFuns.bridge_f;
                direction = true;
                break;
            case 6:
                baseTable = CommonFuns.bridge_g;
                direction = true;
                break;
            case 7:
                baseTable = CommonFuns.bridge_h;
                direction = true;
                break;
            }

            if(UnityEngine.Random.Range(0, 100) < 20){
                show_cabin = true;
            }

            vlp.InitBridgePoses(baseTable, direction, show_cabin);
        }
    }

    public void OnStart(){
        isStart = true;
    }
}
