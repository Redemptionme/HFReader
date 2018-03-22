/********************************************************************
	
	File Name:	CSVRecord.cs
	Date:	    2018/03/22	
	author:		hanlinhe	
	version:    1.0
	
	purpose:	
*********************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
namespace HFReader
{
	
	public class CsvRecord 
	{
	    private Dictionary<string, string> m_record = new Dictionary<string, string>();
	
	    public CsvRecord ()
	    {
	        this.Initialize();
	    }
	
	    public void Initialize ()
	    {
	    }
	
	    public void Execution ()
	    {
	    }
	
	    public void AddField (string header, string field)
	    {     
	        if (!m_record.ContainsKey(header))
	        {
	            m_record.Add(header, field);
	        }
	    }
	
	    public string GetField (string header)
	    {       
	        if (m_record.ContainsKey(header))
	        {
	            return m_record[header];
	        }
	        return null;
	    }
	}
}




