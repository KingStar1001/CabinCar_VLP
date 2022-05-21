using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VLPMovement : MonoBehaviour
{
    public float deltaTime = 0f;

    private List<PositionInfo> movePoses;
    private bool startMove = false;
    
    private bool colorStatus = true;
    private float colorDeltaTime = 0f;
    public UISprite vlpSprite;
    public UISprite vlpGlurSprite;
    public GameObject cabin;

    public bool has_cabin;

    public bool direction = false;
    public float constPos = 0f;

    public VLPMovement beforeVLP = null;

    public bool showDistanceLabel;
    public UILabel distanceLabel;

    public PositionInfo currentPositionInfo;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ////// update wlp positions every second
        if(startMove){
            deltaTime += Time.deltaTime;
            int index = (int)(deltaTime * 24f);
            if(movePoses.Count <= index){
                DestroyObject(gameObject);
            }else{
                PositionInfo pos = movePoses[index];
                currentPositionInfo = pos;
                float movement = pos.pos / 500f;
                if(pos.pos <= 0.5f || pos.v <= 0.5f)
                    transform.localPosition = new Vector3(-1000, -1000, 0);
                else{
                    if(!direction){
                        movement -= 840f;
                        transform.localPosition = new Vector3(movement, constPos, 0);
                    } else {
                        movement -= 594f;
                        transform.localPosition = new Vector3(constPos, movement, 0);
                    }
                }
            }
            vlpSprite.color = MainManager.instance.vlp_color;

            // if(showDistanceLabel){
            //     if(beforeVLP != null){
            //         distanceLabel.gameObject.SetActive(true);
            //         distanceLabel.text = ((int)(currentPositionInfo.pos - beforeVLP.currentPositionInfo.pos)).ToString();
            //     }else{
            //         distanceLabel.gameObject.SetActive(false);
            //     }
            // }else{
            //     distanceLabel.gameObject.SetActive(false);
            // }
/*
            if(has_cabin){
                colorDeltaTime += Time.deltaTime;
                if(colorDeltaTime >= 0.3f){
                    colorDeltaTime = 0f;
                    colorStatus = !colorStatus;
                    if(colorStatus){
                        vlpSprite.color = new Color32(0, 255, 0, 255);
                        vlpGlurSprite.color = new Color32(0, 255, 0, 56);
                    }else{
                        vlpSprite.color = new Color32(0, 0, 255, 255);
                        vlpGlurSprite.color = new Color32(0, 0, 255, 56);
                    }
                }
            }else{
                vlpSprite.color = new Color32(0, 255, 0, 255);
                vlpGlurSprite.color = new Color32(0, 255, 0, 56);
            }*/
        }
    }

    public void InitPoses(List<PositionInfo> _poses, bool _direction, float _constPos, bool showLabel, VLPMovement before){
        beforeVLP = before;
        showDistanceLabel = showLabel;
        direction = _direction;
        constPos = _constPos;
        movePoses = _poses;
        startMove = true;
        has_cabin = false;
        cabin.SetActive(false);
/*
        int rand = Random.Range(0, 4);
        if(rand == 0){
            cabin.SetActive(true);
            has_cabin = true;
        }else{
            cabin.SetActive(false);
            has_cabin = false;
        }*/
    }
}
