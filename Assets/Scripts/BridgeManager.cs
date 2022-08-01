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

    public List<Color> bridgeCabinColors;
    public int cabinColorIndex = 0;


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

            if(deltaTime >= 45f){
                float alpha = deltaTime - 45f;
                if(alpha > 1f) alpha = 1f;
                cabin_color = new Color(cabin_color.r, cabin_color.g, cabin_color.b, alpha);
            }

            if(deltaTime >= 75f){
                float alpha = 76f - deltaTime;
                if(alpha < 0f) alpha = 0f;
                vlp_color = new Color(vlp_color.r, vlp_color.g, vlp_color.b, alpha);
            }

            // if(deltaTime >= 90f){
            //     float val = 1 + (deltaTime - 90f) / 15f;
            //     if(val > 2f) val = 2f;
            //     Main.transform.localScale = Vector3.one * val;
            //     zoomSlider.mainSlider.value = val - 1f;
            // }
        }
    }
    //control zooming
    public void OnZoomChange(){
        float val = 1 + zoomSlider.mainSlider.value;
        Main.transform.localScale = Vector3.one * val;
    }
    //create wlps
    void CreatePoints(){
        if(tickCounter >= CommonFuns.summary.Count)
            tickCounter = 0;
        SummaryInfo summeryInfo = CommonFuns.summary[tickCounter];
        for(int i = 0; i < 8; i ++){
            GameObject obj = (GameObject)Instantiate(vlpTemplate, container);
            VLPMovement vlp = obj.GetComponent<VLPMovement>();
            List<PositionInfo> baseTable = new List<PositionInfo>();
            bool direction = false;
            bool show_cabin = false;
            bool isSpecial = false;
            Color additionalColor = cabin_color;

            switch(i) {
            case 0:
                if(deltaTime <= 75){
                    baseTable = CommonFuns.bridge_a;
                }else{
                    if(summeryInfo.a == ""){
                        baseTable = CommonFuns.bridge_a;
                    } else{
                        baseTable = GetBaseTableFromSummery(summeryInfo.a);
                        show_cabin = true;
                    }

                    if(summeryInfo.a != "" && !isNormalCabin(summeryInfo.a)){
                        isSpecial = true;
                        additionalColor = bridgeCabinColors[cabinColorIndex];
                        cabinColorIndex++;
                    }
                }
                direction = false;
                break;
            case 1:
                if(deltaTime <= 75){
                    baseTable = CommonFuns.bridge_b;
                }else{
                    if(summeryInfo.b == ""){
                        baseTable = CommonFuns.bridge_b;
                    } else{
                        baseTable = GetBaseTableFromSummery(summeryInfo.b);
                        show_cabin = true;
                    }

                    if(summeryInfo.b != "" && !isNormalCabin(summeryInfo.b)){
                        isSpecial = true;
                        additionalColor = bridgeCabinColors[cabinColorIndex];
                        cabinColorIndex++;
                    }
                }
                direction = false;
                break;
            case 2:
                if(deltaTime <= 75){
                    baseTable = CommonFuns.bridge_c;
                }else{
                    if(summeryInfo.c == ""){
                        baseTable = CommonFuns.bridge_c;
                    } else{
                        baseTable = GetBaseTableFromSummery(summeryInfo.c);
                        show_cabin = true;
                    }

                    if(summeryInfo.c != "" && !isNormalCabin(summeryInfo.c)){
                        isSpecial = true;
                        additionalColor = bridgeCabinColors[cabinColorIndex];
                        cabinColorIndex++;
                    }
                }
                direction = false;
                break;
            case 3:
                if(deltaTime <= 75){
                    baseTable = CommonFuns.bridge_d;
                }else{
                    if(summeryInfo.d == ""){
                        baseTable = CommonFuns.bridge_d;
                    } else{
                        baseTable = GetBaseTableFromSummery(summeryInfo.d);
                        show_cabin = true;
                    }

                    if(summeryInfo.d != "" && !isNormalCabin(summeryInfo.d)){
                        isSpecial = true;
                        additionalColor = bridgeCabinColors[cabinColorIndex];
                        cabinColorIndex++;
                    }
                }
                direction = false;
                break;
            case 4:
                if(deltaTime <= 75){
                    baseTable = CommonFuns.bridge_e;
                }else{
                    if(summeryInfo.e == ""){
                        baseTable = CommonFuns.bridge_e;
                    } else{
                        baseTable = GetBaseTableFromSummery(summeryInfo.e);
                        show_cabin = true;
                    }

                    if(summeryInfo.e != "" && !isNormalCabin(summeryInfo.e)){
                        isSpecial = true;
                        additionalColor = bridgeCabinColors[cabinColorIndex];
                        cabinColorIndex++;
                    }
                }
                direction = true;
                break;
            case 5:
                if(deltaTime <= 75){
                    baseTable = CommonFuns.bridge_f;
                }else{
                    if(summeryInfo.f == ""){
                        baseTable = CommonFuns.bridge_f;
                    } else{
                        baseTable = GetBaseTableFromSummery(summeryInfo.f);
                        show_cabin = true;
                    }

                    if(summeryInfo.f != "" && !isNormalCabin(summeryInfo.f)){
                        isSpecial = true;
                        additionalColor = bridgeCabinColors[cabinColorIndex];
                        cabinColorIndex++;
                    }
                }
                direction = true;
                break;
            case 6:
                if(deltaTime <= 75){
                    baseTable = CommonFuns.bridge_g;
                }else{
                    if(summeryInfo.g == ""){
                        baseTable = CommonFuns.bridge_g;
                    } else{
                        baseTable = GetBaseTableFromSummery(summeryInfo.g);
                        show_cabin = true;
                    }

                    if(summeryInfo.g != "" && !isNormalCabin(summeryInfo.g)){
                        isSpecial = true;
                        additionalColor = bridgeCabinColors[cabinColorIndex];
                        cabinColorIndex++;
                    }
                }
                direction = true;
                break;
            case 7:
                if(deltaTime <= 75){
                    baseTable = CommonFuns.bridge_h;
                }else{
                    if(summeryInfo.h == ""){
                        baseTable = CommonFuns.bridge_h;
                    } else{
                        baseTable = GetBaseTableFromSummery(summeryInfo.h);
                        show_cabin = true;
                    }

                    if(summeryInfo.h != "" && !isNormalCabin(summeryInfo.h)){
                        isSpecial = true;
                        additionalColor = bridgeCabinColors[cabinColorIndex];
                        cabinColorIndex++;
                    }
                }
                direction = true;
                break;
            }

            if(cabinColorIndex >= bridgeCabinColors.Count)
                cabinColorIndex = 0;

            if(deltaTime < 45f)
                show_cabin = false;
            else if(deltaTime < 75f){
                if(UnityEngine.Random.Range(0, 100) < 20){
                    show_cabin = true;
                }
            }

            vlp.InitBridgePoses(baseTable, direction, show_cabin, isSpecial, additionalColor);
        }
        tickCounter ++;
    }
    
    public bool isNormalCabin(string type) {
        if(type == "A" || type == "B" || type == "C" || type == "D" || type == "E" || type == "F" || type == "G" || type == "H")
            return true;
        return false;
    }

    public List<PositionInfo> GetBaseTableFromSummery(string type) {
        switch(type) {
        case "A":
            return CommonFuns.bridge_a;
        case "B":
            return CommonFuns.bridge_b;
        case "C":
            return CommonFuns.bridge_c;
        case "D":
            return CommonFuns.bridge_d;
        case "E":
            return CommonFuns.bridge_e;
        case "F":
            return CommonFuns.bridge_f;
        case "G":
            return CommonFuns.bridge_g;
        case "H":
            return CommonFuns.bridge_h;
        case "A2B":
            return CommonFuns.bridge_a2b;
        case "A2C":
            return CommonFuns.bridge_a2c;
        case "A2D":
            return CommonFuns.bridge_a2d;
        case "B2A":
            return CommonFuns.bridge_b2a;
        case "B2C":
            return CommonFuns.bridge_b2c;
        case "B2D":
            return CommonFuns.bridge_b2d;
        case "C2A":
            return CommonFuns.bridge_c2a;
        case "C2B":
            return CommonFuns.bridge_c2b;
        case "C2D":
            return CommonFuns.bridge_c2d;
        case "D2A":
            return CommonFuns.bridge_d2a;
        case "D2B":
            return CommonFuns.bridge_d2b;
        case "D2C":
            return CommonFuns.bridge_d2c;
        case "E2F":
            return CommonFuns.bridge_e2f;
        case "E2G":
            return CommonFuns.bridge_e2g;
        case "E2H":
            return CommonFuns.bridge_e2h;
        case "F2E":
            return CommonFuns.bridge_f2e;
        case "F2G":
            return CommonFuns.bridge_f2g;
        case "F2H":
            return CommonFuns.bridge_f2h;
        case "G2E":
            return CommonFuns.bridge_g2e;
        case "G2F":
            return CommonFuns.bridge_g2f;
        case "G2H":
            return CommonFuns.bridge_g2h;
        case "H2E":
            return CommonFuns.bridge_h2e;
        case "H2F":
            return CommonFuns.bridge_h2f;
        case "H2G":
            return CommonFuns.bridge_h2g;
        }
        Debug.Log(type + ":" + type.Length);
        return null;
    }

    public void OnStart(){
        isStart = true;
    }
}
