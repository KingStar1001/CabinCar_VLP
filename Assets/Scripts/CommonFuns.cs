using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class PositionInfo{
    public int frame;
    public float pos;
    public float v;
    public float pos2;
}

public class LegendaInfo{
    public int id;
    public string name;
    public string direction;
    public string horizontal;
    public int baseTable;
    public float x;
    public float y;
    public int delay;
    public int frame_rate;
}
public class CommonFuns : MonoBehaviour
{
    //position datas
    public static List<PositionInfo> e2w_data = new List<PositionInfo>();
    public static List<PositionInfo> w2e_data = new List<PositionInfo>();
    public static List<PositionInfo> s2n_data = new List<PositionInfo>();
    public static List<PositionInfo> n2s_data = new List<PositionInfo>();
    public static List<PositionInfo> rt_data = new List<PositionInfo>();
    public static List<PositionInfo> lt_data = new List<PositionInfo>();

    public static List<PositionInfo> bridge_a = new List<PositionInfo>();

    public static List<PositionInfo> bridge_b = new List<PositionInfo>();

    public static List<PositionInfo> bridge_c = new List<PositionInfo>();

    public static List<PositionInfo> bridge_d = new List<PositionInfo>();

    public static List<PositionInfo> bridge_e = new List<PositionInfo>();

    public static List<PositionInfo> bridge_f = new List<PositionInfo>();

    public static List<PositionInfo> bridge_g = new List<PositionInfo>();

    public static List<PositionInfo> bridge_h = new List<PositionInfo>();

    //legenda data
    public static List<LegendaInfo> legenda_data = new List<LegendaInfo>();

    void Awake(){
        LoadE2W();
        LoadW2E();
        LoadS2N();
        LoadN2S();
        LoadRT();
        LoadLT();
        LoadLegenda();
        LoadBridgeA();
        LoadBridgeB();
        LoadBridgeC();
        LoadBridgeD();
        LoadBridgeE();
        LoadBridgeF();
        LoadBridgeG();
        LoadBridgeH();
    }
    public static string[] LoadData(string filename){

        string path = "Data/" + filename;
        var source = new StreamReader(path);
        var fileContents = source.ReadToEnd();
        source.Close();
        var lines = fileContents.Split("\n"[0]);
        return lines;
    }
    public static bool IsNumeric(string s)
    {
        s = s.Replace("\n","").Replace("\r","");
        if(s == "") return false;
        foreach (char c in s)
        {
            if (!char.IsDigit(c) && c != '.')
            {
                // Debug.LogError((int)c);
                return false;
            }
        }

        return true;
    }

    public static string changeDouble(string s) {
        if(s.Contains(".")){
            s = s.Substring(0, s.LastIndexOf('.'));
            // Debug.LogError(s);
        }
        return s;
    }

    //load e2w positions
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
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    e2w_data.Add(info);

                    // Debug.LogError("string:" + data[0] + " " + data[1] + " " + data[2]);
                    // Debug.LogError("value:" + info.frame + " " + info.pos + " " + info.v);
                }
            }
            index ++;
        }
    }

    //load w2e positions
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
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    w2e_data.Add(info);
                }
            }
            index ++;
        }
    }

    //load s2n positions
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
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    s2n_data.Add(info);
                }
            }
            index ++;
        }
    }

    //load n2s positions
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
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    n2s_data.Add(info);
                }
            }
            index ++;
        }
    }

    //load RT positions
    public static void LoadRT(){
        string[] lines = LoadData("RT.txt");
        
        rt_data.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 4){
                    int.TryParse(data[0], out info.frame);
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    if(IsNumeric(data[3])) {
                        info.pos2 = float.Parse(changeDouble(data[3]));
                    }
                    rt_data.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadLT(){
        string[] lines = LoadData("LT.txt");
        
        lt_data.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 4){
                    int.TryParse(data[0], out info.frame);
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    if(IsNumeric(data[3])) {
                        info.pos2 = float.Parse(changeDouble(data[3]));
                    }
                    lt_data.Add(info);
                }
            }
            index ++;
        }
    }

    //load legenda positions
    public static void LoadLegenda(){
        string[] lines = LoadData("Legenda.txt");
        
        legenda_data.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                LegendaInfo info = new LegendaInfo();
                if(data.Length == 9){
                    int.TryParse(data[0], out info.id);
                    info.name = data[1];
                    int.TryParse(data[2], out info.baseTable);
                    info.direction = data[3];
                    info.horizontal = data[4];
                    if(IsNumeric(data[5])) {
                        info.x = float.Parse(changeDouble(data[5]));
                    }
                    if(IsNumeric(data[6])) {
                        info.y = float.Parse(changeDouble(data[6]));
                    }
                    int.TryParse(data[7], out info.delay);
                    int.TryParse(data[8], out info.frame_rate);
                    legenda_data.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadBridgeA(){
        string[] lines = LoadData("Bridge/A.txt");
        
        bridge_a.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 4){
                    int.TryParse(data[0], out info.frame);
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    if(IsNumeric(data[3])) {
                        info.pos2 = float.Parse(changeDouble(data[3]));
                    }
                    bridge_a.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadBridgeB(){
        string[] lines = LoadData("Bridge/B.txt");
        
        bridge_b.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 4){
                    int.TryParse(data[0], out info.frame);
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    if(IsNumeric(data[3])) {
                        info.pos2 = float.Parse(changeDouble(data[3]));
                    }
                    bridge_b.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadBridgeC(){
        string[] lines = LoadData("Bridge/C.txt");
        
        bridge_c.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 4){
                    int.TryParse(data[0], out info.frame);
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    if(IsNumeric(data[3])) {
                        info.pos2 = float.Parse(changeDouble(data[3]));
                    }
                    bridge_c.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadBridgeD(){
        string[] lines = LoadData("Bridge/D.txt");
        
        bridge_d.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 4){
                    int.TryParse(data[0], out info.frame);
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    if(IsNumeric(data[3])) {
                        info.pos2 = float.Parse(changeDouble(data[3]));
                    }
                    bridge_d.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadBridgeE(){
        string[] lines = LoadData("Bridge/E.txt");
        
        bridge_e.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 4){
                    int.TryParse(data[0], out info.frame);
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    if(IsNumeric(data[3])) {
                        info.pos2 = float.Parse(changeDouble(data[3]));
                    }
                    bridge_e.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadBridgeF(){
        string[] lines = LoadData("Bridge/F.txt");
        
        bridge_f.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 4){
                    int.TryParse(data[0], out info.frame);
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    if(IsNumeric(data[3])) {
                        info.pos2 = float.Parse(changeDouble(data[3]));
                    }
                    bridge_f.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadBridgeG(){
        string[] lines = LoadData("Bridge/G.txt");
        
        bridge_g.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 4){
                    int.TryParse(data[0], out info.frame);
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    if(IsNumeric(data[3])) {
                        info.pos2 = float.Parse(changeDouble(data[3]));
                    }
                    bridge_g.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadBridgeH(){
        string[] lines = LoadData("Bridge/H.txt");
        
        bridge_h.Clear();
        int index = 0;
        foreach(string line in lines) {
            var data = line.Split("\t"[0]);
            if(index > 0){
                PositionInfo info = new PositionInfo();
                if(data.Length == 4){
                    int.TryParse(data[0], out info.frame);
                    if(IsNumeric(data[1])) {
                        info.pos = float.Parse(changeDouble(data[1]));
                    }
                    if(IsNumeric(data[2])) {
                        info.v = float.Parse(changeDouble(data[2]));
                    }
                    if(IsNumeric(data[3])) {
                        info.pos2 = float.Parse(changeDouble(data[3]));
                    }
                    bridge_h.Add(info);
                }
            }
            index ++;
        }
    }
}
