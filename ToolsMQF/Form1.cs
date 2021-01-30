using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ToolsMQF
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				txtPath.Text = openFileDialog1.FileName;
			}
			Save.Enabled = true;
		}
		private void button2_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.FileName != "")
			{
				try
				{
					byte[] data = File.ReadAllBytes(openFileDialog1.FileName);
					ReadValues r = new ReadValues(new BinaryReader(new MemoryStream(data)));
					if (r != null && data.Length != 0)
					{
						XmlDocument xmlDocument = new XmlDocument();
						XmlNode rootNode = xmlDocument.CreateElement("xml");
						xmlDocument.AppendChild(rootNode);
						r.ReadS(4);
						int questType = r.ReadD();
						r.ReadB(16);
						int valor = 0;
						int valor2 = 0;
						for (int i = 0; i < 40; i++)
						{
							int missionBId = valor2++;
							bool flag3 = valor2 == 4;
							if (flag3)
							{
								valor2 = 0;
								valor++;
							}
							int reqType = r.ReadUH();
							int type = r.ReadC();
							int mapId = r.ReadC();
							byte limitCount = r.ReadC();
							byte weaponClass = r.ReadC();
							int weaponId = r.ReadUH();
							XmlNode userNode = xmlDocument.CreateElement("Cards");
							XmlAttribute atr001_id = xmlDocument.CreateAttribute("id");
							atr001_id.Value = missionBId.ToString();
							userNode.Attributes.Append(atr001_id);
							XmlAttribute atr = xmlDocument.CreateAttribute("reqType");
							atr.Value = reqType.ToString();
							userNode.Attributes.Append(atr);
							XmlAttribute atr2 = xmlDocument.CreateAttribute("type");
							atr2.Value = type.ToString();
							userNode.Attributes.Append(atr2);
							XmlAttribute atr3 = xmlDocument.CreateAttribute("mapId");
							atr3.Value = mapId.ToString();
							userNode.Attributes.Append(atr3);
							XmlAttribute atr4 = xmlDocument.CreateAttribute("limitCount");
							atr4.Value = limitCount.ToString();
							userNode.Attributes.Append(atr4);
							XmlAttribute atr5 = xmlDocument.CreateAttribute("weaponClass");
							atr5.Value = weaponClass.ToString();
							userNode.Attributes.Append(atr5);
							XmlAttribute atr6 = xmlDocument.CreateAttribute("weaponId");
							atr6.Value = weaponId.ToString();
							userNode.Attributes.Append(atr6);
							rootNode.AppendChild(userNode);
							if (questType == 1)
							{
								r.ReadB(24);
							}
						}
						int vai = (questType == 2) ? 5 : 1;
						for (int j = 0; j < 10; j++)
						{
							XmlNode userNode2 = xmlDocument.CreateElement("CardAwards");
							int gp = r.ReadD();
							int xp = r.ReadD();
							int medals = r.ReadD();
							XmlAttribute atr001_id2 = xmlDocument.CreateAttribute("CardID");
							atr001_id2.Value = j.ToString();
							userNode2.Attributes.Append(atr001_id2);
							XmlAttribute atr7 = xmlDocument.CreateAttribute("gp");
							atr7.Value = gp.ToString();
							userNode2.Attributes.Append(atr7);
							XmlAttribute atr8 = xmlDocument.CreateAttribute("xp");
							atr8.Value = xp.ToString();
							userNode2.Attributes.Append(atr8);
							XmlAttribute atr9 = xmlDocument.CreateAttribute("medals");
							atr9.Value = medals.ToString();
							userNode2.Attributes.Append(atr9);
							for (int i2 = 0; i2 < vai; i2++)
							{
								int unk = r.ReadD();
								int type2 = r.ReadD();
								int itemId = r.ReadD();
								int itemCount = r.ReadD();
							}
							rootNode.AppendChild(userNode2);
						}
						if (questType == 2)
						{
							int goldResult = r.ReadD();
							r.ReadB(8);
							for (int k = 0; k < 5; k++)
							{
								int unkI = r.ReadD();
								int typeI = r.ReadD();
								int itemId2 = r.ReadD();
								int itemCount2 = r.ReadD();
								if (unkI > 0)
								{
									XmlNode userNode3 = xmlDocument.CreateElement("MissionItemAward");
									XmlAttribute atr001_id3 = xmlDocument.CreateAttribute("ID");
									atr001_id3.Value = k.ToString();
									userNode3.Attributes.Append(atr001_id3);
									XmlAttribute atr10 = xmlDocument.CreateAttribute("typeI");
									atr10.Value = typeI.ToString();
									userNode3.Attributes.Append(atr10);
									XmlAttribute atr11 = xmlDocument.CreateAttribute("itemId");
									atr11.Value = itemId2.ToString();
									userNode3.Attributes.Append(atr11);
									XmlAttribute atr12 = xmlDocument.CreateAttribute("itemCount");
									atr12.Value = itemCount2.ToString();
									userNode3.Attributes.Append(atr12);
									rootNode.AppendChild(userNode3);
								}
							}
						}
						XmlNode userNode4 = xmlDocument.CreateElement("UTF8");
						XmlAttribute credits = xmlDocument.CreateAttribute("Credits");
						credits.Value = "Owner of MoMz Games file, Reverse engineering made by - Wesley Vale";
						userNode4.Attributes.Append(credits);
						rootNode.AppendChild(userNode4);
						xmlDocument.Save(openFileDialog1.SafeFileName + ".xml");
						label1.ForeColor = Color.Green;
						label1.Text = "Saved successfully";
						Save.Enabled = false;
						openFileDialog1.Reset();
					}
				}
				catch
				{
					label1.ForeColor = Color.Red;
					label1.Text = "error opening the file";
				}
			}
			else
			{
				label1.ForeColor = Color.Red;
				label1.Text = "File not found";
			}
		}
	}
}
