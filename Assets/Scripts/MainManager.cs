using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;

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

    public UISprite background;

    public GameObject settingOutCollider;

    public VLPMovement beforeVLP = null;

    public bool isStart = false;
    public GameObject startBtn;
    // Start is called before the first frame update
    void Awake(){
        instance = this;
    }
    void Start()
    {
        Debug.Log("start");
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
        //create wlps every 1 second
        if(isStart){
            deltaTime += Time.deltaTime;
            int nowIndex = (int)(deltaTime);
            if(nowIndex > index){
                index = nowIndex;

                CreatePoints();
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
        bool isFirst = true;
        foreach(LegendaInfo legenda in CommonFuns.legenda_data){
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
            vlp.InitPoses(baseTable, direction, constPos, isFirst, beforeVLP);
            if(isFirst)
                beforeVLP = vlp;
            isFirst = false;
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
}
