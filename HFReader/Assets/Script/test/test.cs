using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HFReader;
using System.Runtime.InteropServices;

public class test : MonoBehaviour {
    //public TextAsset textCsv;
    public string str;

    Text text;
    private void Awake() {
        text = GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
        CsvLoader loader = new CsvLoader();
        CsvTable csvTable = loader.LoadCSV("Config/test");
        TestDataMap tMap = new TestDataMap();        
        IDataMap tempMap = tMap as IDataMap;
        loader.LoadCSV("Config/test",ref tempMap);
        //tMap.Load(ref csvTable);

        Dictionary<int, TestData> Dic = null;
        //tMap.GetMap(ref Dic);
        tMap.clearMap();

        //CsvTable csvTable = loader.LoadCSV("Config/" + str);
        foreach (CsvRecord record in csvTable.Records) {
            foreach (string header in csvTable.Headers) {
                Debug.Log(header + ":" + record.GetField(header));
                text.text = text.text + (header + ":" + record.GetField(header));
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
