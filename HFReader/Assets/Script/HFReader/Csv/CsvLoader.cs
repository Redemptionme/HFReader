/********************************************************************
	
	File Name:	CSVLoader.cs
	Date:	    2018/03/22	
	author:		hanlinhe	
	version:    1.0
	
	purpose:	
*********************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

namespace HFReader
{
    public class IDataMap
    {
        public virtual void Load(ref CsvTable table) { }
    }

    public class CsvLoader
    {        
        public CsvLoader() {
            this.Initialize();
        }
        public CsvLoader(ref IDataMap datamap) {
            this.Initialize();
        }

        public void Initialize() {
        }
        public void Execution() {
        }

        public CsvTable LoadCSV(TextAsset csvTextAsset) {            
            CsvTable csvTable = new CsvTable();   
            string csvText = csvTextAsset.text.Replace(Environment.NewLine, "\r");

            // Object removes all leading blank and trailing blank characters
            csvText = csvText.Trim('\r');
            
            string[] csv = csvText.Split('\r');            
            List<string> rows = new List<string>(csv);            
            string[] headers = rows[0].Split(',');            
            foreach (string header in headers) {
                csvTable.AddHeaders(header);
            }            
            rows.RemoveAt(0);            
            foreach (string row in rows) {                
                string[] fields = row.Split(',');                
                csvTable.AddRecord(CreateRecord(headers, fields));
            }
            return csvTable;
        }
        public CsvTable LoadCSV(string csv_path) {
            CsvTable csvTable = new CsvTable();
            TextAsset csvTextAsset = Resources.Load(csv_path) as TextAsset;

            //string t1 = Application.dataPath;
            //string t2 = Application.temporaryCachePath;
            //string t3 = Application.persistentDataPath;

            //StreamReader sr;
            //sr = File.OpenText(Application.dataPath + t_csv_path);

            // Replace CR (= carriage return) for each OS environment.
            string csvText = csvTextAsset.text.Replace(Environment.NewLine, "\r");

            // Object removes all leading blank and trailing blank characters
            csvText = csvText.Trim('\r');

            string[] csv = csvText.Split('\r');
            List<string> rows = new List<string>(csv);
            string[] headers = rows[0].Split(',');
            foreach (string header in headers) {
                csvTable.AddHeaders(header);
            }
            rows.RemoveAt(0);
            foreach (string row in rows) {
                string[] fields = row.Split(',');
                csvTable.AddRecord(CreateRecord(headers, fields));
            }
            return csvTable;
        }
        public CsvTable LoadCSV(string csv_path,ref IDataMap dataMap) {
            CsvTable csvTable = new CsvTable();
            TextAsset csvTextAsset = Resources.Load(csv_path) as TextAsset;

            //string t1 = Application.dataPath;
            //string t2 = Application.temporaryCachePath;
            //string t3 = Application.persistentDataPath;

            //StreamReader sr;
            //sr = File.OpenText(Application.dataPath + t_csv_path);

            // Replace CR (= carriage return) for each OS environment.
            string csvText = csvTextAsset.text.Replace(Environment.NewLine, "\r");

            // Object removes all leading blank and trailing blank characters
            csvText = csvText.Trim('\r');

            string[] csv = csvText.Split('\r');
            List<string> rows = new List<string>(csv);
            string[] headers = rows[0].Split(',');
            foreach (string header in headers) {
                csvTable.AddHeaders(header);
            }
            rows.RemoveAt(0);
            foreach (string row in rows) {
                string[] fields = row.Split(',');
                csvTable.AddRecord(CreateRecord(headers, fields));
            }
            dataMap.Load(ref csvTable);
            return csvTable;
        }

        private CsvRecord CreateRecord(string[] t_headers, string[] t_fields) {        
            CsvRecord record = new CsvRecord();            
            for (int i = 0; i < t_headers.Length; ++i) {
                record.AddField(t_headers[i], t_fields[i]);
            }
            return record;
        }        
    }    
}



