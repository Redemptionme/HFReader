using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace HFReader
{
	
	public class CsvTable 
	{
        private List<string> m_headers = new List<string>();
        
        private List<CsvRecord> m_records = new List<CsvRecord>();
      

        public List<string> Headers
	    {
	        get
	        {
	            return m_headers;
	        }
	    }
	   
	    public List<CsvRecord> Records
	    {
	        get
	        {
	            return m_records;
	        }
	    }
	   
	
	    public CsvTable ()
	    {
	        this.Initialize();
	    }

	    public void Initialize ()
	    {
	    }

	    public void Execution ()
	    {
	    }
	    public void AddHeaders (string header)
	    {
	        m_headers.Add(header);
	    }

	    public void AddRecord (CsvRecord record)
	    {
	        m_records.Add(record);
	    }

	    public CsvRecord GetRecord (int record_number)
	    {
	        return m_records[record_number];
	    }
	   
	}
}




