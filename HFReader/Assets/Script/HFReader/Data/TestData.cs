using System.Collections;
using System.Collections.Generic;
using HFReader;
using UnityEngine;

struct TestData{
    public int Id;
    public string Name;
    public string Content;
}

public class TestDataMap : IDataMap {
    private Dictionary<int, TestData> m_Dic = new Dictionary<int, TestData>() ;
    

    public override void Load(ref CsvTable table) {
        foreach (CsvRecord record in table.Records) {
            TestData data;
            //data.Id = int.Parse(record.GetField(table.Headers[0]));
            data.Id = int.Parse(record.GetField("Id"));
            data.Name = record.GetField("Name");
            data.Content = record.GetField("Content");

            if (!m_Dic.ContainsKey(data.Id)) {
                m_Dic.Add(data.Id, data);
            }
        }
    }

    public object GetMap() {
        return m_Dic;
    }

    public void clearMap() {
        Dictionary<int, TestData> Dic = m_Dic;
        m_Dic.Clear();
    }
}
