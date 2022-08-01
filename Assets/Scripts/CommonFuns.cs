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

public class SummaryInfo{
    public string a;
    public string b;
    public string c;
    public string d;
    public string e;
    public string f;
    public string g;
    public string h;
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
    public static List<PositionInfo> bridge_a2b = new List<PositionInfo>();
    public static List<PositionInfo> bridge_a2c = new List<PositionInfo>();
    public static List<PositionInfo> bridge_a2d = new List<PositionInfo>();
    public static List<PositionInfo> bridge_b2c = new List<PositionInfo>();
    public static List<PositionInfo> bridge_b2d = new List<PositionInfo>();
    public static List<PositionInfo> bridge_c2d = new List<PositionInfo>();
    public static List<PositionInfo> bridge_d2a = new List<PositionInfo>();
    public static List<PositionInfo> bridge_d2b = new List<PositionInfo>();
    public static List<PositionInfo> bridge_d2c = new List<PositionInfo>();
    public static List<PositionInfo> bridge_c2a = new List<PositionInfo>();
    public static List<PositionInfo> bridge_c2b = new List<PositionInfo>();
    public static List<PositionInfo> bridge_b2a = new List<PositionInfo>();
    public static List<PositionInfo> bridge_e2f = new List<PositionInfo>();
    public static List<PositionInfo> bridge_e2g = new List<PositionInfo>();
    public static List<PositionInfo> bridge_e2h = new List<PositionInfo>();
    public static List<PositionInfo> bridge_f2g = new List<PositionInfo>();
    public static List<PositionInfo> bridge_f2h = new List<PositionInfo>();
    public static List<PositionInfo> bridge_g2h = new List<PositionInfo>();
    public static List<PositionInfo> bridge_h2e = new List<PositionInfo>();
    public static List<PositionInfo> bridge_h2f = new List<PositionInfo>();
    public static List<PositionInfo> bridge_h2g = new List<PositionInfo>();
    public static List<PositionInfo> bridge_g2e = new List<PositionInfo>();
    public static List<PositionInfo> bridge_g2f = new List<PositionInfo>();
    public static List<PositionInfo> bridge_f2e = new List<PositionInfo>();

    //legenda data
    public static List<LegendaInfo> legenda_data = new List<LegendaInfo>();

    public static List<SummaryInfo> summary = new List<SummaryInfo>();

    void Awake(){
        LoadE2W();
        LoadW2E();
        LoadS2N();
        LoadN2S();
        LoadRT();
        LoadLT();
        LoadLegenda();

        LoadBridgeData("Bridge/A.txt", bridge_a);
        LoadBridgeData("Bridge/B.txt", bridge_b);
        LoadBridgeData("Bridge/C.txt", bridge_c);
        LoadBridgeData("Bridge/D.txt", bridge_d);
        LoadBridgeData("Bridge/E.txt", bridge_e);
        LoadBridgeData("Bridge/F.txt", bridge_f);
        LoadBridgeData("Bridge/G.txt", bridge_g);
        LoadBridgeData("Bridge/H.txt", bridge_h);
        LoadBridgeData("Bridge/A2B.txt", bridge_a2b);
        LoadBridgeData("Bridge/A2C.txt", bridge_a2c);
        LoadBridgeData("Bridge/A2D.txt", bridge_a2d);
        LoadBridgeData("Bridge/B2A.txt", bridge_b2a);
        LoadBridgeData("Bridge/B2C.txt", bridge_b2c);
        LoadBridgeData("Bridge/B2D.txt", bridge_b2d);
        LoadBridgeData("Bridge/C2A.txt", bridge_c2a);
        LoadBridgeData("Bridge/C2B.txt", bridge_c2b);
        LoadBridgeData("Bridge/C2D.txt", bridge_c2d);
        LoadBridgeData("Bridge/D2A.txt", bridge_d2a);
        LoadBridgeData("Bridge/D2B.txt", bridge_d2b);
        LoadBridgeData("Bridge/D2C.txt", bridge_d2c);
        LoadBridgeData("Bridge/E2F.txt", bridge_e2f);
        LoadBridgeData("Bridge/E2G.txt", bridge_e2g);
        LoadBridgeData("Bridge/E2H.txt", bridge_e2h);
        LoadBridgeData("Bridge/F2E.txt", bridge_f2e);
        LoadBridgeData("Bridge/F2G.txt", bridge_f2g);
        LoadBridgeData("Bridge/F2H.txt", bridge_f2h);
        LoadBridgeData("Bridge/G2E.txt", bridge_g2e);
        LoadBridgeData("Bridge/G2F.txt", bridge_g2f);
        LoadBridgeData("Bridge/G2H.txt", bridge_g2h);
        LoadBridgeData("Bridge/H2E.txt", bridge_h2e);
        LoadBridgeData("Bridge/H2F.txt", bridge_h2f);
        LoadBridgeData("Bridge/H2G.txt", bridge_h2g);

        LoadSummary();
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

    public static void LoadBridgeData(string file_name, List<PositionInfo> table){
        string[] lines = LoadData(file_name);
        
        table.Clear();
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
                    table.Add(info);
                }
            }
            index ++;
        }
    }

    public static void LoadSummary() {
        string[] lines = LoadData("Bridge/SUMMARY.txt");
        
        summary.Clear();
        int index = 0;
        foreach(string line in lines) {
            string str = line.Replace("\r", "");
            str = str.Replace("\n", "");
            var data = str.Split("\t"[0]);
            if(index > 0){
                SummaryInfo info = new SummaryInfo();
                if(data.Length == 8){
                    info.a = data[0];
                    info.b = data[1];
                    info.c = data[2];
                    info.d = data[3];
                    info.e = data[4];
                    info.f = data[5];
                    info.g = data[6];
                    info.h = data[7];
                    summary.Add(info);
                }
            }
            index ++;
        }
    }
}
