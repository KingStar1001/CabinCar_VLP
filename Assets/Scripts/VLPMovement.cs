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
    public UISprite cabin_sprite;

    public bool has_cabin;

    public bool direction = false;
    public float constPos = 0f;

    public VLPMovement beforeVLP = null;

    public bool showDistanceLabel;
    public UILabel distanceLabel;

    public int rotationType;

    public int vlpContainerType = 0;

    public PositionInfo currentPositionInfo;

    public int beforeIndex = 0;
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
                if(vlpContainerType == 0) {
                    PositionInfo pos = movePoses[index];
                    if(beforeIndex != index && showDistanceLabel){
                        beforeIndex = index;
                        // Debug.LogError("index:" + index);
                        // Debug.LogError("position:" + pos.pos);
                    }
                    currentPositionInfo = pos;
                    float movement = pos.pos / 500f;
                    if(pos.pos <= 0.5f || pos.v <= 0.5f)
                        transform.localPosition = new Vector3(-1000, -1000, 0);
                    else{
                        if(rotationType == 0){
                            if(!direction){
                                movement -= 840f;
                                transform.localPosition = new Vector3(movement, constPos, 0);
                            } else {
                                movement -= 594f;
                                transform.localPosition = new Vector3(constPos, movement, 0);
                            }
                        } else {
                            if(!direction){
                                movement -= 840f;
                                float y = pos.pos2 / 500f - 594f;
                                transform.localPosition = new Vector3(movement, y, 0);
                            } else {
                                movement -= 594f;
                                float x = pos.pos2 / 500f - 840f;
                                transform.localPosition = new Vector3(x, movement, 0);
                            }
                        }
                    }
                }else{
                    PositionInfo pos = movePoses[index];
                    float movement = pos.pos / 500f;
                    movement -= 594f;
                    float x = pos.pos2 / 500f - 840f;
                    transform.localPosition = new Vector3(x, movement, 0);
                }
            }

            if(vlpContainerType == 0){
                vlpSprite.color = MainManager.instance.vlp_color;
                if(has_cabin && rotationType == 0)
                    cabin_sprite.color = MainManager.instance.cabin_color;

                if(rotationType != 0){
                    if(rotationType == 1){
                        if(index >= 586){
                            float rot = 90f - 90f * (index - 586f) / 119f;
                            if(rot < 0) rot = 0f;
                            cabin.transform.localEulerAngles = new Vector3(0, 0, rot);
                        }
                    } else if(rotationType == 2){
                        if(index >= 675){
                            float rot = 90f - 270f * (index - 675f) / 342f;
                            if(rot < -180f) rot = -180f;
                            cabin.transform.localEulerAngles = new Vector3(0, 0, rot);
                        }
                    }
                }
            }else{
                vlpSprite.color = BridgeManager.instance.vlp_color;
                if(has_cabin)
                    cabin_sprite.color = BridgeManager.instance.cabin_color;
            }
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

    public void InitCityPoses(List<PositionInfo> _poses, bool _direction, string _horizontal, float _constPos, bool showLabel, VLPMovement before, bool _has_cabin, int _rotationType){
        vlpContainerType = 0;
        rotationType = _rotationType;
        beforeVLP = before;
        showDistanceLabel = showLabel;
        direction = _direction;
        constPos = _constPos;
        movePoses = _poses;
        startMove = true;
        has_cabin = _has_cabin;
        cabin.SetActive(has_cabin);
        if(direction){
            if(_horizontal == "f"){
                cabin.transform.localEulerAngles = new Vector3(0, 0, 90);
            }else{
                cabin.transform.localEulerAngles = new Vector3(0, 0, 270);
            }
        }else{
            if(_horizontal == "f"){
                cabin.transform.localEulerAngles = new Vector3(0, 0, 180);
            }else{
                cabin.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }

        if(has_cabin){
            cabin.SetActive(true);
            if(rotationType == 0){
                cabin_sprite.color = new Color32(255, 255, 255, 255);
            } else if (rotationType == 1) {
                cabin_sprite.color = new Color32(255, 0, 0, 255);
                Debug.Log(movePoses.Count);
            } else if (rotationType == 2) {
                cabin_sprite.color = new Color32(0, 255, 0, 255);
                Debug.Log(movePoses.Count);
            }
        }else{
            cabin.SetActive(false);
        }
//        cabin.SetActive(false);
    }
    public void InitBridgePoses(List<PositionInfo> _poses, bool _direction, bool _has_cabin){
        vlpContainerType = 1;
        direction = _direction;
        movePoses = _poses;
        startMove = true;
        has_cabin = _has_cabin;
        cabin.SetActive(has_cabin);
        if(direction){
            cabin.transform.localEulerAngles = new Vector3(0, 0, 180);
        }else{
            cabin.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if(has_cabin){
            cabin.SetActive(true);
        }else{
            cabin.SetActive(false);
        }
//        cabin.SetActive(false);
    }
}
