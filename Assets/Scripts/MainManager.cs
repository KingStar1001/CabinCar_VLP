using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;
using UnityEngine.UI;
using System;

[Serializable]
public class ColorSet{
    public Color back_color;
    public Color vlp_color;
    public Color cabin_color;
}
public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public GameObject vlpTemplate;

    public Transform container;

    public float deltaTime = 0f;
    public int index = 0;

    public Camera cam;

    public GameObject Main;
    public SliderManager zoomSlider;

    public GameObject settingWin;

    
    public SliderManager back_r;
    public SliderManager back_g;
    public SliderManager back_b;
    public SliderManager vlp_r;
    public SliderManager vlp_g;
    public SliderManager vlp_b;

    public Color back_color;
    public Color vlp_color;
    public Color cabin_color;

    public UISprite background;

    public GameObject settingOutCollider;

    public VLPMovement beforeVLP = null;

    public bool isStart = false;
    public GameObject startBtn;

    public Toggle color1Toggle;
    public Toggle color2Toggle;
    public Toggle color3Toggle;

    public List<ColorSet> colors;

    public int tickCounter = 0;
        bool isFirst = true;


    // Start is called before the first frame update
    void Awake(){
        instance = this;

        Screen.fullScreen = false;
        Screen.SetResolution(1680, 1188, FullScreenMode.Windowed, 24);
    }
    void Start()
    {
        back_r.mainSlider.value = back_color.r;
        back_g.mainSlider.value = back_color.g;
        back_b.mainSlider.value = back_color.b;
        vlp_r.mainSlider.value = vlp_color.r;
        vlp_g.mainSlider.value = vlp_color.g;
        vlp_b.mainSlider.value = vlp_color.b;
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

            if(deltaTime >= 60f){
                float alpha = deltaTime - 60f;
                if(alpha > 1f) alpha = 1f;
                cabin_color = new Color(cabin_color.r, cabin_color.g, cabin_color.b, alpha);
            }

            if(deltaTime >= 120f){
                float alpha = 121f - deltaTime;
                if(alpha < 0f) alpha = 0f;
                vlp_color = new Color(vlp_color.r, vlp_color.g, vlp_color.b, alpha);
            }

            if(deltaTime >= 180f){
                float val = 1 + (deltaTime - 180f) / 15f;
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
        int roadIndex = 0;
        tickCounter ++;
        foreach(LegendaInfo legenda in CommonFuns.legenda_data){
            int rotationType = 0;
            GameObject obj = (GameObject)Instantiate(vlpTemplate, container);
            VLPMovement vlp = obj.GetComponent<VLPMovement>();

            bool direction = false;
            float constPos = 0f;
            if(legenda.direction == "h"){
                direction = false;
                constPos = legenda.y / 500f - 594f;
            } else {
                direction = true;
                constPos = legenda.x / 500f - 840f;
            }
            List<PositionInfo> baseTable = new List<PositionInfo>();
            if(legenda.baseTable == 1){
                baseTable = CommonFuns.e2w_data;
            } else if (legenda.baseTable == 2){
                baseTable = CommonFuns.w2e_data;
            } else if (legenda.baseTable == 3){
                baseTable = CommonFuns.s2n_data;
            } else if (legenda.baseTable == 4){
                baseTable = CommonFuns.n2s_data;
            }
            bool show_cabin = false;
            if(roadIndex == 8){
                if(tickCounter % 2 == 0){
                    show_cabin = true;
                }
            } else if(roadIndex == 7){
                if(tickCounter % 4 == 0){
                    show_cabin = true;
                }
            } else {
                if(UnityEngine.Random.Range(0, 100) < 20){
                    show_cabin = true;
                }
            }

            if (roadIndex == 15) {
                if (tickCounter >= 12) {
                    if ((tickCounter - 12) % 6 == 0) {
                        baseTable = CommonFuns.rt_data;
                        rotationType = 1;
                        if(deltaTime >= 60f){
                            show_cabin = true;
                        }
                    }
                }

                if (tickCounter >= 16) {
                    if ((tickCounter - 16) % 10 == 0) {
                        baseTable = CommonFuns.lt_data;
                        rotationType = 2;
                        if(deltaTime >= 60f){
                            show_cabin = true;
                        }
                    }
                }
            }
            if(deltaTime < 60f)
                show_cabin = false;

            vlp.InitCityPoses(baseTable, direction, legenda.horizontal, constPos, isFirst, beforeVLP, show_cabin, rotationType);
            if(isFirst)
                beforeVLP = vlp;
            isFirst = false;
            roadIndex++;
        }
    }

    public void ShowSettingWin(){
        settingWin.SetActive(true);
        settingOutCollider.SetActive(true);
    }

    public void HideSettingWin(){
        settingWin.SetActive(false);
        settingOutCollider.SetActive(false);
    }

    public void OnBackgroundRColorChange(){
        back_color = new Color(back_r.mainSlider.value, back_color.g, back_color.b, 1);
        background.color = back_color;
    }
    public void OnBackgroundGColorChange(){
        back_color = new Color(back_color.r, back_g.mainSlider.value, back_color.b, 1);
        background.color = back_color;
    }
    public void OnBackgroundBColorChange(){
        back_color = new Color(back_color.r, back_color.g, back_b.mainSlider.value, 1);
        background.color = back_color;
    }

    public void OnVLPRColorChange(){
        vlp_color = new Color(vlp_r.mainSlider.value, vlp_color.g, vlp_color.b, 1);
    }

    public void OnVLPGColorChange(){
        vlp_color = new Color(vlp_color.r, vlp_g.mainSlider.value, vlp_color.b, 1);
    }

    public void OnVLPBColorChange(){
        vlp_color = new Color(vlp_color.r, vlp_color.g, vlp_b.mainSlider.value, 1);
    }

    public void OnStart(){
        isStart = true;
        startBtn.SetActive(false);
    }

    public void OnToggleChange(){
        if(color1Toggle.isOn){
            back_color = colors[0].back_color;
            vlp_color = colors[0].vlp_color;
            cabin_color = colors[0].cabin_color;
            background.color = back_color;
        }
        if(color2Toggle.isOn){
            back_color = colors[1].back_color;
            vlp_color = colors[1].vlp_color;
            cabin_color = colors[1].cabin_color;
            background.color = back_color;  
        }
        if(color3Toggle.isOn){
            back_color = colors[2].back_color;
            vlp_color = colors[2].vlp_color;
            cabin_color = colors[2].cabin_color;
            background.color = back_color;
        }
    }
}
