using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class PositionInfo{
    public int frame;
    public float pos;
    public float v;
}

public class LegendaInfo{
    public int id;
    public string name;
    public string direction;
    public int baseTable;
    public float x;
    public float y;
    public int delay;
    public int frame_rate;
}
public class CommonFuns : MonoBehaviour
{
    public static List<PositionInfo> e2w_data = new List<PositionInfo>();
    public static List<PositionInfo> w2e_data = new List<PositionInfo>();
    public static List<PositionInfo> s2n_data = new List<PositionInfo>();
    public static List<PositionInfo> n2s_data = new List<PositionInfo>();

    public static List<LegendaInfo> legenda_data = new List<LegendaInfo>();

    void Awake(){
        LoadE2W();
        LoadW2E();
        LoadS2N();
        LoadN2S();
        LoadLegenda();
    }
    public static string[] LoadData(string filename){

        string path = "Data/" + filename;
        var source = new StreamReader(path);
        var fileContents = source.ReadToEnd();
        source.Close();
        var lines = fileContents.Split("\n"[0]);
        return lines;
    }

    public static void LoadE2W(){
        string[] lines = LoadData("E2W.txt");
        
        e2w_data.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 3){
                    int.TryParse(data[0], out info.frame);
                    float.TryParse(data[1], out info.pos);
                    float.TryParse(data[2], out info.v);
                    e2w_data.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadW2E(){
        string[] lines = LoadData("W2E.txt");
        
        w2e_data.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 3){
                    int.TryParse(data[0], out info.frame);
                    float.TryParse(data[1], out info.pos);
                    float.TryParse(data[2], out info.v);
                    w2e_data.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadS2N(){
        string[] lines = LoadData("S2N.txt");
        
        s2n_data.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 3){
                    int.TryParse(data[0], out info.frame);
                    float.TryParse(data[1], out info.pos);
                    float.TryParse(data[2], out info.v);
                    s2n_data.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadN2S(){
        string[] lines = LoadData("N2S.txt");
        
        n2s_data.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 3){
                    int.TryParse(data[0], out info.frame);
                    float.TryParse(data[1], out info.pos);
                    float.TryParse(data[2], out info.v);
                    n2s_data.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadLegenda(){
        string[] lines = LoadData("Legenda.txt");
        
        legenda_data.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                LegendaInfo info = new LegendaInfo();
                if(data.Length == 8){
                    int.TryParse(data[0], out info.id);
                    info.name = data[1];
                    int.TryParse(data[2], out info.baseTable);
                    info.direction = data[3];
                    float.TryParse(data[4], out info.x);
                    float.TryParse(data[5], out info.y);
                    int.TryParse(data[6], out info.delay);
                    int.TryParse(data[7], out info.frame_rate);
                    legenda_data.Add(info);
                }
            }
            index ++;
        }
    }
}