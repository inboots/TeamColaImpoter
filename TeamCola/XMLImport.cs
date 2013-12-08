using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

public class XMLImport
{
	private string m_xmlFile = string.Empty;
	public XMLImport(string xmlfile)
	{
		this.m_xmlFile = xmlfile;
	}

	public List<WorkLogEntity> GetWorkLog()
	{

		List<WorkLogEntity> wklogs = new List<WorkLogEntity>();

		XmlDocument xdoc = new XmlDocument();
		xdoc.Load(this.m_xmlFile);

		XmlNodeList xnl = xdoc.GetElementsByTagName("Row");

		for (int i = 0; i < xnl.Count; i++)
		{
			if (i <= 1 || xnl[i].ChildNodes.Count != 3) continue;

			XmlNodeList cells = xnl[i].ChildNodes;
			string st = cells[0].InnerText;
			string ed = cells[1].InnerText;
			string wlog = cells[2].InnerText;

			st = st.Replace("T", " ");
			ed = ed.Replace("T", " ");

			WorkLogEntity entity = new WorkLogEntity();
			entity.Start = DateTime.Parse(st);
			entity.End = DateTime.Parse(ed);
			entity.WorkLog = wlog;

			wklogs.Add(entity);
		}

		return wklogs;
	}

}

